using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return _databaseContext.Carts.Include(x => x.Items).
                ThenInclude(x => x.Service).
                FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Service service, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>()
                    {
                        new()
                        {
                            Amount = 1,
                            Service = service,
                            Cart = newCart
                        }
                    };

                _databaseContext.Carts.Add(newCart);   
            }
            else
            {
                var existingCartService = existingCart.Items.FirstOrDefault(x => x.Service.Id == service.Id);

                if (existingCartService != null)
                {
                    existingCartService.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem()
                    {
                        Amount = 1,
                        Service = service,
                        Cart = existingCart
                    });
                }
            }
        }

        public void Delete(Service service, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Service.Id == service.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Amount--;

                if (existingCart.Items.Count == 0)
                    _databaseContext.Carts.Remove(existingCart);

                if (existingCartItem.Amount == 0)
                    existingCart.Items.Remove(existingCartItem);

                _databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            var existingCart = TryGetByUserId(userId);
            _databaseContext.Carts.Remove(existingCart);
        }
    }
}
