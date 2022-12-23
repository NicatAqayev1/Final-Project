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

namespace FinalProjectBackend.Controllers
{
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = new AppUser
            {
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                IsAdmin = false
            };
            if(registerVM.Password != registerVM.ConfirmPassword)
            {
                ModelState.AddModelError("", "Password and ConfirmPassword must be equal");
                return View();
            }
            string token = Guid.NewGuid().ToString();
            appUser.EmailConfirmationToken = token;
            string passwordResetToken = Guid.NewGuid().ToString();
            appUser.PasswordResetToken = passwordResetToken;
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            string coockieBasket = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(coockieBasket))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(coockieBasket);

                List<Basket> baskets = new List<Basket>();
                List<Basket> existedBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (existedBasket.Any(b => b.ProductId == basketVM.ProductId))
                    {
                        existedBasket.Find(b => b.ProductId == basketVM.ProductId).Count = basketVM.Count;
                    }
                    else
                    {
                        Basket basket = new Basket
                        {
                            AppUserId = appUser.Id,
                            ProductId = basketVM.ProductId,
                            Count = basketVM.Count,
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };

                        baskets.Add(basket);
                    }


                }

                if (baskets.Count > 0)
                {
                    await _context.Baskets.AddRangeAsync(baskets);
                    await _context.SaveChangesAsync();
                }
            }

            await _userManager.AddToRoleAsync(appUser, "Member");
            var link = Url.Action(nameof(VerifyEmail), "Account", new { id = appUser.Id, token }, Request.Scheme, Request.Host.ToString());
            EmailVM email = _config.GetSection("Email").Get<EmailVM>();
            string body = string.Empty;

            using (StreamReader stream = new StreamReader($"wwwroot/templates/RegisterVerify.html"))
            {
                body = stream.ReadToEnd();
            }

            body = body.Replace("{link}", link);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email.SenderEmail, email.SenderName);
            mail.To.Add(appUser.Email);
            mail.Subject = "Verify Email";
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = email.Server;
            smtp.Port = email.Port;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
            smtp.Send(mail);

            //await _signInManager.SignInAsync(appUser, true);
            //return RedirectToAction("index", "home");

            return RedirectToAction(nameof(EmailVerification));
        }
        public IActionResult EmailVerification() => View();
        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (user.EmailConfirmationToken != token) return BadRequest();
            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);
            if (result.Succeeded)
            {
                string newToken = Guid.NewGuid().ToString();
                user.EmailConfirmationToken = newToken;
                await _userManager.UpdateAsync(user);
                return View();
            }

            return BadRequest();
        }
        public IActionResult ResetPassword() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM reset)
        {
            if (string.IsNullOrWhiteSpace(reset.Email))
            {
                ModelState.AddModelError(string.Empty, "Please bosh qoyma!");
                return View();
            }
            AppUser user = await _userManager.FindByEmailAsync(reset.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Get birinci qeydiyyatdan kec!");
                return View();
            }
            var body = string.Empty;
            var link = Url.Action(nameof(NewPassword), "Account", new { id = user.Id, token = user.PasswordResetToken }, Request.Scheme, Request.Host.ToString());
            using (StreamReader stream = new StreamReader($"wwwroot/templates/ResetPassword.html"))
            {
                body = stream.ReadToEnd();
            }

            body = body.Replace("{link}", link);

            EmailVM email = _config.GetSection("Email").Get<EmailVM>();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email.SenderEmail, email.SenderName);
            mail.To.Add(reset.Email);
            mail.Subject = "Reset Password";
            mail.Body = body;
            mail.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = email.Server;
                smtp.Port = email.Port;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
                smtp.Send(mail);
            }
            return RedirectToAction(nameof(EmailVerification));
        }
        public IActionResult NewPassword(ResetPasswordVM reset)
        {
            return View(reset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("NewPassword")]
        public async Task<IActionResult> NewPasswordPost(ResetPasswordVM reset)
        {
            if (reset.Id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(reset.Id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.PasswordResetToken != reset.Token)
            {
                return BadRequest();
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, reset.Password);
            if (result.Succeeded)
            {
                string passwordResetToken = Guid.NewGuid().ToString();
                user.PasswordResetToken = passwordResetToken;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return BadRequest();
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
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
            string coockieBasket = HttpContext.Request.Cookies["basket"];
            switch (loginVM.Basket.ToLower().Trim())
            {
                case "fix":
                    if (!string.IsNullOrWhiteSpace(coockieBasket))
                    {
                        List<BasketVM> BasketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(coockieBasket);

                        List<Basket> baskets = new List<Basket>();
                        List<Basket> existedBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();
                        for (int i = 0; i < BasketVMs.Count(); i++)
                        {
                            if (existedBasket.Any(b => b.ProductId == BasketVMs[i].ProductId && b.SizeId == BasketVMs[i].SizeId && b.ColorId == BasketVMs[i].ColorId))
                            {
                                existedBasket.Find(b => b.ProductId == BasketVMs[i].ProductId && b.SizeId == BasketVMs[i].SizeId && b.ColorId == BasketVMs[i].ColorId).Count += BasketVMs[i].Count;
                                //await _context.SaveChangesAsync();
                            }
                            else
                            {
                                Basket basket = new Basket
                                {
                                    AppUserId = appUser.Id,
                                    ProductId = BasketVMs[i].ProductId,
                                    Count = BasketVMs[i].Count,
                                    ColorId = BasketVMs[i].ColorId,
                                    SizeId = BasketVMs[i].SizeId,
                                    Price = BasketVMs[i].Price,
                                    CreatedAt = DateTime.UtcNow.AddHours(4)
                                };
                                baskets.Add(basket);
                            }

                        }
                        if (baskets.Count > 0)
                        {
                            await _context.Baskets.AddRangeAsync(baskets);
                        }
                        await _context.SaveChangesAsync();
                    }
                    List<BasketVM> vMs = new List<BasketVM>();
                    List<Basket> exist = _context.Baskets.Where(p => p.AppUserId == appUser.Id).ToList();
                    foreach (Basket item in exist)
                    {
                        ProductColorSize pcs = _context.ProductColorSizes
                            .Include(p=>p.Color)
                            .Include(p=>p.Size)
                            .Include(p=>p.Product)
                            .FirstOrDefault(p => p.ProductId == item.ProductId && p.ColorId == item.ColorId && p.SizeId == item.SizeId);
                        BasketVM bas = new BasketVM()
                        {
                            Image = pcs.Image,
                            ProductId = item.ProductId,
                            ColorId = item.ColorId,
                            ColorName = pcs.Color.Name,
                            SizeName = pcs.Size.Name,
                            SizeId = item.SizeId,
                            Count = item.Count,
                            Price = item.Price,
                            Name = pcs.Product.Name,
                            ExTax = item.ExTax,
                            StockCount = pcs.StockCount
                        };
                        vMs.Add(bas);
                    }
                    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(vMs));
                    break;
                case "database":
                    List<BasketVM> vMs1 = new List<BasketVM>();
                    List<Basket> exist1 = _context.Baskets.Where(p => p.AppUserId == appUser.Id).ToList();
                    if(exist1 != null)
                    {
                        foreach (Basket item in exist1)
                        {
                            ProductColorSize pcs = _context.ProductColorSizes
                                .Include(p => p.Color)
                                .Include(p => p.Size)
                                .Include(p => p.Product)
                                .FirstOrDefault(p => p.ProductId == item.ProductId && p.ColorId == item.ColorId && p.SizeId == item.SizeId);
                            if(pcs != null)
                            {
                                BasketVM bas = new BasketVM()
                                {
                                    Image = pcs.Image,
                                    ProductId = item.ProductId,
                                    ColorId = item.ColorId,
                                    ColorName = pcs.Color.Name,
                                    SizeName = pcs.Size.Name,
                                    SizeId = item.SizeId,
                                    Count = item.Count,
                                    Price = item.Price,
                                    Name = pcs.Product.Name,
                                    ExTax = item.ExTax,
                                    StockCount = pcs.StockCount
                                };
                                vMs1.Add(bas);
                            }
                        }
                    }
                    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(vMs1));
                    break;
                case "basket":
                    List<Basket> exist2 = _context.Baskets.Where(p => p.AppUserId == appUser.Id).ToList();
                    _context.RemoveRange(exist2);
                    if (!string.IsNullOrWhiteSpace(coockieBasket))
                    {
                        List<Basket> baskets = JsonConvert.DeserializeObject<List<Basket>>(coockieBasket);
                        foreach (Basket item in baskets)
                        {
                            item.AppUserId = appUser.Id;
                            item.CreatedAt = DateTime.UtcNow.AddHours(4);
                        }
                        //List<Basket> baskets = new List<Basket>();
                        //for (int i = 0; i < BasketVMs.Count(); i++)
                        //{
                        //    Basket basket = new Basket
                        //    {
                        //        AppUserId = appUser.Id,
                        //        ProductId = BasketVMs[i].ProductId,
                        //        Count = BasketVMs[i].Count,
                        //        ColorId = BasketVMs[i].ColorId,
                        //        SizeId = BasketVMs[i].SizeId,
                        //        Price = BasketVMs[i].Price,
                        //        CreatedAt = DateTime.UtcNow.AddHours(4)
                        //    };
                        //    baskets.Add(basket);

                        //}
                        await _context.Baskets.AddRangeAsync(baskets);
                        await _context.SaveChangesAsync();
                    }
                    List<BasketVM> vMs3 = new List<BasketVM>();
                    List<Basket> exist3 = _context.Baskets.Where(p => p.AppUserId == appUser.Id).ToList();
                    if(exist3!= null)
                    {
                        foreach (Basket item in exist3)
                        {
                            ProductColorSize pcs = _context.ProductColorSizes
                                .Include(p => p.Color)
                                .Include(p => p.Size)
                                .Include(p => p.Product)
                                .FirstOrDefault(p => p.ProductId == item.ProductId && p.ColorId == item.ColorId && p.SizeId == item.SizeId);
                           if(pcs != null)
                            {
                                BasketVM bas = new BasketVM()
                                {
                                    Image = pcs.Image,
                                    ProductId = item.ProductId,
                                    ColorId = item.ColorId,
                                    ColorName = pcs.Color.Name,
                                    SizeName = pcs.Size.Name,
                                    SizeId = item.SizeId,
                                    Count = item.Count,
                                    Price = item.Price,
                                    Name = pcs.Product.Name,
                                    ExTax = item.ExTax,
                                    StockCount = pcs.StockCount
                                };
                                vMs3.Add(bas);
                            }
                        }
                    }
                    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(vMs3));
                    break;
                default:
                    List<BasketVM> vMs4 = new List<BasketVM>();
                    List<Basket> exist4 = _context.Baskets.Where(p => p.AppUserId == appUser.Id).ToList();
                    if(exist4 != null)
                    {
                        foreach (Basket item in exist4)
                        {
                            ProductColorSize pcs = _context.ProductColorSizes
                                .Include(p => p.Color)
                                .Include(p => p.Size)
                                .Include(p => p.Product)
                                .FirstOrDefault(p => p.ProductId == item.ProductId && p.ColorId == item.ColorId && p.SizeId == item.SizeId);
                            if (pcs != null)
                            {
                                BasketVM bas = new BasketVM()
                                {
                                    Image = pcs.Image,
                                    ProductId = item.ProductId,
                                    ColorId = item.ColorId,
                                    ColorName = pcs.Color.Name,
                                    SizeName = pcs.Size.Name,
                                    SizeId = item.SizeId,
                                    Count = item.Count,
                                    Price = item.Price,
                                    Name = pcs.Product.Name,
                                    ExTax = item.ExTax,
                                    StockCount = pcs.StockCount
                                };
                                vMs4.Add(bas);
                            }
                        }
                    }
                    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(vMs4));
                    break;
            }
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            //await _context.SaveChangesAsync();


            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Member,SuperAdmin")]
        public async Task<IActionResult> Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            AppUser appUser = await _userManager.Users
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null) return RedirectToAction("index", "home");
            ViewBag.AppUser = appUser;
            MemberProfileVM memberProfileVM = new MemberProfileVM
            {
                Member = new MemberUpdateVM
                {
                    Address = appUser.Address,
                    City = appUser.City,
                    Country = appUser.Country,
                    FullName = appUser.FullName,
                    PhoneNumber = appUser.PhoneNumber,
                    State = appUser.State,
                    UserName = appUser.UserName,
                    ZipCode = appUser.ZipCode,
                    Email = appUser.Email
                },
                Orders = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .ThenInclude(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                .Include(o => o.AppUser)
                .Where(o => !o.IsDeleted && o.AppUserId == appUser.Id).ToListAsync()

            };

            return View(memberProfileVM);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Edit(MemberUpdateVM member)
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null) return RedirectToAction("index", "home");
            ViewBag.User = appUser;
            MemberProfileVM memberProfileVM = new MemberProfileVM
            {
                Member = member,
                Orders = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.AppUser)
                .Where(o => !o.IsDeleted && o.AppUserId == appUser.Id).ToListAsync()
            };
            TempData["ProfileTab"] = "Account";

            if (!ModelState.IsValid)
            {
                return View("Profile", memberProfileVM);
            }

            if (appUser.NormalizedUserName != member.UserName.ToUpper() && await _userManager.Users.AnyAsync(u => u.NormalizedUserName == member.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName Alreade Exist");

                return View("Profile", memberProfileVM);
            }

            if (appUser.NormalizedEmail != member.Email.ToUpper() && await _userManager.Users.AnyAsync(u => u.NormalizedEmail == member.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email Alreade Exist");
                return View("Profile", memberProfileVM);
            }

            appUser.FullName = member.FullName;
            appUser.UserName = member.UserName;
            appUser.Email = member.Email;
            appUser.Address = member.Address;
            appUser.Country = member.Country;
            appUser.City = member.City;
            appUser.State = member.State;
            appUser.ZipCode = member.ZipCode;
            appUser.PhoneNumber = member.PhoneNumber;

            IdentityResult identityResult = await _userManager.UpdateAsync(appUser);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("Profile", memberProfileVM);
            }

            if (member.Password != null)
            {
                if (string.IsNullOrWhiteSpace(member.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword Is Requered");
                    return View("Profile", memberProfileVM);
                }

                if (!await _userManager.CheckPasswordAsync(appUser, member.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword Is InCorrect");
                    return View("Profile", memberProfileVM);
                }

                string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                identityResult = await _userManager.ResetPasswordAsync(appUser, token, member.Password);
                if (!identityResult.Succeeded)
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Profile", memberProfileVM);
                }
            }

            return RedirectToAction("Profile");
        }

        #region Create Role
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}
        #endregion
        public IActionResult LoginBasket(LoginVM loginVM)
        {
            return PartialView("_LoginBasketPartial");
        }
    }
}
