using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class ServiceController : Controller
    {
        private ProductRepository _services;

        public ServiceController()
        {
            _services = new ProductRepository();
        }

        public string? Index(int id)
        {
            var service = _services.TryGetService(id);

            return service == null ? $"Услуги с таким id нет" : service?.ToString();
        }
    }
}
