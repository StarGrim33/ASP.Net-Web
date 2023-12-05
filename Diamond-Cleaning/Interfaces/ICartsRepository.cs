using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface ICartsRepository
    {
        void Add(Service service, string userId);

        Cart TryGetByUserId(string userId);

        void Delete(Service service, string productId);

        void Clear(string userId);
    }
}