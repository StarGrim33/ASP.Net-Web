using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext _ordersRepository;

        public OrdersDbRepository(DatabaseContext ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void Add(Order order)
        {
            try
            {
                _ordersRepository.Orders.Add(order);
                _ordersRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> GetAllOrders()
        {
            return _ordersRepository.Orders.Include(x => x.User).
                Include(x => x.Items).ThenInclude(x => x.Service).ToList();
        }

        public Order TryGetById(Guid id)
        {
            return _ordersRepository.Orders.Include(x => x.User).Include(x => x.Items).
                ThenInclude(x => x.Service).FirstOrDefault(o => o.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatuses newStatus)
        {
            var order = TryGetById(orderId);

            if (order != null)
            {
                order.Status = newStatus;
            }

            _ordersRepository.SaveChanges();
        }
    }
}
