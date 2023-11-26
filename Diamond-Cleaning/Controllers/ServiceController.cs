using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class ServiceController : Controller
    {
        private ProductRepository _services;

        public ServiceController()
        {
            _services = new ProductRepository();
        }

        public IActionResult? Index(int id)
        {
            Service? service = _services.TryGetService(id);

            return View(service);
        }
    }
}
