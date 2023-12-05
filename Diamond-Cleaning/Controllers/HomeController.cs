﻿using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Diamond_Cleaning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicesRepository _servicesRepository;
        private readonly ICartsRepository _cartsRepository;

        public HomeController(ILogger<HomeController> logger, IServicesRepository servicesRepository, ICartsRepository cartsRepository)
        {
            _logger = logger;
            _servicesRepository = servicesRepository;
            _cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            ViewBag.ProductCount = cart?.Amount;
            ViewData["CurrentDate"] = $"Сегодня: {DateOnly.FromDateTime(DateTime.Now)}";
            ViewData["LastWeekStartDate"] = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
            var services = _servicesRepository.GetServices();
            return View(services);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
