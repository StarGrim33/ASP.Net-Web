using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class AdministratorController : Controller
    {
        private IServicesRepository _servicesRepository;
        private IOrdersRepository _ordersRepository;
        private IRolesRepository _rolesRepository;

        public AdministratorController(IServicesRepository servicesRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            _servicesRepository = servicesRepository;
            _ordersRepository = ordersRepository;
            _rolesRepository = rolesRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            var orders = _ordersRepository.GetAllOrders();
            return View(orders);
        }

        public IActionResult GetUsers()
        {
            return View();
        }

        public IActionResult GetRoles()
        {
            var roles = _rolesRepository.GetAll();
            return View("Roles", roles);
        }

        public IActionResult GetProducts()
        {
            var services = _servicesRepository.GetServices();

            if(services != null)
                return View(services);
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult EditStatus(Guid id)
        {
            var orders = _ordersRepository.GetAllOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == id);
            return View(currentOrder);
        }

        [HttpPost]
        public IActionResult EditStatus(Guid Id, OrderStatuses Status)
        {
            var orders = _ordersRepository.GetAllOrders();
            Order? currentOrder = orders.FirstOrDefault(order => order.Id == Id);
            currentOrder.Status = Status;
            return RedirectToAction("GetOrders");
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
