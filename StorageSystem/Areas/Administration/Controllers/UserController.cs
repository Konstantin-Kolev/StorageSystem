using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Data.Entities;
using StorageSystem.Data.Enumeration;
using StorageSystem.Models.User;
using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static StorageSystem.Common.GlobalConstants;

namespace StorageSystem.Areas.Administration.Controllers
{
    public class UserController : AdministrationBaseController
    {
        private readonly UserManager<User> userManager;
        private Claim notAdminClaim = new Claim("notAdmin", "notAdmin");

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            User user = model.To<User>();
            await userManager.CreateAsync(user, model.Password);
            if(model.Role==UserRole.Manager)
            {
                await userManager.AddToRoleAsync(user, Roles.Manager);
            }
            else
            {
                await userManager.AddToRoleAsync(user, Roles.Manager);
            }

            await userManager.AddClaimAsync(user, notAdminClaim);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users = await userManager.GetUsersForClaimAsync(notAdminClaim);
            return View(users.Select(u=>u.To<UserViewModel>()));
        }

        public async Task<IActionResult> Details(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            return View(user.To<UserDetailsViewModel>());
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            return View(user.To<UserEditInputModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditInputModel model)
        {
            User user = await userManager.FindByIdAsync(model.Id);
            user.Email = model.Email;
            user.UserName = model.Username;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;

            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Details), new { model.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            return View(user.To<UserDetailsViewModel>());
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DelteConfirm(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
