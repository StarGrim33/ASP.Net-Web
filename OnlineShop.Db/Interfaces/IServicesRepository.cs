using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IServicesRepository
    {
        Task<List<Service>> GetServicesAsync();

        Service? TryGetService(Guid id);

        void Delete(Guid id);

        void Add(Service service);

        void Update(Service service);
    }
}