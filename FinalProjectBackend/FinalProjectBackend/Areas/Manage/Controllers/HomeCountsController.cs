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
    public class HomeCountsController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeCountsController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeCounts.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeCounts HomeCounts)
        {

            if (!ModelState.IsValid) return View();

            if (string.IsNullOrWhiteSpace(HomeCounts.CountsText))
            {
                ModelState.AddModelError("CountsText", "Bosluq Olmamalidir");
                return View();
            }

            if (await _context.HomeCounts.AnyAsync(t => t.CountsText.ToLower().Trim() == HomeCounts.CountsText.ToLower().Trim()))
            {
                ModelState.AddModelError("CountsText", "Alreade Exists");
                return View();
            }
            if (HomeCounts.CountsImageFile != null)
            {
                if (!HomeCounts.CountsImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("CountsImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!HomeCounts.CountsImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("CountsImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                HomeCounts.CountsImage = HomeCounts.CountsImageFile.CreateFile(_env, "images", "HomeCounts");
            }
            else
            {
                ModelState.AddModelError("CountsImageFile", "Sekil mutleq secilmelidir");
                return View();
            };

            HomeCounts.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.HomeCounts.AddAsync(HomeCounts);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
