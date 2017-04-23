using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CES_DAL.Models.UsersEntities;
using CES_BLL.ViewModels;

namespace CES_WebApp.Controllers
{
    public class RootController : Controller
    {
        private UserManager<AppUser> _userManager;

        public RootController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid) {
                AppUser newUser = new AppUser();
                switch (model.Rank) {
                    case Rank.Root:
                        break;
                    case Rank.Teacher:
                        newUser = new Teacher() { UserName = model.Name, Login = model.Login, Password = model.Password };
                        break;
                    case Rank.Student:
                        newUser = new Student() { UserName = model.Name, Login = model.Login, Password = model.Password };
                        break;
                    default:
                        break;
                }
                IdentityResult result =
                    await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
                else {
                    foreach (IdentityError error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}