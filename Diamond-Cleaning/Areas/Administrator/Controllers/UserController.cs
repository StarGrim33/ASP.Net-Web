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
            return View(Mapping.ToUserViewModel(user));
        }

        public async Task<IActionResult> Edit(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return View(Mapping.ToEditUserViewModel(user));
        }

        [HttpPost]
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

            return RedirectToAction(nameof(ChangePassword));
        }

        //public IActionResult ChangeAccess(string name)
        //{
        //    var user = _userManager.FindByNameAsync(name).Result;
        //    var userRoles = _userManager.GetRolesAsync(user).Result;
        //    var roles = _roleManager.Roles.ToList();
        //    var model = new ChangeRoleViewModel
        //    {
        //        Name = user.UserName,
        //        UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
        //        AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
        //    };

        //    return View(model);
        //}

        [HttpPost]
        public IActionResult ChangeAccess(string name, Dictionary<string, bool> userRolesViewsModel)
        {
            if (ModelState.IsValid)
            {
                var userSelectedRoles = userRolesViewsModel.Select(x => x.Key);
                var user = _userManager.FindByNameAsync(name).Result;
                var userRoles = _userManager.GetRolesAsync(user).Result;
                _userManager.RemoveFromRolesAsync(user, userRoles).Wait();
                _userManager.AddToRolesAsync(user, userSelectedRoles).Wait();
                return Redirect($"/Admin/User/Details?name={name}");
            }

            return Redirect($"/Admin/User/EditRights?name={name}");
        }

        public async Task<IActionResult> Delete(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(GetUsers));
        }
    }
}
