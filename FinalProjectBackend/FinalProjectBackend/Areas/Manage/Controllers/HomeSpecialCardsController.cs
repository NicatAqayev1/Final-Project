using FinalProjectBackend.DAL;
using FinalProjectBackend.Extensions;
using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class HomeSpecialCardsController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeSpecialCardsController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeSpecialCards.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeSpecialCards HomeSpecialCards)
        {
            if (!ModelState.IsValid) return View();

            if (string.IsNullOrWhiteSpace(HomeSpecialCards.CardName))
            {
                ModelState.AddModelError("CardName", "Bosluq Olmamalidir");
                return View();
            }
            if (string.IsNullOrWhiteSpace(HomeSpecialCards.CardText))
            {
                ModelState.AddModelError("CardText", "Bosluq Olmamalidir");
                return View();
            }

            if (await _context.HomeSpecialCards.AnyAsync(t => t.CardName.ToLower().Trim() == HomeSpecialCards.CardName.ToLower().Trim()))
            {
                ModelState.AddModelError("CardName", "Alreade Exists");
                return View();
            }
            if (await _context.HomeSpecialCards.AnyAsync(t => t.CardText.ToLower().Trim() == HomeSpecialCards.CardText.ToLower().Trim()))
            {
                ModelState.AddModelError("CardText", "Alreade Exists");
                return View();
            }

            if (HomeSpecialCards.CardImageFile != null)
            {
                if (!HomeSpecialCards.CardImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("CardImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!HomeSpecialCards.CardImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("CardImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                HomeSpecialCards.CardImage = HomeSpecialCards.CardImageFile.CreateFile(_env, "images", "HomeSpecialCards");
            }
            else
            {
                ModelState.AddModelError("CardImageFile", "Sekil mutleq secilmelidir");
                return View();
            };

            HomeSpecialCards.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.HomeSpecialCards.AddAsync(HomeSpecialCards);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
