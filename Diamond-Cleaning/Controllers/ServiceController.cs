using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class ServiceController : Controller
    {
        private IServicesRepository _services;

        public ServiceController(IServicesRepository services)
        {
            _services = services;
        }

        public IActionResult? Index(int id)
        {
            Service? service = _services.TryGetService(id);

            return View(service);
        }
    }
}
