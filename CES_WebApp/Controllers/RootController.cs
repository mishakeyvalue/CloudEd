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
    
    public class RootController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;



        public RootController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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



                IdentityResult result =
                    await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded) {

                    var roleResult = await _userManager.AddToRoleAsync(newUser, model.Rank);
                    if(roleResult.Succeeded)
                        return RedirectToAction("Index");
                    return Content(AddErrorsFromResult(roleResult));
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

            var result = await _userManager.RemovePasswordAsync(user);
            if (result.Succeeded)
            {
                var r = await _userManager.AddPasswordAsync(user, model.Password);

                if (r.Succeeded)
                {
                    user.Password = model.Password;
                    var updateResult = await _userManager.UpdateAsync(user);
                    if (updateResult.Succeeded)
                        return RedirectToAction("Index");
                    else return Content(AddErrorsFromResult(updateResult));
                }

                else return Content(AddErrorsFromResult(r));

            }

            else return Content(AddErrorsFromResult(result));

        }

        private void addErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }

        private string AddErrorsFromResult(IdentityResult result)
        {
            string err = "";
            foreach (IdentityError error in result.Errors)
            {
                err += error.Description + "\n";
            }
            return err;
        }
    }
}