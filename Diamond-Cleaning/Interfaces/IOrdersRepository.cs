using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface IOrdersRepository
    {
        Task Add(Order order);

        List<Order> GetAllOrders();
    }
}
