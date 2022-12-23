using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Wishlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Controllers
{
    public class WishlistController : Controller
    {
        private readonly WineDbContext _context;

        private readonly UserManager<AppUser> _userManager;
        public WishlistController(WineDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            AppUser appUser = _userManager.Users.FirstOrDefault(p => p.UserName.ToUpper() == User.Identity.Name.ToUpper() && !p.IsAdmin && !p.IsDeleted);
            ViewBag.AppUser = appUser;
            string cookieBasket = HttpContext.Request.Cookies["wishlist"];
            List<WishlistVM> wishlistVMs2 = new List<WishlistVM>();

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                List<WishlistVM> wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookieBasket);
                foreach (var item in wishlistVMs)
                {
                    if(item.AppUserId == appUser.Id)
                    {
                        wishlistVMs2.Add(item);
                    }
                }
            }

            foreach (WishlistVM basketVM in wishlistVMs2)
            {
                Product dbProduct = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = (dbProduct.MainImage == null) ? "" : dbProduct.MainImage;
                basketVM.Name = dbProduct.Name;
            }
            return View(wishlistVMs2);
        }
        public async Task<IActionResult> Delete(string AppUserid,int Prodid)
        {
            if (AppUserid == null || Prodid == null) return BadRequest();
            if (!_userManager.Users.Any(p => p.Id == AppUserid) || !_context.Products.Any(p => p.Id == Prodid)) return NotFound();

            AppUser appUser = _userManager.Users.FirstOrDefault(p => p.UserName.ToUpper() == User.Identity.Name.ToUpper() && !p.IsAdmin && !p.IsDeleted);

            Wishlist wishlist = await _context.Wishlists.FirstOrDefaultAsync(p => p.AppUserId == AppUserid && p.ProductId == Prodid);
            if (wishlist == null) return NotFound();

            ViewBag.AppUser = appUser;
            string cookieBasket = HttpContext.Request.Cookies["wishlist"];
            List<WishlistVM> wishlistVMs = null;
            List<WishlistVM> wishlistVMs2 = new List<WishlistVM>();

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                 wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(cookieBasket);

                WishlistVM RemWish = wishlistVMs.FirstOrDefault(p => p.AppUserId == AppUserid && p.ProductId == Prodid);
                if(RemWish == null)
                {
                    return NotFound();
                }
                wishlistVMs.Remove(RemWish);
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();
            }

            HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlistVMs));
            _context.Wishlists.RemoveRange(wishlist);
            await _context.SaveChangesAsync();

            return PartialView("_WishlistIndexPartial",wishlistVMs);
        }
    }
}
