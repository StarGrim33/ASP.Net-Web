using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Make(Order order)
        {
            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
            _ordersRepository.Add(existingCart, order);
            _cartsRepository.Clear(Constants.UserId);
            return View("~/Views/Order/Success.cshtml", order);
        }
    }
}
