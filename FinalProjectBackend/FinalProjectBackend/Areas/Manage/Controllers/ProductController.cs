using FinalProjectBackend.DAL;
using FinalProjectBackend.Extensions;
using FinalProjectBackend.Helpers;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Account;
using FinalProjectBackend.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductController(WineDbContext context,IWebHostEnvironment env, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;
            IEnumerable<Product> products = new List<Product>();

            if (status != null)
            {
                products = await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                    .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                    .Where(t => t.IsDeleted == status)
                    .ToListAsync();
            }
            else
            {
                products = await _context.Products
                   .Include(p => p.Category)
                   .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                   .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                   .ToListAsync();
            }

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);
            return View(products.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Specialities = await _context.Specialities.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Vendors = await _context.Vendors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Specialities = await _context.Specialities.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Vendors = await _context.Vendors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            if (!ModelState.IsValid) return View(product);
            if (!await _context.Categories.AnyAsync(b => b.Id == product.CategoryId && !b.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Duzgun Category Secin ");
                return View(product);
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(product);
            }

            if (await _context.Products.AnyAsync(t => t.Name.ToLower().Trim() == product.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(product);
            }
            if (!product.IsBestseller && !product.IsFeatured && !product.IsNewArrival)
            {
                ModelState.AddModelError("IsFeatured", "You must select at least one");
                return View(product);
            }
            if (product.SizeIds.Count != product.ColorIds.Count() ||
                product.SizeIds.Count != product.Counts.Count ||
                product.SizeIds.Count != product.Prices.Count ||
                product.SizeIds.Count != product.DiscountPrices.Count ||
                product.SizeIds.Count != product.ImageFiles.Count() ||
                product.Counts.Count != product.ColorIds.Count ||
                product.Counts.Count != product.Prices.Count ||
                product.Counts.Count != product.DiscountPrices.Count ||
                product.Counts.Count != product.ImageFiles.Count() ||
                product.ColorIds.Count != product.Prices.Count ||
                product.ColorIds.Count != product.DiscountPrices.Count ||
                product.ColorIds.Count != product.ImageFiles.Count() ||
                product.DiscountPrices.Count != product.Prices.Count() ||
                product.DiscountPrices.Count != product.ImageFiles.Count()
                )
            {
                ModelState.AddModelError("", "Count,Price,DiscountPrice values are required.Can not empty.");
                return View(product);
            }
            foreach (int item in product.SizeIds)
            {
                if (!await _context.Sizes.AnyAsync(s => s.Id == item))
                {
                    ModelState.AddModelError("", "Incorect Size Id");
                    return View(product);
                }
            }

            foreach (int item in product.ColorIds)
            {
                if (!await _context.Colors.AnyAsync(s => s.Id == item))
                {
                    ModelState.AddModelError("", "Incorect Color Id");
                    return View(product);
                }
            }

            List<ProductColorSize> productColorSizes = new List<ProductColorSize>();

            for (int i = 0; i < product.ColorIds.Count(); i++)
            {
                if (product.DiscountPrices[i] > product.Prices[i])
                {
                    ModelState.AddModelError("", "DiscountPrice deyeri Price deyerinden kicik olmalidir");
                    return View(product);
                }
                if (!product.ImageFiles[i].CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("", "Sonu .jpeg olan fayl daxil edin");
                    return View(product);
                }
                if (!product.ImageFiles[i].CheckFileSize(300))
                {
                    ModelState.AddModelError("", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View(product);
                }
                ProductColorSize productColorSize = new ProductColorSize()
                {
                    ColorId = product.ColorIds[i],
                    SizeId = product.SizeIds[i],
                    StockCount = product.Counts[i],
                    DiscountPrice = product.DiscountPrices[i],
                    Price = product.Prices[i],
                    Image = product.ImageFiles[i].CreateFile(_env, "images", "products"),
                };
                productColorSizes.Add(productColorSize);
                product.Count += product.Counts[i];
            }
            for (int i = 0; i < productColorSizes.Count(); i++)
            {
                for (int a = 1; a < productColorSizes.Count() - i; a++)
                {
                    if (productColorSizes[i].ColorId == productColorSizes[i + a].ColorId && productColorSizes[i].SizeId == productColorSizes[i + a].SizeId)
                    {
                        ModelState.AddModelError("", "2 eyni deyer olmaz");
                        return View(product);
                    }
                }
            }

            //Hover image select
            if (product.HoverImageFile != null)
            {
                if (!product.HoverImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("HoverImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!product.HoverImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("HoverImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                product.HoverImage = product.HoverImageFile.CreateFile(_env, "images", "products");
            }
            else
            {
                if (product.ColorIds.Count() <= 1)
                {
                    ModelState.AddModelError("HoverImageFile", "Either select hover image or add a second value to the product"); ;
                    return View(product);
                }
                else
                {
                    product.HoverImage = productColorSizes[1].Image;
                }
            }
            product.MainImage = productColorSizes[0].Image;
            product.ProductColorSizes = productColorSizes;
            product.CreatedAt = DateTime.UtcNow.AddHours(4);
            product.Availability = product.Count > 0 ? true : false;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            if (_context.Subscribers != null && _context.Subscribers.Count() != 0)
            {

                string host = _httpContextAccessor.HttpContext.Request.Host.Value;

                string prodlink = $"http://localhost:46931/product/detail/{product.Id}?colorid={product.ProductColorSizes.ElementAt(0).ColorId}&sizeid={product.ProductColorSizes.ElementAt(0).SizeId}";
                MailMessage mail = new MailMessage();

                byte[] imageArray = System.IO.File.ReadAllBytes($"wwwroot/images/products/{product.MainImage}");
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                string body = string.Empty;

                using (StreamReader stream = new StreamReader($"wwwroot/templates/NewProduct.html"))
                {
                    body = stream.ReadToEnd();
                }

                body = body.Replace("{link}", prodlink);
                body = body.Replace("{productimage}", $"{host}/images/products/{product.MainImage}");

                EmailVM email = _config.GetSection("Email").Get<EmailVM>();

                mail.From = new MailAddress(email.SenderEmail, email.SenderName);
                mail.Subject = "New Product";
                mail.Body = body;
                foreach (var item in _context.Subscribers)
                {
                    mail.To.Add(new MailAddress(item.Email));
                }
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = email.Server;
                    smtp.Port = email.Port;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
                    smtp.Send(mail);
                }
            }


            return RedirectToAction("index");
        }
        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Specialities = await _context.Specialities.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Vendors = await _context.Vendors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product, int[] WhichImg, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Specialities = await _context.Specialities.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Vendors = await _context.Vendors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            //if (!ModelState.IsValid) return View(product);
            if (id == null) return BadRequest();

            if (id != product.Id) return BadRequest();

            Product dbProduct = await _context.Products
                 .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                 .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                 .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (dbProduct == null) return NotFound();


            if (product.SizeIds.Count != product.ColorIds.Count ||
                  product.SizeIds.Count != product.Counts.Count ||
                  product.SizeIds.Count != product.Prices.Count ||
                  product.SizeIds.Count != product.DiscountPrices.Count ||
                  product.Counts.Count != product.ColorIds.Count ||
                  product.Counts.Count != product.Prices.Count ||
                  product.Counts.Count != product.DiscountPrices.Count ||
                  product.ColorIds.Count != product.Prices.Count ||
                  product.ColorIds.Count != product.DiscountPrices.Count ||
                  product.DiscountPrices.Count != product.Prices.Count
                  )
            {
                ModelState.AddModelError("", "Count,Price,DiscountPrice values are required.Can not empty.");
                return View(product);
            }

            foreach (int item in product.SizeIds)
            {
                if (!await _context.Sizes.AnyAsync(s => s.Id == item))
                {
                    ModelState.AddModelError("", "Incorect Size Id");
                    return View(product);
                }
            }

            foreach (int item in product.ColorIds)
            {
                if (!await _context.Colors.AnyAsync(s => s.Id == item))
                {
                    ModelState.AddModelError("", "Incorect Color Id");
                    return View(product);
                }
            }
            int fileCount = 0;
            int wImg = 0;
            int ferq = 0;
            _context.ProductColorSizes.RemoveRange(dbProduct.ProductColorSizes);
            List<ProductColorSize> productColorSizes = new List<ProductColorSize>();
            for (int i = 0; i < product.ColorIds.Count(); i++)
            {
                //Price discountPrice
                if (product.Prices[i] < product.DiscountPrices[i])
                {
                    ModelState.AddModelError("", "Discount Price must less than Price");
                    return View(product);
                }
               
                ProductColorSize productColorSize = new ProductColorSize()
                {
                    Price = product.Prices[i],
                    DiscountPrice = product.DiscountPrices[i],
                    ColorId = product.ColorIds[i],
                    SizeId = product.SizeIds[i],
                    StockCount = product.Counts[i],
                    Image = dbProduct.ProductColorSizes.Any(p=>p.ColorId == product.ColorIds[i] && p.SizeId == product.SizeIds[i]) ? dbProduct.ProductColorSizes.Find(p => p.ColorId == product.ColorIds[i] && p.SizeId == product.SizeIds[i]).Image : ""
                };
                product.Count += product.Counts[i];

                productColorSizes.Add(productColorSize);
            }

            ferq = (productColorSizes.Count() - dbProduct.ProductColorSizes.Count()) >= 0 ?
                (productColorSizes.Count() - dbProduct.ProductColorSizes.Count()) :
                (dbProduct.ProductColorSizes.Count() - productColorSizes.Count());

            //Image set
            for (int i = 0; i < product.ColorIds.Count(); i++)
            {
                if (product.ImageFiles.Count() > 0)
                {
                    for (int f = fileCount; f < product.ImageFiles.Count(); f++)
                    {
                        if (WhichImg.Length > 0)
                        {
                            for (int w = wImg; w < WhichImg.Length; w++)
                            {
                                productColorSizes[WhichImg[w]-ferq].Image = product.ImageFiles[f].CreateFile(_env, "images", "products");
                                wImg++;
                                break;
                            }
                            fileCount++;
                            break;
                        }
                        else
                        {
                            if(dbProduct.ProductColorSizes.Count() >= productColorSizes.Count())
                            {
                                productColorSizes[dbProduct.ProductColorSizes.Count() - ferq - 1 + i].Image = product.ImageFiles[f].CreateFile(_env, "images", "products");
                                fileCount++;
                                break;
                            }
                            else
                            {
                                productColorSizes[dbProduct.ProductColorSizes.Count() + i].Image = product.ImageFiles[f].CreateFile(_env, "images", "products");
                                fileCount++;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if(dbProduct.ProductColorSizes.Any(p => p.ColorId == product.ColorIds[i] && p.SizeId == product.SizeIds[i]))
                    {
                        productColorSizes[i].Image = dbProduct.ProductColorSizes.Find(p => p.ColorId == product.ColorIds[i] && p.SizeId == product.SizeIds[i]).Image;
                    }
                    else
                    {
                        productColorSizes[i].Image = dbProduct.ProductColorSizes[i].Image;
                    }
                }
            }
            //Check double same values
            for (int i = 0; i < productColorSizes.Count(); i++)
            {
                for (int a = 1; a < productColorSizes.Count() - i; a++)
                {
                    if (productColorSizes[i].ColorId == productColorSizes[i + a].ColorId && productColorSizes[i].SizeId == productColorSizes[i + a].SizeId)
                    {
                        ModelState.AddModelError("", "2 eyni deyer olmaz");
                        return View(dbProduct);
                    }
                }
            }
            //HoverImage
            if (product.HoverImageFile != null)
            {
                if (!product.HoverImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("HoverImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!product.HoverImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("HoverImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbProduct.HoverImage, "images", "products");

                dbProduct.HoverImage = product.HoverImageFile.CreateFile(_env, "images", "products");
            }

            dbProduct.ProductColorSizes = productColorSizes;
            dbProduct.MainImage = productColorSizes[0].Image;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Name = product.Name;
            dbProduct.ExTax = product.ExTax;
            dbProduct.IsFeatured = product.IsFeatured;
            dbProduct.IsNewArrival = product.IsNewArrival;
            dbProduct.IsBestseller = product.IsBestseller;
            dbProduct.Description = product.Description;
            dbProduct.Count = product.Count;
            dbProduct.Availability = product.Count > 0 ? true : false;
            dbProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (product == null) return NotFound();
            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted);
            if (product == null) return NotFound();
            product.IsDeleted = false;
            await _context.SaveChangesAsync();


            return RedirectToAction("index", new { status, page });
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest();

            Product product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductColorSizes).ThenInclude(pc => pc.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(ps => ps.Size)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }
        public async Task<IActionResult> GetFormColoRSizeCount()
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();

            return PartialView("_ProductColorSizePartial");
        }
    }
}
