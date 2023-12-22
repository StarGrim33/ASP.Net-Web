using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface ICompareServices
    {
        void Add(string userId, Service product);

        public void Remove(string userId, Guid productId);

        public void Clear(string userId);

        public List<Service> GetAll(string userId);
    }
}
