using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Controllers
{
    public class ProductController : Controller
    {
        private readonly WineDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        public ProductController(WineDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int? id, int colorid = 1, int sizeid = 1)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Speciality)
                .Include(p => p.Vendor)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.ProductColorSizes.Any(p => p.ProductId == id && p.ColorId == colorid && p.SizeId == sizeid) && !p.IsDeleted);
            if (product == null) return NotFound();

            List<int> dbSizes = new List<int>();
            for (int i = 0; i < product.ProductColorSizes.Count(); i++)
            {
                dbSizes.Add((int)product.ProductColorSizes[i].SizeId);
            }
            dbSizes = dbSizes.Distinct().ToList();
            List<Size> sizes = new List<Size>();
            for (int i = 0; i < dbSizes.Count(); i++)
            {
                sizes.Add(_context.Sizes.Where(p=>p.Id == dbSizes[i]).FirstOrDefault());
            }
            ViewBag.SizesDet = sizes;



            List<int> dbColors = new List<int>();
            for (int i = 0; i < product.ProductColorSizes.Count(); i++)
            {
                dbColors.Add((int)product.ProductColorSizes[i].ColorId);
            }
            dbColors = dbColors.Distinct().ToList();
            List<Color> colors = new List<Color>();
            for (int i = 0; i < dbColors.Count(); i++)
            {
                colors.Add(_context.Colors.Include(p=>p.ProductColorSizes).Where(p => p.Id == dbColors[i]).FirstOrDefault());
            }
            ViewBag.ColorsDet = colors;



            ProductColorSize productColorSize = _context.ProductColorSizes.FirstOrDefault(p => p.ProductId == product.Id && p.ColorId == colorid && p.SizeId == sizeid);
            if (productColorSize == null) return NotFound();
            ViewBag.StockCount = productColorSize.StockCount;

            ViewBag.RelatedProducts = _context.Products.Where(p => p.CategoryId == product.CategoryId && !p.IsDeleted).ToList();
            ViewBag.ReccomendedProducts = _context.Products.Where(p => !p.IsDeleted).ToList();
            ViewBag.Products = _context.Products.Where(p =>!p.IsDeleted).OrderByDescending(p=>p.CreatedAt).ToList();
            List<ProductColorSize> productColorSizes = await _context
                .ProductColorSizes
                .Include(p=>p.Color)
                .Include(p=>p.Size)
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
            ViewBag.ColorId = productColorSize.ColorId;
            ViewBag.SizeId = productColorSize.SizeId;
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Reviews = await _context.Reviews.Where(p => p.ProductId == product.Id && !p.IsDeleted).ToListAsync(),
                Setting = await _context.Settings.FirstOrDefaultAsync()
            };
            return View(productVM);
        }
        public async Task<IActionResult> AddProdReview(string Message,int star, int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return PartialView("_LoginPartial");
            }
            if (id == null) return View();
            Review review = new Review();
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);
            review.Email = appUser.Email;
            review.Name = appUser.UserName;
            ProductVM productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted),
                Reviews = await _context.Reviews.Where(p => p.ProductId == id && !p.IsDeleted).ToListAsync()
            };
            if (Message == null || Message == "" || Message.Trim() == null || Message.Trim() == "")
            {
                return PartialView("_AddReviewForProductPartial", productVM);
            }

            review.Message = Message.Trim();
            if (star == 0 || star < 0 || star > 5)
            {
                review.Star = 1;
            }
            else
            {
                review.Star = star;
            }
            review.ProductId = (int)id;
            review.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id),
                Reviews = await _context.Reviews.Where(p => p.ProductId == id && !p.IsDeleted).ToListAsync()
            };
            return PartialView("_AddReviewForProductPartial", productVM);
        }
        public async Task<IActionResult> Edit(string Message, int? id)
        {
            if (id == null) return BadRequest();
            Review dbReview = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (dbReview == null) return NotFound();

            if (Message != null && Message.Trim() != null && Message.Trim() != "")
            {
                dbReview.Message = Message.Trim();
            }
            dbReview.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            ProductVM productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(P=>P.Id == dbReview.ProductId && !P.IsDeleted),
                Reviews = await _context.Reviews.Where(p => p.ProductId == dbReview.ProductId && !p.IsDeleted).ToListAsync()
            };
            return PartialView("_AddReviewForProductPartial", productVM);
        }
        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (id == null) return BadRequest();

            Review review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (review == null) return NotFound();

            review.IsDeleted = true;
            review.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            ProductVM productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(P => P.Id == review.ProductId && !P.IsDeleted),
                Reviews = await _context.Reviews.Where(p => p.ProductId == review.ProductId && !p.IsDeleted).ToListAsync()
            };
            return PartialView("_AddReviewForProductPartial", productVM);
        }
        public async Task<IActionResult> ProdCommentCount(int? id)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (product == null) return NotFound();
            IEnumerable<Review> reviews = await _context.Reviews.Where(r => !r.IsDeleted && r.ProductId == id).ToListAsync();

            return Content($"{reviews.Count()}");
        }
        public async Task<IActionResult> GeneralStar(int? id)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (product == null) return NotFound();
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Reviews = await _context.Reviews.Where(p => p.ProductId == product.Id && !p.IsDeleted).ToListAsync()
            };
            return PartialView("_ProductReviewStars",productVM);
        }
        public async Task<IActionResult> toTagCatSpeVen(string which,int? whichId, string sortby, int countby = 1, int page = 1)
        {
            ViewBag.PageIndex = page;
            ViewBag.WhichName = await _context.Categories.FirstOrDefaultAsync(c => c.Id == whichId);
            Category category = await _context.Categories.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == whichId);
            Speciality speciality = await _context.Specialities.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == whichId);
            Vendor vendor = await _context.Vendors.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == whichId);
            if (category == null && speciality == null && vendor == null) return NotFound();
            List<Product> products = null;
            switch (which)
            {
                case "Category":
                    ViewBag.WhichName = category.Name;
                    products = await _context.Products
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                        .Where(p => p.Category.Id == whichId && !p.IsDeleted).ToListAsync();
                    break;
                case "Speciality":
                    ViewBag.WhichName = speciality.Name;
                    products = await _context.Products
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                        .Where(p => p.Speciality.Id == whichId && !p.IsDeleted).ToListAsync();
                    break;
                case "Vendor":
                    ViewBag.WhichName = vendor.Name;
                    products = await _context.Products
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                        .Where(p => p.Vendor.Id == whichId && !p.IsDeleted).ToListAsync();
                    break;
                default:
                    products = await _context.Products
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                        .Where(p=>!p.IsDeleted)
                        .ToListAsync();
                    break;
            }
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);
            return View(products.Skip((page - 1) * 5).Take(4));
        }
        public async Task<IActionResult> DetailSizeColor(int? id,int colorid,int sizeid)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products
                .Include(p => p.Speciality)
                .Include(p => p.Vendor)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Reviews = await _context.Reviews.Where(p=>p.ProductId == product.Id).ToListAsync()
            };
            List<ProductColorSize> productColorSizes = await _context
                .ProductColorSizes
                .Include(p => p.Color)
                .Include(p => p.Size)
                .ToListAsync();

            List<int> dbSizes = new List<int>();
            for (int i = 0; i < product.ProductColorSizes.Count(); i++)
            {
                dbSizes.Add((int)product.ProductColorSizes[i].SizeId);
            }
            dbSizes = dbSizes.Distinct().ToList();
            List<Size> sizes = new List<Size>();
            for (int i = 0; i < dbSizes.Count(); i++)
            {
                sizes.Add(_context.Sizes.Where(p => p.Id == dbSizes[i]).FirstOrDefault());
            }
            ViewBag.SizesDet = sizes;



            List<int> dbColors = new List<int>();
            for (int i = 0; i < product.ProductColorSizes.Count(); i++)
            {
                dbColors.Add((int)product.ProductColorSizes[i].ColorId);
            }
            dbColors = dbColors.Distinct().ToList();
            List<Color> colors = new List<Color>();
            for (int i = 0; i < dbColors.Count(); i++)
            {
                colors.Add(_context.Colors.Include(p => p.ProductColorSizes).Where(p => p.Id == dbColors[i]).FirstOrDefault());
            }
            ViewBag.ColorsDet = colors;
            Product stProduct = await _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Speciality)
                .Include(p => p.Vendor)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.ProductColorSizes.Any(p=>p.ColorId == colorid && p.SizeId == sizeid));
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
            return PartialView("_ProductDetailRightPartial", productVM);
        }
    }
}
