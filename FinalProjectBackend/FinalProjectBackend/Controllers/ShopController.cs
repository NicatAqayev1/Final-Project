using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
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
    public class ShopController : Controller
    {
        private readonly WineDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ShopController(WineDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.PageIndex = page;
            ViewBag.Categories = await _context.Categories
                .Include(p=>p.Products)
                .Where(p=>p.ParentId == null && !p.IsDeleted)
                .ToListAsync();
            ViewBag.SubCategories = await _context.Categories
                .Include(p=>p.Products)
                .Where(p=>p.ParentId != null && !p.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(p=>!p.IsDeleted).ToListAsync();
            ViewBag.Sizes = await _context.Sizes
                .Include(p=>p.ProductColorSizes).ThenInclude(d=>d.Product)
                .Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Specialities = await _context.Specialities
                .Include(p=>p.Products)
                .Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Vendors = await _context.Vendors
                .Include(p => p.Products)
                .Where(p => !p.IsDeleted).ToListAsync();

            List<Product> products = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .Where(p=>!p.IsDeleted
                    && !p.Speciality.IsDeleted
                    && !p.Category.IsDeleted
                    && !p.Vendor.IsDeleted
                    && !p.Speciality.IsDeleted
                    && !p.Speciality.IsDeleted)
                    .ToListAsync();
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 6);
            return View(products.Skip((page - 1) * 6).Take(6));
        }
        public async Task<IActionResult> Filter(string sizes,string colors,string specs
            ,string vendors,int countby,int sortby
            ,string category,int minPrice,int maxPrice, int page = 1)
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Speciality)
                .Include(p => p.Category).ThenInclude(p=>p.Children)
                .Include(p => p.Vendor)
                .Where(p => !p.IsDeleted
                    && !p.Speciality.IsDeleted
                    && !p.Category.IsDeleted
                    && !p.Vendor.IsDeleted
                    && !p.Speciality.IsDeleted
                    && !p.Speciality.IsDeleted)
                ;
           
            if (string.IsNullOrWhiteSpace(sizes)
                && string.IsNullOrWhiteSpace(colors)
                && string.IsNullOrWhiteSpace(specs)
                && string.IsNullOrWhiteSpace(vendors)
                && string.IsNullOrWhiteSpace(countby.ToString())
                && string.IsNullOrWhiteSpace(sortby.ToString())
                && string.IsNullOrWhiteSpace(category)
                && string.IsNullOrWhiteSpace(minPrice.ToString())
                && string.IsNullOrWhiteSpace(maxPrice.ToString())
                )
            {
                return PartialView("_ShopProductsPartial", _context.Products
                    .Include(p=>p.ProductColorSizes)
                    .Where(p => !p.IsDeleted).ToList());
            }
            if (!string.IsNullOrWhiteSpace(sizes))
            {
                string[] sizs = sizes.Split(",");
                foreach (var s in sizs)
                {
                    products = products
                        .Where(p => p.ProductColorSizes.Any(p => p.SizeId.ToString() == s.ToString()));

                }
            }
            if (!string.IsNullOrWhiteSpace(colors))
            {
                string[] colrs = colors.Split(",");
                foreach (var c in colrs)
                {
                    products = products
                        .Where(p => p.ProductColorSizes.Any(p => p.ColorId.ToString() == c.ToString()));

                }
            }
            if (!string.IsNullOrWhiteSpace(specs))
            {
                string[] colrs = specs.Split(",");
                foreach (var c in colrs)
                {
                    products = products
                        .Where(p => p.Speciality.Id.ToString() == c.ToString());

                }
            }
            if (!string.IsNullOrWhiteSpace(vendors))
            {
                string[] colrs = vendors.Split(",");
                foreach (var c in colrs)
                {
                    products = products
                        .Where(p => p.Vendor.Id.ToString() == c.ToString());

                }
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                string[] colrs = category.Split(",");
                foreach (var c in colrs)
                {
                    products = products
                        .Where(p => p.Category.Id.ToString() == c.ToString());

                }
            }
            if (!string.IsNullOrWhiteSpace(countby.ToString()))
            {
                ViewBag.CountBy = countby;
                products = products.Take(countby);
            }
            if (!string.IsNullOrWhiteSpace(sortby.ToString()))
            {
                switch (sortby)
                {
                    case 1:
                        products = products.Where(p => p.IsFeatured);
                        break;
                    case 2:
                        products = products.Where(p => p.IsBestseller);
                        break;
                    case 3:
                        products = products.OrderBy(p => p.Name);
                        break;
                    case 4:
                        products = products.OrderByDescending(p => p.Name);
                        break;
                    case 5:
                        products = from p in products
                                   let produccs = p.ProductColorSizes.FirstOrDefault()
                                   orderby produccs.Price
                                   select p;
                        break;
                    case 6:
                        products = from p in products
                                   let produccs = p.ProductColorSizes.FirstOrDefault()
                                   orderby produccs.Price descending
                                   select p;
                        break;
                    case 7:
                        products = products.OrderBy(p => p.CreatedAt);
                        break;
                    case 8:
                        products = products.OrderByDescending(p => p.CreatedAt);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrWhiteSpace(minPrice.ToString()))
            {
                products = from p in products
                           let produccs = p.ProductColorSizes.FirstOrDefault()
                           where produccs.Price >= minPrice
                           select p;
            }
            if (!string.IsNullOrWhiteSpace(maxPrice.ToString()))
            {
                products = from p in products
                           let produccs = p.ProductColorSizes.FirstOrDefault()
                           where produccs.Price <= maxPrice
                           select p;
            }

            ViewBag.PageIndex = page;

            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 6);
            return PartialView("_ShopProductsPartial",products.Where(p=>!p.IsDeleted).Take(6).ToList());
        }
    }
}
