using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CompareDbRepository : ICompareServices
    {
        private readonly DatabaseContext _dbContext;

        public CompareDbRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(string userId, Service product)
        {
            var existingService = _dbContext.CompareServices
                .FirstOrDefault(x => x.UserId == userId && x.Service.Id == product.Id);

            if (existingService == null)
            {
                _dbContext.CompareServices.Add(new CompareServices { Service = product, UserId = userId });
                _dbContext.SaveChanges();
            }
        }

        public void Remove(string userId, Guid productId)
        {
            var removingCompare = _dbContext.CompareServices
                .FirstOrDefault(u => u.UserId == userId && u.Service.Id == productId);

            _dbContext.CompareServices.Remove(removingCompare);
            _dbContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var userCompareProducts = _dbContext.CompareServices
                .Where(u => u.UserId == userId)
                .ToList();

            _dbContext.CompareServices.RemoveRange(userCompareProducts);
            _dbContext.SaveChanges();
        }

        public List<Service> GetAll(string userId)
        {
            return _dbContext.CompareServices
                .Where(u => u.UserId == userId)
                .Include(x => x.Service)
                .Select(x => x.Service)
                .ToList();
        }
    }
}
