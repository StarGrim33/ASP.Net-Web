using Diamond_Cleaning.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;

namespace Diamond_Cleaning.Controllers
{
    [Authorize]
    public class FavouriteController : Controller
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IServicesRepository _servicesRepository;

        public FavouriteController(IFavouriteRepository favouriteRepository, IServicesRepository servicesRepository)
        {
            _favouriteRepository = favouriteRepository;
            _servicesRepository = servicesRepository;
        }

        public IActionResult Index()
        {
            var services = _favouriteRepository.GetAll(User.Identity.Name);
            return View(Mapping.ToServiceViewModels(services));
        }

        public IActionResult Add(Guid serviceId)
        {
            var service = _servicesRepository.TryGetService(serviceId);

            if (service != null)
            {
                _favouriteRepository.Add(User.Identity.Name, service);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Remove(Guid serviceId) 
        { 
            _favouriteRepository.Remove(User.Identity.Name, serviceId); 
            return RedirectToAction(nameof(Index));
        }
    }
}
