using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CES_WebApp.Controllers
{
    public class AccountController : Controller
    {
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
    }
}