using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class FavouriteDbRepository : IFavouriteRepository
    {
        private readonly DatabaseContext _dbContext;

        public FavouriteDbRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public void Add(string userId, Service product)
        {
            var existingService = _dbContext.FavouriteServices
               .FirstOrDefault(x => x.UserId == userId && x.Service.Id == product.Id);

            if (existingService == null)
            {
                _dbContext.FavouriteServices.Add(new FavouriteServices { Service = product, UserId = userId });
                _dbContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavouriteServices = _dbContext.FavouriteServices
                .Where(u => u.UserId == userId)
                .ToList();

            _dbContext.FavouriteServices.RemoveRange(userFavouriteServices);
            _dbContext.SaveChanges();
        }

        public List<Service> GetAll(string userId)
        {
            return _dbContext.FavouriteServices
                .Where(u => u.UserId == userId)
                .Include(x => x.Service)
                .Select(x => x.Service)
                .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removingFavourite = _dbContext.FavouriteServices
                .FirstOrDefault(u => u.UserId == userId && u.Service.Id == productId);

            _dbContext.FavouriteServices.Remove(removingFavourite);
            _dbContext.SaveChanges();
        }
    }
}
