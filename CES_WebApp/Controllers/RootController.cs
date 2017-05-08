using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CES_DAL.Models.UsersEntities;
using CES_BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CES_WebApp.Controllers
{
    [Authorize]
    public class RootController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppUser> _roleManager;



        public RootController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
         //   _roleManager = roleManager;
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
                AppUser newUser = new AppUser() {Name = model.Name, UserName = model.Login, Password = model.Password };

                

                switch (model.Rank) {
                    case Rank.Root:
                        
                        break;
                    case Rank.Teacher:
                        //  newUser = new Teacher() { UserName = model.Name, Login = model.Login, Password = model.Password };
                        break;
                    case Rank.Student:
                        //  newUser = new Student() { UserName = model.Name, Login = model.Login, Password = model.Password };
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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
                else {
                    addErrorsFromResult(result);
                }

            }
            else {
                ModelState.AddModelError("", "User not found");
            }
            return View("Index", _userManager.Users);

        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                return View(user);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return View("Index");
        }

        private void addErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}