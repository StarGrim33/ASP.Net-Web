using Diamond_Cleaning.Helpers;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

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
            return View(Mapping.ToServiceViewModels(services));
        }

        public IActionResult? Index(Guid id)
        {
            var service = _servicesRepository.TryGetService(id);

            return View(service);
        }

        public IActionResult Delete(Guid id)
        {
            _servicesRepository.Delete(id);
            return RedirectToAction("GetProducts");
        }

        public IActionResult Edit(Guid id)
        {
            var product = _servicesRepository.TryGetService(id);

            ServiceViewModel serviceViewModel = new()
            {
                Id = id,
                Cost = product.Cost,
                Description = product.Description,
                Link = product.Link
            };

            return View(serviceViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ServiceViewModel serviceViewModel, Guid id)
        {
            var currentProduct = _servicesRepository.TryGetService(id);
            currentProduct.Name = serviceViewModel.Name;
            currentProduct.Cost = serviceViewModel.Cost;
            currentProduct.Description = serviceViewModel.Description;
            currentProduct.Link = serviceViewModel.Link;
            _servicesRepository.Update(currentProduct);
            return RedirectToAction("GetProducts");
        }

        public IActionResult Add()
        {
            if (ModelState.IsValid)
            {
                ServiceViewModel serviceViewModel = new();
                return View(serviceViewModel);
            }

            return RedirectToAction("GetProducts");
        }

        [HttpPost]
        public IActionResult Add(ServiceViewModel newProduct)
        {
            Service service = new()
            {
                Name = newProduct.Name,
                Cost = newProduct.Cost,
                Description = newProduct.Description,
                Link = newProduct.Link,
            };

            _servicesRepository.Add(service);
            return RedirectToAction("GetProducts");
        }
    }
}
