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
    [Authorize(Roles = "root")]
    public class RootController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;



        public RootController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
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
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser() { Name = model.Name, UserName = model.Login, Password = model.Password, Rank = model.Rank };
                IdentityResult result =
                    await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(newUser, model.Rank);
                    if (roleResult.Succeeded)
                        newUser.Rank = model.Rank;
                        await _userManager.UpdateAsync(newUser);
                   
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
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
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    addErrorsFromResult(result);
                }

            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("Index", _userManager.Users);

        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(new UserViewModel(user));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);


            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded) return Content(AddErrorsFromResult(result));

            var r = await _userManager.AddPasswordAsync(user, model.Password);
            if (!r.Succeeded) return Content(AddErrorsFromResult(r));

            user.Password = model.Password;
            user.Name = model.Name;
            user.UserName = model.Login;
            if(await _roleManager.RoleExistsAsync(model.Rank))
            {
                //   IdentityRole role = await _roleManager.FindByNameAsync(model.Rank);
                if (!_userManager.GetRolesAsync(user).Result.Contains(model.Rank))
                {
                    var roleRes = await _userManager.AddToRoleAsync(user, model.Rank);
                    if (!roleRes.Succeeded) { return Content(AddErrorsFromResult(r)); }
                    else user.Rank = model.Rank;
                }
            }


            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
                return RedirectToAction("Index");
            else return Content(AddErrorsFromResult(updateResult));



        }

        private void addErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
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