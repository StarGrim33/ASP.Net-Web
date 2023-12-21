using Microsoft.EntityFrameworkCore;
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

        //public ServiceDbRepository()
        //{
        //    //_services =
        //    //[
        //    //    new Service(name: "Стандартная уборка квартиры",
        //    //    description: "Стандартная уборка вашей квартиры, цена зависит от количества комнат и площади", cost: 5000,
        //    //    link: "/image/image1.jpg"),
        //    //    new Service(name: "Генеральная уборка квартиры", description: "Генеральная уборка вашей квартиры", cost: 8000,
        //    //    link: "/image/image2.jpg"),
        //    //    new Service(name: "Уборка поддерживающая", description: "Поддерживающая уборка квартиры", cost: 3000,
        //    //    link: "/image/image3.jpeg")
        //    //];
        //}

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
