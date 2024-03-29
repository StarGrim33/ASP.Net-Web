﻿using Diamond_Cleaning.Helpers;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;

namespace Diamond_Cleaning.Controllers
{
    public class ServiceController : Controller
    {
        private IServicesRepository _services;

        public ServiceController(IServicesRepository services)
        {
            _services = services;
        }

        public async Task<IActionResult?> Index(Guid serviceId)
        {
            var service = await _services.TryGetService(serviceId);
            return View(Mapping.ToServiceViewModel(service));
        }

        public IActionResult Delete(Guid id)
        {
            _services.Delete(id);
            return RedirectToAction("GetProducts", "Administrator");
        }

        public IActionResult Edit(Guid id)
        {
            var product = _services.TryGetService(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceEdit serviceEdit, Guid id)
        {
            var currentProduct = await _services.TryGetService(id);
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
    }
}
