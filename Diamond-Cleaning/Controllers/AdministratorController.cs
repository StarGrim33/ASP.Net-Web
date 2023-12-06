using Diamond_Cleaning.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class AdministratorController : Controller
    {
        private IServicesRepository _servicesRepository;

        public AdministratorController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
        public IActionResult GetOrders()
        {
            return View();
        }

        public IActionResult GetUsers()
        {
            return View();
        }

        public IActionResult GetRoles()
        {
            return View();
        }

        public IActionResult GetProducts()
        {
            var services = _servicesRepository.GetServices();

            if(services != null)
                return View(services);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
