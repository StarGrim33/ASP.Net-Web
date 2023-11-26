using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class ServiceController : Controller
    {
        private ServicesRepository _services;

        public ServiceController()
        {
            _services = new ServicesRepository();
        }

        public IActionResult? Index(int id)
        {
            Service? service = _services.TryGetService(id);

            return View(service);
        }
    }
}
