using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthorizationController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }

            return View(login);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                User user = new User { Email = register.UserName, UserName = register.UserName, PhoneNumber = register.Phone };
                var result = _userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(register);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home");
        }
    }
}
