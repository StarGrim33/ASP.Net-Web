using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public IActionResult GetRoles()
        {
            var roles = _rolesRepository.GetAll();
            return View("Roles", roles);
        }

        public IActionResult AddRoles()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoles(Roles role)
        {
            var roles = _rolesRepository.GetAll();

            if (roles.FirstOrDefault(r => r.Name == role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            _rolesRepository.Add(role);
            return RedirectToAction("GetRoles");
        }

        [HttpPost]
        public IActionResult DelRoles(string Name)
        {
            var roles = _rolesRepository.GetAll();
            var currentRole = roles.FirstOrDefault(role => role.Name == Name);

            _rolesRepository.Delete(currentRole);
            return RedirectToAction("GetRoles");
        }
    }
}
