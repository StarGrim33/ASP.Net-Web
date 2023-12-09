using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class AuthorizationController : Controller
    {
        private IUsersRepository _usersRepository;

        public AuthorizationController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            if(string.IsNullOrEmpty(user.Name))
            {
                ModelState.AddModelError("", "Введите данные");
                return View("Index", user);
            }

            var userAccount = _usersRepository.TryGetByName(user.Name);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем не найден. Проверьте имя или зарегистрируйтесь.");
                return View("Index", user);
            }
            if (userAccount.Password != user.Password)
            {
                ModelState.AddModelError("", "Не верный пароль");
                return View("Index", user);
            }
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            var userAccount = _usersRepository.TryGetByName(register.UserName);

            if (userAccount != null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже есть.");
                return View(register);
            }
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
                return View(register);
            }
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            _usersRepository.Add(new User(register.UserName, register.Password, register.FirstName, register.LastName, register.Phone));
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
