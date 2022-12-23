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
    public class HomeOurClientsSlidersController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeOurClientsSlidersController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeOurClientsSliders.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeOurClientsSlider HomeOurClientsSliders)
        {
            if (!ModelState.IsValid) return View();

            if (HomeOurClientsSliders.ImageFile != null)
            {
                if (!HomeOurClientsSliders.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!HomeOurClientsSliders.ImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("ImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                HomeOurClientsSliders.Image = HomeOurClientsSliders.ImageFile.CreateFile(_env, "images", "HomeOurClientsSliders");
            }
            else
            {
                ModelState.AddModelError("CardImageFile", "Sekil mutleq secilmelidir");
                return View();
            };

            HomeOurClientsSliders.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.HomeOurClientsSliders.AddAsync(HomeOurClientsSliders);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
