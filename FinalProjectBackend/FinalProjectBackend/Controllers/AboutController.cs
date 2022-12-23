using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Controllers
{
    public class AboutController : Controller
    {
        private readonly WineDbContext _context;
        public AboutController(WineDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            About about = _context.Abouts.FirstOrDefault();
            ViewBag.Products = _context.Products.Where(p => !p.IsDeleted).ToList().Count();
            ViewBag.Blogs = _context.Blogs.Where(p => !p.IsDeleted).ToList().Count();
            ViewBag.Users = _context.AppUsers.Where(p => !p.IsDeleted).ToList().Count();
            ViewBag.Reviews = _context.Reviews.Where(p => !p.IsDeleted).ToList().Count();
            return View(about);
        }
    }
}
