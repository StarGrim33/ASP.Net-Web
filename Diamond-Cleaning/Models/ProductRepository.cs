namespace Diamond_Cleaning.Models
{
    public class ProductRepository
    {
        private static List<Service>? _services;

        static ProductRepository()
        {
            _services =
            [
                new(name: "Стандартная уборка квартиры",
                description: "Стандартная уборка вашей квартиры, цена зависит от количества комнат и площади", cost: "От 5000 тыс. рублей"),
                new(name: "Генеральная уборка квартиры", description: "Генеральная уборка вашеей квартиры", cost: "От 8000 тыс. рублей"),
                new(name: "Уборка поддерживающая", description: "Поддерживающая уборка квартиры", cost: "От 3000 тыс. рублей")
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
