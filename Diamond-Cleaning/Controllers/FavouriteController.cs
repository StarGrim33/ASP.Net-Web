﻿using Diamond_Cleaning.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System.ComponentModel;

namespace Diamond_Cleaning.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IServicesRepository _servicesRepository;

        public FavouriteController(IFavouriteRepository favouriteRepository, IServicesRepository servicesRepository)
        {
            _favouriteRepository = favouriteRepository;
            _servicesRepository = servicesRepository;
        }

        public IActionResult Index()
        {
            var services = _favouriteRepository.GetAll(Constants.UserId);
            return View(Mapping.ToServiceViewModels(services));
        }

        public IActionResult Add(Guid serviceId)
        {
            var service = _servicesRepository.TryGetService(serviceId);

            if (service != null)
            {
                _favouriteRepository.Add(Constants.UserId, service);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(Guid serviceId) 
        { 
            _favouriteRepository.Remove(Constants.UserId, serviceId); 
            return RedirectToAction(nameof(Index));
        }
    }
}
