using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.DAL;
using FinalProjectBackend.Extensions;
using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using FinalProjectBackend.Helpers;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            IEnumerable<Category> categories = await _context.Categories
                .Include(p => p.Products)
                .ToListAsync();
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return View(categories.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories
                .Include(p=>p.Parent)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category Category)
        {
            if (!ModelState.IsValid) return View();

            if (id == null) return BadRequest();

            if (id != Category.Id) return NotFound();

            Category dbCategory = await _context.Categories
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (dbCategory == null) return NotFound();
            if (string.IsNullOrWhiteSpace(Category.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Category.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Categories.AnyAsync(t => t.Name.ToLower() == Category.Name.ToLower() && t.Id != Category.Id))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }
            if (Category.CategoryImage != null)
            {
                if(Category.ParentId != null)
                {
                    ModelState.AddModelError("CategoryImage", "You can only assign image to the main category");
                    return View();
                }
                if (!Category.CategoryImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("CategoryImage", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Category.CategoryImage.CheckFileSize(300))
                {
                    ModelState.AddModelError("CategoryImage", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbCategory.Image, "images", "categories");

                dbCategory.Image = Category.CategoryImage.CreateFile(_env, "images", "categories");
            }
            dbCategory.Name = Category.Name;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.IsMain && !c.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category Category)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.IsMain && !c.IsDeleted).ToListAsync();
            if (!ModelState.IsValid) return View();

            if (string.IsNullOrWhiteSpace(Category.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Category.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Categories.AnyAsync(t => t.Name.ToLower() == Category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            if (Category.IsMain)
            {
                Category.ParentId = null;

                if (Category.CategoryImage == null)
                {
                    ModelState.AddModelError("CategoryImage", "Sekil Mutleq Olmalidi");
                    return View();
                }

                if (!Category.CategoryImage.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("CategoryImage", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Category.CategoryImage.CheckFileSize(100))
                {
                    ModelState.AddModelError("CategoryImage", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View();
                }

                Category.Image = Category.CategoryImage.CreateFile(_env, "images");
            }
            else
            {
                if (Category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Parent Mutleq Secilmelidir");
                    return View();
                }

                if (!await _context.Categories.AnyAsync(c => c.Id == Category.ParentId && !c.IsDeleted && c.IsMain))
                {
                    ModelState.AddModelError("ParentId", "Parent Id yanlisdir");
                    return View();
                }
                Category.Image =  _context.Categories.FirstOrDefault(c => c.Id == Category.ParentId).Image;
            }
            Category.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Categories.AddAsync(Category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            Category Category = await _context.Categories.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
            if (Category == null) return NotFound();
            Category.IsDeleted = true;
            Category.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return BadRequest();
            Category Category = await _context.Categories.FirstOrDefaultAsync(t => t.Id == id && t.IsDeleted);
            if (Category == null) return NotFound();
            Category.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
