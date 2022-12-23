using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Order;

namespace FinalProjectBackend.Controllers
{
    [Authorize(Roles = "Member")]
    public class OrderController : Controller
    {
        private readonly WineDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(WineDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Create(  )
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin && !u.IsDeleted);

            if (appUser == null)
            {
                return RedirectToAction("login", "Account");
            }

            double total = 0;
            List<Basket> baskets = await _context.Baskets
                .Include(b => b.Product).ThenInclude(p=>p.Speciality)
                .Include(b => b.Product).ThenInclude(p=>p.ProductColorSizes)
                .Include(b => b.Color)
                .Include(b => b.Size)
                .Where(b => b.AppUserId == appUser.Id)
                .ToListAsync();

            ViewBag.Total = total;
            ViewBag.Basket = baskets;

            OrderVM orderVM = new OrderVM
            {
                FullName = appUser.FullName,
                Email = appUser.Email,
                Address = appUser.Address,
                City = appUser.City,
                Country = appUser.Country,
                State = appUser.State,
                ZipCode = appUser.ZipCode
            };

            return View(orderVM);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderVM orderVM)
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin && !u.IsDeleted);

            if (appUser == null)
            {
                return RedirectToAction("login", "Account");
            }

            List<Basket> baskets = await _context.Baskets
                .Include(b => b.Product)
                .ThenInclude(p => p.Speciality)
                .Include(b => b.Color)
                .Include(b => b.Size)
                .Where(b => b.AppUserId == appUser.Id)
                .ToListAsync();

            double total = 0;
            foreach (var item in baskets)
            {
                total += (item.Price+item.ExTax) * item.Count;
            }
            ViewBag.Total = total;
            ViewBag.Basket = baskets;

            if (!ModelState.IsValid)
            {
                return View(orderVM);
            }

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (Basket item in baskets)
            {
                total = total + (item.Count * item.Price);

                OrderItem orderItem = new OrderItem
                {
                    Count = item.Count,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    TotalPrice = item.Count * item.Price,
                    Size = item.Size.Name,
                    Color = item.Color.Name,
                    CreatedAt = DateTime.UtcNow.AddHours(4)
                };
                orderItems.Add(orderItem);
            }

            Order order = new Order
            {
                Address = orderVM.Address,
                AppUserId = appUser.Id,
                City = orderVM.City,
                Country = orderVM.Country,
                State = orderVM.State,
                TotalPrice = total,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ZipCode = orderVM.ZipCode,
                OrderItems = orderItems
            };
            List<Address> addresses = await _context.Addresses.Where(p=>p.AppUserId == appUser.Id).ToListAsync();
            if (!addresses.Any(p=>
            p.Name.Contains(orderVM.Address) && 
            p.Name.Contains(orderVM.Country) &&
            p.Name.Contains(orderVM.City) &&
            p.Name.Contains(orderVM.Appartment) &&
            p.Name.Contains(orderVM.ZipCode)
            ))
            {
                Address address = new Address()
                {
                    Name = orderVM.Address + " , " + orderVM.Appartment + " , " + orderVM.City + " , " + orderVM.Country + " " + orderVM.ZipCode,
                    AppUserId = appUser.Id
                };
                await _context.Addresses.AddAsync(address);
            }

            List<ProductColorSize> productColorSizes = await _context
                .ProductColorSizes
                .ToListAsync();
            foreach (Basket basket in baskets)
            {
                foreach (ProductColorSize product in productColorSizes)
                {
                    if(product.SizeId == basket.SizeId && product.ColorId == basket.ColorId && product.ProductId == basket.ProductId)
                    {
                        int count = 0;
                        if(product.StockCount >= basket.Count)
                        {
                            count = basket.Count;
                        }
                        else
                        {
                            count = product.StockCount;
                        }
                        product.StockCount -= count;
                    }
                }
            }

            _context.Baskets.RemoveRange(baskets);
            HttpContext.Response.Cookies.Append("basket", "");
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", "home");
        }
    }
}