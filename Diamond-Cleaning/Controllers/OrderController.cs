using Diamond_Cleaning.Helpers;
using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

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
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserOrderInfoViewModel user)
        {
            if (!user.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должны содержать только буквы");
            }
            if (!user.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
            }
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
            var existingCartViewModel = Mapping.ToCartViewModel(existingCart);

            var order = new Order
            {
                User = Mapping.ToUser(user),
                Items = existingCart.Items
            };

            _ordersRepository.Add(order);
            _cartsRepository.Clear(Constants.UserId);
            return View("Success", Mapping.ToOrderViewModel(order));
        }
    }
}
