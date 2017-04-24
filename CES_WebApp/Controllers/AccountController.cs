using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CES_BLL.ViewModels;
using Microsoft.AspNetCore.Identity;
using CES_DAL.Models.UsersEntities;

namespace CES_WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManger;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManger = signInManager;
        }

        public IActionResult Index()
        {
            return Content("Index.");
        }

        public IActionResult Forbidden()
        {
            return Content("Forbidden.");
        }
        public async Task<IActionResult> SignIn()
        {
            var principal = new ClaimsPrincipal(new MyIdentity("jojo", true, "jj"));

            await HttpContext.Authentication.SignInAsync("MyAuthMiddleware", principal);
            return Content("Signed");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.Authentication.SignOutAsync("MyAuthMiddleware");
            return Content("Signed Out.");
        }
        [AllowAnonymous]
        public IActionResult Login(string returnURI)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Login(LoginViewModel model, string returnURI)
        {
            if (ModelState.IsValid) {
                AppUser user = await _userManager.FindByNameAsync(model.Login);
                if(user != null) {
                   await _signInManger.SignOutAsync();
                    var result = await _signInManger.PasswordSignInAsync(user, model.Password, true, false);
                    if (result.Succeeded) {
                        return Redirect(returnURI ?? "/");
                    }
                }
            }
            return View(model);
        }

    }
}