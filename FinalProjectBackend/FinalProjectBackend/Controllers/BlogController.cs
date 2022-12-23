using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Controllers
{
    public class BlogController : Controller
    {
        private readonly WineDbContext _context;

        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public BlogController(WineDbContext context, UserManager<AppUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.Products = await _context.Products
                .Include(p=>p.ProductColorSizes)
                .Where(p => !p.IsDeleted).OrderByDescending(p => p.CreatedAt).Take(4).ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags
                .Include(p=>p.BlogTags)
                .ToListAsync();
            ViewBag.Blogs = await _context.Blogs.OrderByDescending(p => p.CreatedAt).Take(5).ToListAsync();
            IEnumerable<Blog> blogs = blogs = await _context.Blogs
                   .OrderByDescending(c => c.CreatedAt)
                   .Include(b => b.BlogTags).ThenInclude(b => b.Tag)
                    .Where(p => !p.IsDeleted)
                   .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)blogs.Count() / 6);
            return View(blogs.Skip((page - 1) * 6).Take(6));
        }
        public async Task<IActionResult> Detail(int? bid)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            ViewBag.Blogs = await _context.Blogs.OrderByDescending(b => b.CreatedAt).Take(4).ToListAsync();

            if (bid == null) return BadRequest();
            Blog blog = await _context.Blogs
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(p => p.Id == (int)bid && !p.IsDeleted);
            if (blog == null) return NotFound();

            BlogVM blogVM = new BlogVM()
            {
                Blog = blog,
                Blogs = await _context.Blogs.Where(p=>!p.IsDeleted).ToListAsync(),
                Reviews = await _context.Reviews.Where(p=>p.BlogId == blog.Id && !p.IsDeleted).OrderByDescending(r=>r.CreatedAt).ToListAsync()
            };

            return View(blogVM);
        }
        public async Task<IActionResult> AddReview(string Message, int? bid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return PartialView("_LoginPartial");
            }
            if (bid == null) return View();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == bid && !b.IsDeleted);
            if (blog == null) return NotFound();
            Review review = new Review();
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);
            review.Email = appUser.Email;
            review.Name = appUser.UserName;
            BlogVM blogVM = new BlogVM()
            {
                Blog = blog,
                Blogs = await _context.Blogs.Where(p=>!p.IsDeleted).ToListAsync(),
                Reviews = await _context.Reviews
               .Where(p => p.BlogId == blog.Id && !p.IsDeleted)
               .OrderByDescending(r => r.CreatedAt)
               .ToListAsync()
            };
            if (Message == null || Message == "" || Message.Trim() == null || Message.Trim() == "")
            {
                return PartialView("_AddReviewPartial", blogVM);
            }

            review.Message = Message.Trim();
            if (review.Star == null || review.Star < 0 || review.Star > 5)
            {
                review.Star = 1;
            }
            review.BlogId = (int)bid;
            review.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            blogVM = new BlogVM()
            {
                Blog = blog,
                Blogs = await _context.Blogs.ToListAsync(),
                Reviews = await _context.Reviews
                .Where(p => p.BlogId == blog.Id && !p.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync()
            };
            return PartialView("_AddReviewPartial", blogVM);
        }
        public async Task<IActionResult> Edit(string Message,int? id)
        {
            if (id == null) return BadRequest();
            Review dbReview = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (dbReview == null) return NotFound();

            if(Message != null && Message.Trim() != null && Message.Trim() != "")
            {
                dbReview.Message = Message.Trim();
            }
            dbReview.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            BlogVM blogVM = new BlogVM()
            {
                Blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == dbReview.BlogId && !b.IsDeleted),
                Blogs = await _context.Blogs.ToListAsync(),
                Reviews = await _context.Reviews
                .Where(p => p.BlogId == dbReview.BlogId && !p.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync()
            };
            return PartialView("_AddReviewPartial", blogVM);
        }
        public async Task<IActionResult> EditComment(int? id)
        {
            if (id == null) return BadRequest();
            Review dbReview = await _context.Reviews
                .Include(r => r.Blog)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (dbReview == null) return NotFound();

            return PartialView("_ReviewEditPartial", dbReview);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Review review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (review == null) return NotFound();
            review.IsDeleted = true;
            review.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            BlogVM blogVM = new BlogVM()
            {
                Blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == review.BlogId && !b.IsDeleted),
                Blogs = await _context.Blogs.ToListAsync(),
                Reviews = await _context.Reviews
                .Where(p => p.BlogId == review.BlogId && !p.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync()
            };
            return PartialView("_AddReviewPartial", blogVM);
        }
        public async Task<IActionResult> CommentCount(int? id)
        {
            if (id == null) BadRequest();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);
            if (blog == null) return NotFound();
            IEnumerable<Review> reviews = await _context.Reviews.Where(r=>!r.IsDeleted && r.BlogId == blog.Id).ToListAsync();
            return Content($"{reviews.Count()}");
        }
        public async Task<IActionResult> toTag( string tag,int page = 1)
        {
            ViewBag.Products = await _context.Products
                .Include(p => p.ProductColorSizes)
                .Where(p => !p.IsDeleted).OrderByDescending(p => p.CreatedAt).Take(4).ToListAsync();
            ViewBag.PageIndex = page;
            List<Blog> blogs = new List<Blog>();
            if (string.IsNullOrWhiteSpace(tag))
            {
                ViewBag.PageIndex = page;
                blogs = await _context.Blogs
                    .Include(p=>p.BlogTags).ThenInclude(a => a.Tag)
                    .Where(b => !b.IsDeleted).ToListAsync();
                ViewBag.PageCount = Math.Ceiling((double)blogs.Count() / 6);
                return PartialView("_BlogListPartial", blogs.Skip((page - 1) * 6).Take(6));
            }

            IQueryable<Tag> dbtag =  _context.Tags;
                string[] sizs = tag.Split(",");
                foreach (var s in sizs)
                {
                    dbtag = dbtag
                        .Where(t => !t.IsDeleted && t.Id.ToString() == s);
                };
            blogs = await _context.Blogs
                .Include(p => p.BlogTags)
                .ThenInclude(p => p.Tag)
                .Where(p=>p.BlogTags.Any(p=>sizs.Any(a=>a == p.TagId.ToString())) && !p.IsDeleted)
                .ToListAsync();

            if (dbtag == null || blogs == null)
            {
                blogs = await _context.Blogs
                    .Include(p=>p.BlogTags).ThenInclude(a=>a.Tag)
                    .Where(b => !b.IsDeleted).ToListAsync();
            }
            ViewBag.PageCount = Math.Ceiling((double)blogs.Count() / 6);

            return PartialView("_BlogListPartial", blogs.Skip((page - 1) * 6).Take(6));
        }
    }
}
