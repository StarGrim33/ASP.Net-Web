using Diamond_Cleaning.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var productCounts = cart?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
