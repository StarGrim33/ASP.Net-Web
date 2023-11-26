using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface ICartsRepository
    {
        void Add(Service service, string userId);

        public Cart TryGetByUserId(string userId);
    }
}