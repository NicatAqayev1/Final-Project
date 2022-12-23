using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class UserController : Controller
    {
        private readonly WineDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(WineDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ActionResult> Index(int page = 1)
        {
            List<AppUser> appUsers = await _context.AppUsers.Where(p=>!p.IsAdmin && !p.IsDeleted).ToListAsync();
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)appUsers.Count() / 5);

            return View(appUsers.Skip((page - 1) * 5).Take(5));
        }
        public async Task<ActionResult> Detail(string email)
        {
            if (email == null) return BadRequest();
            AppUser appUser = await _context.AppUsers
                .Include(p => p.Orders).ThenInclude(p => p.OrderItems).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(a => a.Email.ToLower() == email);
            if (appUser == null) return NotFound();
            return View(appUser);
        }
        public async Task<ActionResult> Delete(string email,int page = 1)
        {
            if (email == null) return BadRequest();
            AppUser appUser = await _context.AppUsers
                .Include(p => p.Orders).ThenInclude(p => p.OrderItems).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(a => a.Email.ToLower() == email);
            if (appUser == null) return NotFound();

            List<AppUser> appUsers = await _context.AppUsers.ToListAsync();
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)appUsers.Count() / 5);

            appUser.IsDeleted = true;
            await _context.SaveChangesAsync();
            return View("index", appUsers.Skip((page - 1) * 5).Take(5));
        }
        public async Task<ActionResult> Restore(string email,int page = 1)
        {
            if (email == null) return BadRequest();
            AppUser appUser = await _context.AppUsers
                .Include(p => p.Orders).ThenInclude(p => p.OrderItems).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(a => a.Email.ToLower() == email);
            if (appUser == null) return NotFound();
            List<AppUser> appUsers = await _context.AppUsers.ToListAsync();
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)appUsers.Count() / 5);

            appUser.IsDeleted = false;
            await _context.SaveChangesAsync();
            return View("index", appUsers.Skip((page - 1) * 5).Take(5));
        }

    }
}
