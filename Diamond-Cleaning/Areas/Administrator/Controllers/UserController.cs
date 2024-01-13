using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private IUsersRepository _usersRepository;
        private IRolesRepository _rolesRepository;

        public UserController(IUsersRepository usersRepository, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
        }

        public IActionResult GetUsers()
        {
            var users = _usersRepository.GetAll();
            return View(users);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Register register)
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

            //_usersRepository.Add(new UserViewModel(register.UserName, register.Password, register.FirstName, register.LastName, register.Phone));
            return RedirectToAction("GetUsers");
        }

        public IActionResult Details(Guid guid)
        {
            var user = _usersRepository.TryGetById(guid);

            if (user == null)
                return View(nameof(GetUsers));

            return View(user);
        }

        public IActionResult Delete(Guid userId)
        {
            _usersRepository.Delete(userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid userId)
        {
            var user = _usersRepository.TryGetById(userId);
            var editUser = new EditUser
            {
                Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            };

            ViewData["userId"] = userId;
            return View(editUser);
        }

        [HttpPost]
        public IActionResult Edit(EditUser user, Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _usersRepository.Edit(user, userId);
            return RedirectToAction(nameof(GetUsers));
        }

        public IActionResult ChangePassword(Guid userId)
        {
            var user = _usersRepository.TryGetById(userId);
            return View(user);
        }

        [HttpPost]
        public IActionResult ChangePassword(Guid userId, string password)
        {
            _usersRepository.ChangePassword(userId, password);
            return RedirectToAction(nameof(GetUsers));
        }

        public IActionResult ChangeAccess(Guid userId)
        {
            var user = _usersRepository.TryGetById(userId);
            var roles = _rolesRepository.GetAll();
            ViewData["userId"] = userId;
            ViewData["userName"] = user.Name;
            ViewData["userRole"] = user.Role.Name;
            return View(roles);
        }

        [HttpPost]
        public IActionResult ChangeAccess(Guid userId, string role)
        {
            _usersRepository.ChangeAccess(userId, role);
            return RedirectToAction(nameof(GetUsers));
        }
    }
}
