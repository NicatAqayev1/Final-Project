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
    public class HomePageController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomePageController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Home Home = _context.Homes.FirstOrDefault();
            return View(Home);
        }
        public async Task<IActionResult> Change(int? id)
        {

            if (id == null) return BadRequest();

            Home Home = await _context.Homes.FirstOrDefaultAsync(p => p.Id == id);

            if (Home == null) return NotFound();

            return View(Home);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Change(int? id, Home Home, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != Home.Id) return BadRequest();

            Home dbHome = await _context.Homes.FirstOrDefaultAsync(p => p.Id == id);

            if (dbHome == null) return NotFound();

            if (!ModelState.IsValid) return View(dbHome);
            //Upgrade
            if (Home.UpgradeLatestHeader == null)
            {
                ModelState.AddModelError("UpgradeLatestHeader", "UpgradeLatestHeader is required");
                return View(Home);
            }
            if (Home.UpgradeLatestText == null)
            {
                ModelState.AddModelError("UpgradeLatestText", "UpgradeLatestText is required");
                return View(Home);
            }
            if (Home.UpgradeLatestImageFile != null)
            {
                if (!Home.UpgradeLatestImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("UpgradeLatestImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Home.UpgradeLatestImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("UpgradeLatestImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbHome.UpgradeLatestImage, "images", "MainHJome");

                dbHome.UpgradeLatestImage = Home.UpgradeLatestImageFile.CreateFile(_env, "images", "MainHJome");
            }
            if (Home.UpgradeLatestSignImageFile != null)
            {
                if (!Home.UpgradeLatestSignImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("UpgradeLatestSignImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Home.UpgradeLatestSignImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("UpgradeLatestSignImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbHome.UpgradeLatestSignImage, "images", "MainHJome");

                dbHome.UpgradeLatestSignImage = Home.UpgradeLatestSignImageFile.CreateFile(_env, "images", "MainHJome");
            }
            //Arrival
            if (Home.ArrivalHeader == null)
            {
                ModelState.AddModelError("ArrivalHeader", "ArrivalHeader is required");
                return View(Home);
            }
            if (Home.ArrivalText == null)
            {
                ModelState.AddModelError("ArrivalText", "ArrivalText is required");
                return View(Home);
            }
            if (Home.ArrivalFeatureBtnText == null)
            {
                ModelState.AddModelError("ArrivalFeatureBtnText", "ArrivalFeatureBtnText is required");
                return View(Home);
            }
            if (Home.ArrivalNewBtnText == null)
            {
                ModelState.AddModelError("ArrivalNewBtnText", "ArrivalNewBtnText is required");
                return View(Home);
            }
            if (Home.ArrivalFeatureBtnText == null)
            {
                ModelState.AddModelError("ArrivalFeatureBtnText", "ArrivalFeatureBtnText is required");
                return View(Home);
            }
            //Gallery
            if (Home.GalleryHeader == null)
            {
                ModelState.AddModelError("GalleryHeader", "GalleryHeader is required");
                return View(Home);
            }
            if (Home.GalleryText == null)
            {
                ModelState.AddModelError("OfferText", "IntroHeader is required");
                return View(Home);
            }
            //Featured
            if (Home.featuredProdsHeader == null)
            {
                ModelState.AddModelError("featuredProdsHeader", "featuredProdsHeader is required");
                return View(Home);
            }
            if (Home.featuredProdsText == null)
            {
                ModelState.AddModelError("featuredProdsText", "featuredProdsText is required");
                return View(Home);
            }
            if (Home.featuredProdsImageFile != null)
            {
                if (!Home.featuredProdsImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("featuredProdsImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Home.featuredProdsImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("featuredProdsImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbHome.featuredProdsImage, "images", "MainHJome");

                dbHome.featuredProdsImage = Home.featuredProdsImageFile.CreateFile(_env, "images", "MainHJome");
            }
            //Hurry
            if (Home.HurryHeader == null)
            {
                ModelState.AddModelError("HurryHeader", "HurryHeader is required");
                return View(Home);
            }
            if (Home.HurrySaleText == null)
            {
                ModelState.AddModelError("HurrySaleText", "HurrySaleText is required");
                return View(Home);
            }
            if (Home.HurryImageFile != null)
            {
                if (!Home.HurryImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("HurryImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Home.HurryImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("HurryImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbHome.HurryImage, "images", "MainHJome");

                dbHome.HurryImage = Home.HurryImageFile.CreateFile(_env, "images", "MainHJome");
            }
            //Special
            if (Home.SpecialHeader == null)
            {
                ModelState.AddModelError("SpecialHeader", "SpecialHeader is required");
                return View(Home);
            }
            if (Home.SpecialImageFile != null)
            {
                if (!Home.SpecialImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("SpecialImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Home.SpecialImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("SpecialImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbHome.SpecialImage, "images", "MainHJome");

                dbHome.SpecialImage = Home.SpecialImageFile.CreateFile(_env, "images", "MainHJome");
            }
            //Our clients
            if (Home.OurClientsHeader == null)
            {
                ModelState.AddModelError("OurClientsHeader", "OurClientsHeader is required");
                return View(Home);
            }
            if (Home.OurClientsText == null)
            {
                ModelState.AddModelError("OurClientsText", "OurClientsText is required");
                return View(Home);
            }

            dbHome.ArrivalBestBtnText = Home.ArrivalBestBtnText;
            dbHome.ArrivalFeatureBtnText = Home.ArrivalFeatureBtnText;
            dbHome.ArrivalNewBtnText = Home.ArrivalNewBtnText;
            dbHome.ArrivalHeader = Home.ArrivalHeader;
            dbHome.ArrivalText = Home.ArrivalText;

            dbHome.UpgradeLatestHeader = Home.UpgradeLatestHeader;
            dbHome.UpgradeLatestText = Home.UpgradeLatestText;

            dbHome.GalleryHeader = Home.GalleryHeader;
            dbHome.GalleryText = Home.GalleryText;

            dbHome.featuredProdsHeader = Home.featuredProdsHeader;
            dbHome.featuredProdsText = Home.featuredProdsText;

            dbHome.HurryHeader = Home.HurryHeader;
            dbHome.HurrySaleText = Home.HurrySaleText;

            dbHome.SpecialHeader = Home.SpecialHeader;


            dbHome.OurClientsHeader = Home.OurClientsHeader;
            dbHome.OurClientsText = Home.OurClientsText;


            dbHome.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
    }
}
