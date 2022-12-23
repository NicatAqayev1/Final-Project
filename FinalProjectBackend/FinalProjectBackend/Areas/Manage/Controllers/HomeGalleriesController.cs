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
    public class HomeGalleriesController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeGalleriesController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeGalleries
                .Include(p=>p.Category)
                .ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeGallery HomeGalleries)
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View();

            if (!await _context.Categories.AnyAsync(b => b.Id == HomeGalleries.CategoryId && !b.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Duzgun Category Secin ");
                return View();
            }

            if (string.IsNullOrWhiteSpace(HomeGalleries.Title))
            {
                ModelState.AddModelError("Title", "Bosluq Olmamalidir");
                return View();
            }

            if (await _context.HomeGalleries.AnyAsync(t => t.Title.ToLower().Trim() == HomeGalleries.Title.ToLower().Trim()))
            {
                ModelState.AddModelError("Title", "Alreade Exists");
                return View();
            }
            if (HomeGalleries.ImageFile != null)
            {
                if (!HomeGalleries.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!HomeGalleries.ImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("ImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                HomeGalleries.Image = HomeGalleries.ImageFile.CreateFile(_env, "images", "HomeGalleries");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Sekil mutleq secilmelidir");
                return View();
            };

            HomeGalleries.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.HomeGalleries.AddAsync(HomeGalleries);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
