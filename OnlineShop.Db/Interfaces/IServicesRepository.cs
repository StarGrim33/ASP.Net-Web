using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IServicesRepository
    {
        List<Service> GetServices();

        Task<Service?> TryGetService(Guid id);

        Task Delete(Guid id);

        Task Add(Service service);

        Task Update(Service service);
    }
}