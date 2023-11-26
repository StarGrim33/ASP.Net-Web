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
                description: "Стандартная уборка вашей квартиры, цена зависит от количества комнат и площади", cost: 5000,
                link: "https://super-cleaning-spb.ru/uploads/s/g/f/l/gflxywmvkvrh/img/full_H7gMciJT.jpg"),
                new(name: "Генеральная уборка квартиры", description: "Генеральная уборка вашей квартиры", cost: 8000,
                link: "https://krym-cleaning.ru/wp-content/uploads/2023/01/Kachestvennaya-uborka-dvuhkomnatnoj-kvartiry.jpg"),
                new(name: "Уборка поддерживающая", description: "Поддерживающая уборка квартиры", cost: 3000,
                link: "https://proprikol.ru/wp-content/uploads/2021/09/kartinki-uborka-kvartir-40.jpeg")
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
