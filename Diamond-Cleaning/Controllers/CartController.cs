using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class CartController : Controller
    {
        private readonly IServicesRepository _productRepository;
        private readonly ICartsRepository _cartRepository;

        public CartController(IServicesRepository productRepository, ICartsRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public IActionResult Add(int productId)
        {
            try
            {
                var item = _productRepository.TryGetService(productId);
                _cartRepository.Add(item, Constants.UserId);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Delete(int productId)
        {
            try
            {
                var item = _productRepository.TryGetService(productId);
                _cartRepository.Delete(item, Constants.UserId);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Clear()
        {
            _cartRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
    }
}
