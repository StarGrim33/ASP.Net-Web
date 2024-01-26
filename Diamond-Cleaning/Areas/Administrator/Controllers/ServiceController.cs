using AutoMapper;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServicesRepository _servicesRepository;
        private readonly IMapper _mapper;

        public ServiceController(IServicesRepository servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetProducts()
        {
            var services = await _servicesRepository.GetServicesAsync();
            var servicesViewModels = services.Select(_mapper.Map<ServiceDto>).ToList();
            return View(servicesViewModels);
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
