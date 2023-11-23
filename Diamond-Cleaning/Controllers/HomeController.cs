using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Diamond_Cleaning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _productRepository = new();
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["CurrentDate"] = DateOnly.FromDateTime(DateTime.Now);
            ViewData["LastWeekStartDate"] = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
            var services = _productRepository.GetServices();
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
