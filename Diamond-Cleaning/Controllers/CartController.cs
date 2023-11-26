using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class CartController : Controller
    {
        private readonly ServicesRepository _productRepository;

        public CartController()
        {
            _productRepository = new();
        }

        public IActionResult Add(int productId)
        {
            try
            {
                var item = _productRepository.TryGetService(productId);
                CartsRepository.Add(item, Constants.UserId);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
    }
}
