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
    public class VendorController : Controller
    {
        private readonly WineDbContext _context;

        public VendorController(WineDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {

            ViewBag.Status = status;
            IEnumerable<Vendor> Vendors = new List<Vendor>();

            if (status != null)
            {
                Vendors = await _context.Vendors
                    .Where(t => t.IsDeleted == status)
                    .ToListAsync();
            }
            else
            {
                Vendors = await _context.Vendors
                   .ToListAsync();
            }
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)Vendors.Count() / 5);

            return View(Vendors.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Vendor dbVendor = await _context.Vendors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbVendor == null) return NotFound();
            return View(dbVendor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Vendor Vendor)
        {
            if (!ModelState.IsValid) return View();

            if (id == null) return BadRequest();

            if (id != Vendor.Id) return NotFound();

            Vendor dbVendor = await _context.Vendors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbVendor == null) return NotFound();

            if (string.IsNullOrWhiteSpace(Vendor.Name.Trim()))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Vendor.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Vendors.AnyAsync(t => t.Name.ToLower().Trim() == Vendor.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            dbVendor.Name = Vendor.Name;
            dbVendor.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendor Vendor)
        {
            if (!ModelState.IsValid) return View();
            if (string.IsNullOrWhiteSpace(Vendor.Name.Trim()))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Vendor.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Vendors.AnyAsync(t => t.Name.ToLower().Trim() == Vendor.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }
            Vendor.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Vendors.AddAsync(Vendor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            Vendor Vendor = await _context.Vendors.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
            if (Vendor == null) return NotFound();
            Vendor.IsDeleted = true;
            Vendor.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return BadRequest();
            Vendor Vendor = await _context.Vendors.FirstOrDefaultAsync(t => t.Id == id && t.IsDeleted);
            if (Vendor == null) return NotFound();
            Vendor.IsDeleted = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
