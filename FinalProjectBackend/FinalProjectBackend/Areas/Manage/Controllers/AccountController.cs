using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.DAL;
using FinalProjectBackend.Models;
using FinalProjectBackend.ViewModels.Account;
using FinalProjectBackend.ViewModels.Basket;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.IO;

namespace FinalProjectBackend.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly WineDbContext _context;
        private readonly IConfiguration _config;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, WineDbContext context, IConfiguration config)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _config = config;
        }

        public IActionResult Index()
        {
            return RedirectToAction("login");
        }
        public IActionResult Login()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("index", "home");
            //}


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == loginVM.Email.ToUpper());
           
            if (appUser == null)
            {
                ModelState.AddModelError("Email", "Couldn't find this email.Try again");
                return View();
            }
            if (!appUser.IsAdmin)
            {
                ModelState.AddModelError("", "You are not Admin.");
                return View();
            }
            if (appUser.IsDeleted)
            {
                ModelState.AddModelError("", "Your account was blocked");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("Password", "Email Or Password Is InCorrect");
                return View();
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabiniz Blocklanib");
                return View();
            }

            return RedirectToAction("index", "Dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name.ToUpper());
            await _context.SaveChangesAsync();


            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Dashboard");
        }
    }
}
