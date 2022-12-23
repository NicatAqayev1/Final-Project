using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FinalProjectBackend.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly WineDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(IHttpContextAccessor httpContextAccessor, WineDbContext context,UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<BasketVM>> GetBasket()
        {
            string cookieBasket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products
                    .Include(p=>p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                //basketVM.Image = (dbProduct.MainImage == null )? "": dbProduct.MainImage;
                basketVM.Name = dbProduct.Name;
                if(dbProduct.ProductColorSizes.Any(p =>p.ProductId == basketVM.ProductId && p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId))
                {
                    basketVM.StockCount = dbProduct.ProductColorSizes.Find(p => p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId).StockCount;
                }
                else
                {
                    basketVM.StockCount = 0;
                }
            }

            return basketVMs;
        }

        public async Task<Setting> GetSetting()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }
      
        public async Task<List<Wishlist>> GetWishlist()
        {
            List<Wishlist> wishlists = await _context.Wishlists
                .Include(w => w.Product).ThenInclude(p => p.ProductColorSizes)
                .ToListAsync();

            return wishlists;
        }
        public async Task<List<Product>> OurWines()
        {
            return await _context.Products.Include(p=>p.ProductColorSizes).Where(p => !p.IsDeleted).OrderBy(p => p.CreatedAt).Take(4).ToListAsync();
        }
    }
}
