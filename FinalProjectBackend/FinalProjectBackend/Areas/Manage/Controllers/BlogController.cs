using FinalProjectBackend.DAL;
using FinalProjectBackend.Extensions;
using FinalProjectBackend.Helpers;
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
    public class BlogController : Controller
    {
        private readonly WineDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(WineDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;
            IEnumerable<Blog> Blogs = new List<Blog>();

            if (status != null)
            {
                Blogs = await _context.Blogs
                    .Include(p => p.BlogTags).ThenInclude(pt => pt.Tag)
                    .Where(t => t.IsDeleted == status)
                    .ToListAsync();
            }
            else
            {
                Blogs = await _context.Blogs
                   .Include(p => p.BlogTags).ThenInclude(pt => pt.Tag)
                   .ToListAsync();
            }

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)Blogs.Count() / 5);
            return View(Blogs.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog Blog)
        {
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View();


            if (string.IsNullOrWhiteSpace(Blog.Title))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (Blog.Title.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Blogs.AnyAsync(t => t.Title.ToLower().Trim() == Blog.Title.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            //Main image select
            if (Blog.ImageFile != null)
            {
                if (!Blog.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "Sonu .jpeg olan fayl daxil edin");
                    return View();
                }
                if (!Blog.ImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("ImageFile", "Seklin olcusu 30 Kb-den cox olmamalidir");
                    return View();
                }
                Blog.Image = Blog.ImageFile.CreateFile(_env, "images", "blogs");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Sekil mutleq secilmelidir");
                return View();
            }
            if (Blog.TagIds.Count > 0)
            {
                List<BlogTag> BlogTags = new List<BlogTag>();

                foreach (int item in Blog.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(s => s.Id == item))
                    {
                        ModelState.AddModelError("TagIds", $"Secilen Id {item} - li Tag Yanlisdir");
                        return View();
                    }
                    if (!await _context.Tags.AnyAsync(t => t.Id == item && !t.IsDeleted))
                    {
                        ModelState.AddModelError("TagIds", $"Secilen Id {item} - li Tag Yanlisdir");
                        return View();
                    }

                    BlogTag BlogTag = new BlogTag
                    {
                        TagId = item
                    };

                    BlogTags.Add(BlogTag);
                }

                Blog.BlogTags = BlogTags;
            }

            Blog.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Blogs.AddAsync(Blog);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            if (id == null) return BadRequest();

            Blog Blog = await _context.Blogs
                .Include(p => p.BlogTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (Blog == null) return NotFound();

            Blog.TagIds = Blog.BlogTags.Select(pt => pt.Tag.Id).ToList();

            return View(Blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog Blog, bool? status, int page = 1)
        {
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            if (id == null) return BadRequest();

            if (id != Blog.Id) return BadRequest();

            Blog dbBlog = await _context.Blogs
                 .Include(p => p.BlogTags).ThenInclude(pt => pt.Tag)
                 .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (dbBlog == null) return NotFound();

            if (!ModelState.IsValid) return View(dbBlog);

            if (Blog.TagIds.Count > 0)
            {
                _context.BlogTags.RemoveRange(dbBlog.BlogTags);

                List<BlogTag> BlogTags = new List<BlogTag>();

                foreach (int item in Blog.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(t => t.Id == item && !t.IsDeleted))
                    {
                        ModelState.AddModelError("TagIds", $"Secilen Id {item} - li Tag Yanlisdir");
                        return View(Blog);
                    }

                    BlogTag BlogTag = new BlogTag
                    {
                        TagId = item
                    };

                    BlogTags.Add(BlogTag);
                }

                dbBlog.BlogTags = BlogTags;
            }
            else
            {
                _context.BlogTags.RemoveRange(dbBlog.BlogTags);
            }

            if (Blog.ImageFile != null)
            {
                if (!Blog.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "Secilen Seklin Novu Uygun");
                    return View();
                }

                if (!Blog.ImageFile.CheckFileSize(1000))
                {
                    ModelState.AddModelError("ImageFile", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                    return View();
                }
                Helper.DeleteFile(_env, dbBlog.Image, "images", "blogs");

                dbBlog.Image = Blog.ImageFile.CreateFile(_env, "images", "blogs");
            }


            dbBlog.Title = Blog.Title;
            dbBlog.Description = Blog.Description;
            dbBlog.Publisher = Blog.Publisher;
            dbBlog.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();
            Blog Blog = await _context.Blogs.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (Blog == null) return NotFound();
            Blog.IsDeleted = true;
            Blog.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();
            Blog Blog = await _context.Blogs.FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted);
            if (Blog == null) return NotFound();
            Blog.IsDeleted = false;
            await _context.SaveChangesAsync();


            return RedirectToAction("index", new { status, page });
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest();

            Blog Blog = _context.Blogs
                .Include(p => p.BlogTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefault(p => p.Id == id);

            if (Blog == null) return NotFound();

            return View(Blog);
        }
    }
}
