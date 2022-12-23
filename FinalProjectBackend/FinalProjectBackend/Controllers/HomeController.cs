using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels;
using FinalProjectBackend.ViewModels.Account;
using FinalProjectBackend.ViewModels.Basket;
using FinalProjectBackend.ViewModels.Product;
using FinalProjectBackend.ViewModels.Wishlist;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly WineDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        public HomeController(WineDbContext context, UserManager<AppUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }
        public IActionResult Index()
        {
            ViewBag.Home = "home";
            HomeVM homevm = new HomeVM()
            {
                Home = _context.Homes.FirstOrDefault(),
                IntroSliders =  _context.IntroSliders.ToList(),
                Products =  _context.Products
                .Include(p=>p.ProductColorSizes)
                .ToList(),
                HomeSpecialCards =  _context.HomeSpecialCards.ToList(),
                HomeOurClientsSliders =  _context.HomeOurClientsSliders.ToList(),
                HomeCounts =  _context.HomeCounts.ToList(),
                HomeGalleries =  _context.HomeGalleries
                .Include(p=>p.Category)
                .ToList(),
            };
            return View(homevm);
        }
        public async Task<IActionResult> AddToBasket(int? id, int? colorid, int? sizeid,int count = 1)
        {
            if (colorid == null || sizeid == null) return BadRequest();

            if (!await _context.Colors.AnyAsync(p => p.Id == colorid && !p.IsDeleted) ||
                !await _context.Sizes.AnyAsync(p => p.Id == sizeid && !p.IsDeleted)) return NotFound();

            if (id == null) return BadRequest();
            Product dBproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (dBproduct == null) return NotFound();

            ProductColorSize productColorSize = _context.ProductColorSizes
                .Include(p=>p.Color)
                .Include(p=>p.Size)
                .FirstOrDefault(p =>p.ProductId == dBproduct.Id && p.ColorId == colorid&& p.SizeId == sizeid);
            if (productColorSize == null) return NotFound();
            List<BasketVM> basketVMs = null;

            string cookie = HttpContext.Request.Cookies["basket"];

            if (cookie != "" && cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
                if (basketVMs.Any(b => b.ProductId == dBproduct.Id && b.ColorId == colorid && b.SizeId == sizeid))
                {
                    if(basketVMs.Find(b => b.ProductId == dBproduct.Id && b.ColorId == colorid && b.SizeId == sizeid).Count+count <= productColorSize.StockCount)
                    {
                        basketVMs.Find(b => b.ProductId == dBproduct.Id && b.ColorId == colorid && b.SizeId == sizeid).Count += count;
                    }
                    else
                    {
                        basketVMs.Find(b => b.ProductId == dBproduct.Id && b.ColorId == colorid && b.SizeId == sizeid).Count = productColorSize.StockCount;
                    }
                    count = basketVMs.Find(b => b.ProductId == dBproduct.Id && b.ColorId == colorid && b.SizeId == sizeid).Count;
                }
                else
                {
                    basketVMs.Add(new BasketVM
                    {
                        ProductId = dBproduct.Id,
                        Count = count,
                        ColorId = productColorSize.Color.Id,
                        ColorName = productColorSize.Color.Name,
                        SizeId = productColorSize.Size.Id,
                        SizeName = productColorSize.Size.Name,
                        Price = productColorSize.DiscountPrice > 0 ? productColorSize.DiscountPrice : productColorSize.Price,
                        StockCount = productColorSize.StockCount
                    });
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();

                basketVMs.Add(new BasketVM()
                {
                    ProductId = dBproduct.Id,
                    Count = count,
                    ColorId = productColorSize.Color.Id,
                    ColorName = productColorSize.Color.Name,
                    SizeId = productColorSize.Size.Id,
                    SizeName = productColorSize.Size.Name,
                    Price = productColorSize.DiscountPrice > 0 ? productColorSize.DiscountPrice : productColorSize.Price,
                    StockCount = productColorSize.StockCount
                });
            }

            if (User.Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(cookie))
            {
                AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name.ToUpper() && !u.IsAdmin);
                if (appUser != null)
                {
                    Basket basket = await _context.Baskets.FirstOrDefaultAsync(b => b.AppUserId == appUser.Id && !b.IsDeleted && b.ProductId == id && b.ColorId == colorid && b.SizeId == sizeid);

                    if (basket != null)
                    {
                        basket.Count = count;
                    }
                    else
                    {
                        basket = new Basket
                        {
                            AppUserId = appUser.Id,
                            ProductId = id,
                            SizeId = sizeid,
                            ColorId = colorid,
                            Price = productColorSize.DiscountPrice > 0 ? productColorSize.DiscountPrice : productColorSize.Price,
                            Count = count
                        };

                        await _context.Baskets.AddAsync(basket);
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                ProductColorSize productColor = _context.ProductColorSizes
                      .FirstOrDefault(p => p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId && p.ProductId == basketVM.ProductId);
                Product dbProduct = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = productColor.Image;
                basketVM.Name = dbProduct.Name;
                basketVM.ExTax = dbProduct.ExTax;
                basketVM.Price = productColor.DiscountPrice > 0 ? productColor.DiscountPrice : productColor.Price;
                basketVM.StockCount = productColor.StockCount;
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

            return PartialView("_BasketPartial", basketVMs);
        }
        
        public async Task<IActionResult> AddToWishlist(int? id, int colorid = 1, int sizeid = 1)
        {
            if (colorid == null || sizeid == null) return BadRequest();
            Color color = await _context.Colors.FirstOrDefaultAsync(p => p.Id == colorid && !p.IsDeleted);
            Size size = await _context.Sizes.FirstOrDefaultAsync(p => p.Id == sizeid && !p.IsDeleted);
            if (color == null || size == null) return NotFound();

            if (id == null) return BadRequest();
            Product dBproduct = await _context.Products
                .Include(p=>p.ProductColorSizes)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (dBproduct == null) return NotFound();

            ProductColorSize productColorSize = _context.ProductColorSizes
                .Include(p => p.Color)
                .Include(p => p.Size)
                .FirstOrDefault(p => p.ProductId == dBproduct.Id && p.ColorId == color.Id && p.SizeId == size.Id);
            if (productColorSize == null) return NotFound();

            List<WishlistVM> wishlistVMs = null;

            string cookie = HttpContext.Request.Cookies["wishlist"];

            if (cookie != "" && cookie != null)
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookie);
                if (!wishlistVMs.Any(b => b.ProductId == dBproduct.Id && b.ColorId == colorid && b.SizeId == sizeid))
                {
                    wishlistVMs.Add(new WishlistVM
                    {
                        ProductId = dBproduct.Id,
                        ColorId = productColorSize.Color.Id,
                        ColorName = productColorSize.Color.Name,
                        SizeId = productColorSize.Size.Id,
                        SizeName = productColorSize.Size.Name,
                        Price = productColorSize.DiscountPrice == 0 ? productColorSize.Price : productColorSize.DiscountPrice,
                    });
                }
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();

                wishlistVMs.Add(new WishlistVM()
                {
                    ProductId = dBproduct.Id,
                    ColorId = productColorSize.Color.Id,
                    ColorName = productColorSize.Color.Name,
                    SizeId = productColorSize.Size.Id,
                    SizeName = productColorSize.Size.Name,
                    Price = productColorSize.DiscountPrice == 0 ? productColorSize.Price : productColorSize.DiscountPrice,
                });
            }


            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.ToUpper() == User.Identity.Name.ToUpper() && !u.IsAdmin);
                if (appUser == null)
                {
                    return BadRequest();
                }
                List<Wishlist> wishlists = new List<Wishlist>();
                Wishlist existWishlist =
                    await _context.Wishlists.FirstOrDefaultAsync(p =>
                p.AppUserId == appUser.Id &&
                p.ProductId == dBproduct.Id &&
                p.Product.ProductColorSizes.Any(p=>p.ColorId == color.Id && p.SizeId == size.Id)
                );

                if(existWishlist == null)
                {
                    Wishlist wishlist = new Wishlist()
                    {
                        AppUserId = appUser.Id,
                        ProductId = dBproduct.Id,
                        ColorId = colorid,
                        SizeId = sizeid,
                        Price = dBproduct.ProductColorSizes.Find(p=>p.ColorId == colorid && p.SizeId == sizeid).DiscountPrice == 0 ?
                        dBproduct.ProductColorSizes.Find(p => p.ColorId == colorid && p.SizeId == sizeid).Price :
                        dBproduct.ProductColorSizes.Find(p => p.ColorId == colorid && p.SizeId == sizeid).DiscountPrice
                    };
                    wishlists.Add(wishlist);
                }
                await _context.Wishlists.AddRangeAsync(wishlists);
                await _context.SaveChangesAsync();
            }
            int count = await _context.Wishlists.CountAsync();
            int imgCount = 0;
            foreach (WishlistVM wishlistVM in wishlistVMs)
            {
                Product dbProduct = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == wishlistVM.ProductId && !p.IsDeleted);
                wishlistVM.Image = dbProduct.ProductColorSizes[imgCount].Image;
                wishlistVM.Name = dbProduct.Name;
                imgCount++;
            }
            HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlistVMs));
            return Content($"{count}");
        }
        public async Task<IActionResult> DetailModal(int? id, int colorid = 1, int sizeid = 1)
        {
            ViewBag.Colors= await _context.Colors.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Sizes = await _context.Sizes.Where(p => !p.IsDeleted).ToListAsync();

            if (colorid == null || sizeid == null) return BadRequest();
            Color color = await _context.Colors.FirstOrDefaultAsync(p => p.Id == colorid && !p.IsDeleted);
            Size size = await _context.Sizes.FirstOrDefaultAsync(p => p.Id == sizeid && !p.IsDeleted);
            if (color == null || size == null) return NotFound();

            ViewBag.Colorid = color.Id;
            ViewBag.Sizeid = size.Id;

            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                .Include(p=>p.Speciality)
                .Include(p=>p.Vendor)
                .Include(p=>p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            ProductColorSize productColorSize = _context.ProductColorSizes
                .Include(p => p.Color)
                .Include(p => p.Size)
                .FirstOrDefault(p => p.ProductId == product.Id && p.ColorId == color.Id && p.SizeId == size.Id);
            if (productColorSize == null) return NotFound();

            ViewBag.StockCount = product.ProductColorSizes.Find(p => p.ColorId == colorid && p.SizeId == sizeid).StockCount;
            if (!product.ProductColorSizes.Any(p=>p.ColorId == colorid && p.SizeId == sizeid))
            {
                return NotFound();
            }
            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                if (productColor.ProductId == id && productColor.ColorId == colorid && productColor.SizeId == sizeid)
                {
                    ViewBag.ProdCount = productColor.StockCount;
                    ViewBag.DisPrice = productColor.DiscountPrice;
                    ViewBag.Price = productColor.Price;
                }
            }
            ViewBag.ColorId = colorid;
            ViewBag.SizeId = sizeid;
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Reviews = await _context.Reviews.Where(p => p.ProductId == id && !p.IsDeleted).ToListAsync(),
            };
            return PartialView("_ProductModalPartial", productVM);
        }
        public async Task<int> Count()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }
            int imgCount = 0;
            foreach (BasketVM basketVM in basketVMs)
            {
                ProductColorSize productColor = _context.ProductColorSizes
                      .FirstOrDefault(p => p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId && p.ProductId == basketVM.ProductId);
                Product dbProduct = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.ProductColorSizes[imgCount].Image;
                basketVM.Name = dbProduct.Name;
                basketVM.ExTax = dbProduct.ExTax;
                basketVM.Price = productColor.DiscountPrice > 0 ? productColor.DiscountPrice : productColor.Price;
                basketVM.StockCount = productColor.StockCount;
                imgCount++;
            }

            return basketVMs.Count();
        }
        public async Task<IActionResult> SearchInput(string key)
        {
            List<Product> products = new List<Product>();
            if (key != null)
            {
                key = key.Trim();
                products = await _context.Products
                    .Include(p=>p.ProductColorSizes).ThenInclude(a=>a.Color)
                    .Include(p=>p.ProductColorSizes).ThenInclude(a=>a.Size)
                    .Include(p=>p.Category)
                    .Include(p=>p.Speciality)
                    .Include(p=>p.Vendor)
                .Where(p => !p.IsDeleted && 
                 p.Name.Contains(key)
                || p.Category.Name.Contains(key)
                || p.Speciality.Name.Contains(key)
                || p.Vendor.Name.Contains(key)
                || p.Category.Name.Contains(key)
                || p.ProductColorSizes.Any(p => p.Color.Name.Contains(key))
                || p.ProductColorSizes.Any(p => p.Size.Name.Contains(key))
                || p.ProductColorSizes.Any(p => p.Price.ToString().Contains(key))
                || p.ProductColorSizes.Any(p => p.DiscountPrice.ToString().Contains(key))
                )
                .ToListAsync();
                if(products == null)
                {
                    products = new List<Product>();
                }
            }
            return PartialView("_ProductListPartial", products);
        }
        public async Task<IActionResult> DetailSizeColor(int? id, int colorid, int sizeid)
        {
            if (colorid == null || sizeid == null) return BadRequest();
            Color color = await _context.Colors.FirstOrDefaultAsync(p => p.Id == colorid && !p.IsDeleted);
            Size size = await _context.Sizes.FirstOrDefaultAsync(p => p.Id == sizeid && !p.IsDeleted);
            if (color == null || size == null) return NotFound();

            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                .Include(p => p.Speciality)
                .Include(p => p.Vendor)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Reviews = await _context.Reviews.Where(p => p.ProductId == product.Id && !p.IsDeleted).ToListAsync()
            };
            ProductColorSize productColorSize = _context.ProductColorSizes
                .Include(p => p.Color)
                .Include(p => p.Size)
                .FirstOrDefault(p => p.ProductId == product.Id && p.ColorId == color.Id && p.SizeId == size.Id);

            List<ProductColorSize> productColorSizes = await _context
                .ProductColorSizes
                .Include(p => p.Color)
                .Include(p => p.Size)
                .ToListAsync();
            Product stProduct = await _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Speciality)
                .Include(p => p.Vendor)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.ProductColorSizes.Any(p => p.ColorId == colorid && p.SizeId == sizeid) && !p.IsDeleted);

            if (stProduct != null)
            {
                ViewBag.StockCount = stProduct.ProductColorSizes.Find(p => p.ColorId == colorid && p.SizeId == sizeid).StockCount;
            }
            foreach (ProductColorSize productColor in productColorSizes)
            {
                if (productColor.ProductId == id && productColor.ColorId == colorid && productColor.SizeId == sizeid)
                {
                    ViewBag.ProdCount = productColor.StockCount;
                    ViewBag.DisPrice = productColor.DiscountPrice;
                    ViewBag.Price = productColor.Price;
                }
            }
            ViewBag.ColorId = colorid;
            ViewBag.SizeId = sizeid;
            return PartialView("_ProductRightModalPartial", productVM);
        }
        public async Task<IActionResult> Subscriber(string email)
        {
            Subscriber subscriber = _context.Subscribers.FirstOrDefault(c => c.Email.Trim().ToLower() == email.Trim().ToLower());
            if(subscriber == null)
            {
                subscriber = new Subscriber()
                {
                    Email = email
                };
                string body = "";
                using (StreamReader stream = new StreamReader($"wwwroot/templates/Subscribe.html"))
                {
                    body = stream.ReadToEnd();
                }
                EmailVM emaill = _config.GetSection("Email").Get<EmailVM>();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emaill.SenderEmail, emaill.SenderName);
                mail.To.Add(new MailAddress(email));
                mail.Subject = "Thanks for subscribing";
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = emaill.Server;
                    smtp.Port = emaill.Port;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(emaill.SenderEmail, emaill.Password);
                    smtp.Send(mail);
                }

                _context.Subscribers.Add(subscriber);
                await _context.SaveChangesAsync();
                return Json(new { status = 200 });
            }
            else
            {
                return Json(new { status = 500 });
            }
        }
    }
}
