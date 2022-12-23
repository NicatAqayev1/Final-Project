using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.DAL;
using FinalProjectBackend.Extensions;
using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SpecialityController : Controller
    {
        private readonly WineDbContext _context;

        public SpecialityController(WineDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {

            ViewBag.Status = status;
            IEnumerable<Speciality> Specialities = new List<Speciality>();

            if (status != null)
            {
                Specialities = await _context.Specialities
                    .Where(t => t.IsDeleted == status)
                    .ToListAsync();
            }
            else
            {
                Specialities = await _context.Specialities
                   .ToListAsync();
            }
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)Specialities.Count() / 5);

            return View(Specialities.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Speciality dbSpeciality = await _context.Specialities.FirstOrDefaultAsync(t => t.Id == id);

            if (dbSpeciality == null) return NotFound();
            return View(dbSpeciality);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Speciality Speciality)
        {
            if (!ModelState.IsValid) return View();

            if (id == null) return BadRequest();

            if (id != Speciality.Id) return NotFound();

            Speciality dbSpeciality = await _context.Specialities.FirstOrDefaultAsync(t => t.Id == id);

            if (dbSpeciality == null) return NotFound();

            if (string.IsNullOrWhiteSpace(Speciality.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Speciality.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Specialities.AnyAsync(t => t.Name.ToLower() == Speciality.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            dbSpeciality.Name = Speciality.Name;
            dbSpeciality.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Speciality Speciality)
        {
            if (!ModelState.IsValid) return View();
            if (string.IsNullOrWhiteSpace(Speciality.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Speciality.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Specialities.AnyAsync(t => t.Name.ToLower() == Speciality.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }
            Speciality.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Specialities.AddAsync(Speciality);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            Speciality Speciality = await _context.Specialities.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
            if (Speciality == null) return NotFound();
            Speciality.IsDeleted = true;
            Speciality.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return BadRequest();
            Speciality Speciality = await _context.Specialities.FirstOrDefaultAsync(t => t.Id == id && t.IsDeleted);
            if (Speciality == null) return NotFound();
            Speciality.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
