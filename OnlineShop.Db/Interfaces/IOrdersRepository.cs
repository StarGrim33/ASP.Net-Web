using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IOrdersRepository
    {
        void Add(Order order);

        List<Order> GetAllOrders();

        Order TryGetById(Guid id);

        void UpdateStatus(Guid id, OrderStatuses newStatus);
    }
}
