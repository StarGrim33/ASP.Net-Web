using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using Diamond_Cleaning.Helpers;
using Diamond_Cleaning.Areas.Administrator.Models;
using Microsoft.EntityFrameworkCore;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> GetUsers()
		{
			var users = await _userManager.Users.ToListAsync();
            var usersViewModel = Mapping.ToUsersViewModel(users);
            return View(usersViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EditUser user)
        {
            if (user.UserName == user.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
                return View(user);
            }
            if (ModelState.IsValid)
            {
                User usr = new()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PhoneNumber = user.Phone
                };

                var result = await _userManager.CreateAsync(usr, user.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(usr, "User");
                    return RedirectToAction(nameof(GetUsers));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(user);
        }


        public async Task<IActionResult> Details(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var userRoles = await _userManager.GetRolesAsync(user);
            return View(Mapping.ToUserViewModelWithRole(user, userRoles.ToList()));
        }

        public async Task<IActionResult> Edit(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return View(Mapping.ToEditUserViewModel(user));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditUserViewModel editUserViewModel, string name)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(name); 
                user.PhoneNumber = editUserViewModel.Phone;
                user.UserName = editUserViewModel.Name;
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(GetUsers));
            }

            return View(editUserViewModel);
        }

        public IActionResult ChangePassword(string name)
        {
            if (ModelState.IsValid)
            {
                var changePassword = new ChangePasswordViewModel()
                {
                    UserName = name
                }; 

                return View(changePassword);
            }

            return View(nameof(GetUsers));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(changePassword.UserName);
                var newHashPassword = _userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(GetUsers));
            }

            return RedirectToAction(nameof(GetUsers));
        }

        public async Task<IActionResult> ChangeAccess(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();
            var model = new EditRoleViewModel
            {
                Name = user.UserName,
                UserRoles = userRoles.Select(x => new RoleViewModel {Name = x}).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAccess(string name, Dictionary<string, bool> userRolesViewsModel)
        {
            if (ModelState.IsValid)
            {
                var userSelectedRoles = userRolesViewsModel.Select(x => x.Key);
                var user = await _userManager.FindByNameAsync(name);
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, userSelectedRoles);
                return Redirect($"/Administrator/User/Details?name={name}");
            }

            return Redirect($"/Administrator/User/ChangeAccess?name={name}");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(GetUsers));
        }
    }
}
