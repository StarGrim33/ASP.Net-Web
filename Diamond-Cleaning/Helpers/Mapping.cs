using Diamond_Cleaning.Models;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Helpers
{
    public static class Mapping
    {
        public static List<ServiceViewModel> ToServiceViewModels(List<Service> services)
        {
            var productsViewModels = new List<ServiceViewModel>();

            foreach (var service in services)
            {
                productsViewModels.Add(ToServiceViewModel(service));
            }

            return productsViewModels;
        }

        public static ServiceViewModel ToServiceViewModel(Service service)
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Cost = service.Cost,
                Description = service.Description,
                Link = service.Link
            };
        }

        public static CartViewModel? ToCartViewModel(Cart cart)
        {
            if (cart == null)
                return null;

            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items),
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDtItems)
        {
            var cartItems = new List<CartItemViewModel>();

            foreach (var cartDtItem in cartDtItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDtItem.Id,
                    Amount = cartDtItem.Amount,
                    Service = ToServiceViewModel(cartDtItem.Service),
                };

                cartItems.Add(cartItem);
            }

            return cartItems;
        }
    }
}
