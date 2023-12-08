using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    public class ServiceController : Controller
    {
        private IServicesRepository _servicesRepository;

        public ServiceController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public IActionResult GetProducts()
        {
            var services = _servicesRepository.GetServices();

            if (services != null)
                return View(services);
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult? Index(int id)
        {
            Service? service = _servicesRepository.TryGetService(id);

            return View(service);
        }

        public IActionResult Delete(int id)
        {
            _servicesRepository.Delete(id);
            return RedirectToAction("GetProducts");
        }

        public IActionResult Edit(int id)
        {
            var product = _servicesRepository.TryGetService(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ServiceEdit serviceEdit, int id)
        {
            var currentProduct = _servicesRepository.TryGetService(id);
            currentProduct.Name = serviceEdit.Name;
            currentProduct.Cost = serviceEdit.Cost;
            currentProduct.Description = serviceEdit.Description;
            currentProduct.Link = serviceEdit.Link;
            return RedirectToAction("GetProducts");
        }

        public IActionResult Add()
        {
            if (ModelState.IsValid)
            {
                ServiceEdit serviceEdit = new();
                return View(serviceEdit);
            }

            return RedirectToAction("GetProducts");
        }

        [HttpPost]
        public IActionResult Add(ServiceEdit newProduct)
        {
            var products = _servicesRepository.GetServices();
            products.Add(new Service(newProduct.Name, newProduct.Description, newProduct.Cost, newProduct.Link));
            return RedirectToAction("GetProducts");
        }
    }
}
