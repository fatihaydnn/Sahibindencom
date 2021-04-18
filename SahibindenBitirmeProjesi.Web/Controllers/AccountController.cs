using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using SahibindenBitirmeProjesi.Web.Models.Dtos;

namespace SahibindenBitirmeProjesi.Web.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IPasswordHasher<AppUser> _passwordHasher;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }


        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded) return RedirectToAction("Login");
                else foreach (IdentityError error in result.Errors) ModelState.AddModelError("", error.Description);
            }

            return View(user);
        }


        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

                if (user.Succeeded)
                {
                    TempData["success"] = "Giriş İşlemi Başarılı Yönlendiriliyorsunuz";
                    return RedirectToAction(nameof(HomeController.Index), "Home"); // Eğer giriş başarılı olursa HomeController'daki Home Action'a yönlendir.
                }
                ModelState.AddModelError(String.Empty, "Geçersiz giriş denemesi..!");
                TempData["failed"] = "Lütfen Tekrar Deneyiniz";



                //    AppUser appUser = await _userManager.FindByNameAsync(login.UserName);

                //    if (appUser != null)
                //    {
                //        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser.UserName, login.Password, false, false);

                //        if (signInResult.Succeeded)
                //        {
                //            return Redirect(login.ReturnUrl ?? "/");
                //        }
                //        ModelState.AddModelError("", "Giriş yapılamadı bilgilerinizi kontrol ediniz..!");
                //    } 
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        public async Task<IActionResult> Edit()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEdit userEdit = new UserEdit(appUser);
            return View(userEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEdit userEdit)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

                appUser.UserName = userEdit.UserName;

                if (userEdit.Password != null)
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, userEdit.Password);
                }

                IdentityResult ıdentityResult = await _userManager.UpdateAsync(appUser);
                if (ıdentityResult.Succeeded)
                {
                    TempData["Success"] = "Bilgileriniz güncellendi..!";
                }
                else
                {
                    TempData["Warning"] = "Bir hata oluştur..!";
                }
            }

            return View(userEdit);
        }

    }
}
