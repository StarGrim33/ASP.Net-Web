using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolesManager;

        public RolesController(RoleManager<IdentityRole> rolesRepository)
        {
            _rolesManager = rolesRepository;
        }

        public IActionResult GetRoles()
        {
            var roles = _rolesManager.Roles.ToList();
            return View(nameof(Roles), roles);
        }

        public IActionResult AddRoles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoles(Roles role)
        {
            var roles = _rolesManager.Roles.ToList();

            if (roles.FirstOrDefault(r => r.Name == role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            var result = await _rolesManager.CreateAsync(new IdentityRole() { Name = role.Name });

            if(result.Succeeded)
            {
                return RedirectToAction(nameof(GetRoles));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> DelRoles(string Name)
        {
            var role = await _rolesManager.FindByNameAsync(Name);

            if (role != null)
            {
                _rolesManager.DeleteAsync(role).Wait();
            }

            return RedirectToAction(nameof(GetRoles));
        }
    }
}
