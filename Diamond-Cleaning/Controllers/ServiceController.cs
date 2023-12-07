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

        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return RedirectToAction("GetProducts", "Administrator");
        }

        public IActionResult Edit(int id)
        {
            var product = _services.TryGetService(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ServiceEdit serviceEdit, int id)
        {
            var currentProduct = _services.TryGetService(id);
            currentProduct.Name = serviceEdit.Name;
            currentProduct.Cost = serviceEdit.Cost;
            currentProduct.Description = serviceEdit.Description;
            currentProduct.Link = serviceEdit.Link;
            return RedirectToAction("GetProducts", "Administrator");
        }

        public IActionResult Add()
        {
            if(ModelState.IsValid)
            {
                ServiceEdit serviceEdit = new();
                return View(serviceEdit);
            }

            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(ServiceEdit newProduct)
        {
            var products = _services.GetServices();
            products.Add(new Service(newProduct.Name, newProduct.Description, newProduct.Cost, newProduct.Link));
            return RedirectToAction("GetProducts", "Administrator");
        }
    }
}
