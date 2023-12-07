using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorize(User user)
        {
            if (user.Name == user.Password)
                ModelState.AddModelError("", "Имя и пароль не должны совпадать");

            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(User user)
        {
            if (user.Name == user.Password)
                ModelState.AddModelError("", "Имя и пароль не должны совпадать");

            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            return View("Register");
        }
    }
}
