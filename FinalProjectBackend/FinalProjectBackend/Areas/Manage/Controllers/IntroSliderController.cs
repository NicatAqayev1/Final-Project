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
    public class IntroSliderController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public IntroSliderController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.IntroSliders.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IntroSlider IntroSlider)
        {
            if (!ModelState.IsValid) return View();

            if (string.IsNullOrWhiteSpace(IntroSlider.Title))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }
            if (string.IsNullOrWhiteSpace(IntroSlider.Subtitle))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (IntroSlider.Title.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }
            if (IntroSlider.Subtitle.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.IntroSliders.AnyAsync(t => t.Title.ToLower() == IntroSlider.Title.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }
            if (await _context.IntroSliders.AnyAsync(t => t.Subtitle.ToLower() == IntroSlider.Subtitle.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            if (IntroSlider.BackImageFile != null)
            {
                if (!IntroSlider.BackImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("BackImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!IntroSlider.BackImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("BackImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                IntroSlider.Image = IntroSlider.BackImageFile.CreateFile(_env, "images", "IntroSlider");
            }
            else
            {
                ModelState.AddModelError("BackImageFile", "Sekil mutleq secilmelidir");
                return View();
            };
            if (IntroSlider.SmallLogoImageFile != null)
            {
                if (!IntroSlider.SmallLogoImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("SmallLogoImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!IntroSlider.BackImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("SmallLogoImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                IntroSlider.SmallImageLogo = IntroSlider.SmallLogoImageFile.CreateFile(_env, "images", "IntroSlider");
            }
            else
            {
                ModelState.AddModelError("SmallLogoImageFile", "Sekil mutleq secilmelidir");
                return View();
            };

            IntroSlider.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.IntroSliders.AddAsync(IntroSlider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
