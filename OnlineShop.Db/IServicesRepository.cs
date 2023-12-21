using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IServicesRepository
    {
        List<Service> GetServices();

        Service? TryGetService(Guid id);

        void Delete(Guid id);

        void Add(Service service);

        void Update(Service service);
    }
}