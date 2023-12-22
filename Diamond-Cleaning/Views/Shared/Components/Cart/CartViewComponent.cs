using Diamond_Cleaning.Helpers;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartRepository;

        public CartViewComponent(ICartsRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
         
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
