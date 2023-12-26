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

        public static UserOrderInfoViewModel ToUserOrderInfoViewModel(UserOrderInfo userOrderInfo)
        {
            if (userOrderInfo == null)
                return null;

            return new UserOrderInfoViewModel()
            {
                Id = userOrderInfo.Id,
                Name = userOrderInfo.Name,
                Address = userOrderInfo.Address,
                Email = userOrderInfo.Email,
                Phone = userOrderInfo.Phone
            };
        }

        public static List<OrderViewModel> ToOrderViewModels(List<Order> orders)
        {
            var ordersView = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var ord = new OrderViewModel
                {
                    Id = order.Id,
                    Items = ToCartItemViewModels(order.Items),
                    Status = (Models.OrderStatuses)(int)order.Status,
                    Time = order.Time,
                    User = ToUserOrderInfoViewModel(order.User)
                };

                ordersView.Add(ord);
            }

            return ordersView;
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            if (order == null)
                return null;

            return new OrderViewModel()
            {
                Id = order.Id,
                Status = (Models.OrderStatuses)(int)order.Status,
                Items = ToCartItemViewModels(order.Items),
                Time = order.Time,
                User = ToUserOrderInfoViewModel(order.User),
            };
        }

        public static UserOrderInfo ToUser(UserOrderInfoViewModel user)
        {
            return new UserOrderInfo
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
            };
        }
    }
}
