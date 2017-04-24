using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CES_WebApp.Controllers
{
    public class RoleAdminController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        public RoleAdminController(RoleManager<IdentityRole> roleManager)
        {

            _roleManager = roleManager;
        }
        public ViewResult Index() => View(_roleManager.Roles);
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid) {
                IdentityResult result
                = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
                else {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null) {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
                else {
                    AddErrorsFromResult(result);
                }
            }
            else {
                ModelState.AddModelError("", "No role found");
            }
            return View("Index", _roleManager.Roles);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}

