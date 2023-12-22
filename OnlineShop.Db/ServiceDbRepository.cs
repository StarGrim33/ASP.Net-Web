using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ServiceDbRepository : IServicesRepository
    {
        private readonly DatabaseContext _dbContext;

        public ServiceDbRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Service> GetServices()
        {
            try
            {
                var services = _dbContext.Services.ToList();
                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Service? TryGetService(Guid id)
        {
            try
            {
                return _dbContext.Services.FirstOrDefault(product => product.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Guid id)
        {
            var product = TryGetService(id);
            _dbContext.Services?.Remove(product);
            _dbContext.SaveChanges();
        }

        public void Add(Service service)
        {
            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();
        }

        public void Update(Service service)
        {
            _dbContext.Services.Update(service);
            _dbContext.SaveChanges();
        }
    }
}
