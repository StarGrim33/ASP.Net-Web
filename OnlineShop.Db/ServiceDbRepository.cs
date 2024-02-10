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

        public async Task<Service?> TryGetService(Guid id)
        {
            try
            {
                return await _dbContext.Services.FirstOrDefaultAsync(product => product.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            var product = await TryGetService(id);
            _dbContext.Services?.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(Service service)
        {
            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Service service)
        {
            _dbContext.Services.Update(service);
            await _dbContext.SaveChangesAsync();
        }
    }
}
