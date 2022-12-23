using FinalProjectBackend.DAL;
using FinalProjectBackend.Helpers;
using FinalProjectBackend.Extensions;
using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class AboutController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            About about = _context.Abouts.FirstOrDefault();
            return View(about);
        }
        public async Task<IActionResult> Change(int? id)
        {

            if (id == null) return BadRequest();

            About About = await _context.Abouts.FirstOrDefaultAsync(p => p.Id == id);

            if (About == null) return NotFound();

            return View(About);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Change(int? id, About About, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != About.Id) return BadRequest();

            About dbAbout = await _context.Abouts.FirstOrDefaultAsync(p => p.Id == id);

            if (dbAbout == null) return NotFound();

            if (!ModelState.IsValid) return View(dbAbout);

            if (About.IntroHeader == null)
            {
                ModelState.AddModelError("IntroHeader", "IntroHeader is required");
                return View(About);
            }
            if (About.IntroText == null)
            {
                ModelState.AddModelError("IntroText", "IntroHeader is required");
                return View(About);
            }
            if (About.AboutWineHeader == null)
            {
                ModelState.AddModelError("AboutWineHeader", "IntroHeader is required");
                return View(About);
            }
            if (About.AboutWineText == null)
            {
                ModelState.AddModelError("AboutWineText", "IntroHeader is required");
                return View(About);
            }
            if (About.OfferHeader == null)
            {
                ModelState.AddModelError("OfferHeader", "IntroHeader is required");
                return View(About);
            }
            if (About.OfferText == null)
            {
                ModelState.AddModelError("OfferText", "IntroHeader is required");
                return View(About);
            }

            if (About.IntroImageFile != null)
            {
                if (!About.IntroImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("IntroImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!About.IntroImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("IntroImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbAbout.IntroImage, "images", "AboutPage");

                dbAbout.IntroImage = About.IntroImageFile.CreateFile(_env, "images", "AboutPage");
            }
           
            if (About.OfferImageFile != null)
            {
                if (!About.OfferImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("OfferImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!About.OfferImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("OfferImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbAbout.OfferImage, "images", "AboutPage");

                dbAbout.OfferImage = About.OfferImageFile.CreateFile(_env, "images", "AboutPage");
            }

            if (About.AboutWineImageFile != null)
            {
                if (!About.AboutWineImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("AboutWineImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!About.AboutWineImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("AboutWineImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbAbout.AboutWineImage, "images", "AboutPage");

                dbAbout.AboutWineImage = About.AboutWineImageFile.CreateFile(_env, "images", "AboutPage");
            }

            dbAbout.AboutWineHeader = About.AboutWineHeader;
            dbAbout.AboutWineText = About.AboutWineText;
            dbAbout.IntroHeader = About.IntroHeader;
            dbAbout.IntroText = About.IntroText;
            dbAbout.OfferHeader = About.OfferHeader;
            dbAbout.OfferText = About.OfferText;

            dbAbout.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
    }
}
