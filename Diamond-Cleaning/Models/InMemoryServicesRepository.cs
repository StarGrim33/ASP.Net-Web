using Diamond_Cleaning.Interfaces;

namespace Diamond_Cleaning.Models
{
    public class InMemoryServicesRepository : IServicesRepository
    {
        private List<Service>? _services;

        public InMemoryServicesRepository()
        {
            _services =
            [
                new Service(name: "Стандартная уборка квартиры",
                description: "Стандартная уборка вашей квартиры, цена зависит от количества комнат и площади", cost: 5000,
                link: "/image/image1.jpg"),
                new Service(name: "Генеральная уборка квартиры", description: "Генеральная уборка вашей квартиры", cost: 8000,
                link: "/image/image2.jpg"),
                new Service(name: "Уборка поддерживающая", description: "Поддерживающая уборка квартиры", cost: 3000,
                link: "/image/image3.jpeg")
            ];
        }

        public List<Service> GetServices()
        {
            try
            {
                return _services;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Service? TryGetService(int id)
        {
            try
            {
                return _services.FirstOrDefault(product => product.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
