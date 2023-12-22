using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;

namespace Diamond_Cleaning.Views.Shared.Components.CalculateFavouriteServiceCount
{
    public class CalculateFavouriteServiceCount : ViewComponent
    {
        private readonly IFavouriteRepository _favouriteRepository;

        public CalculateFavouriteServiceCount(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var servicesCount = _favouriteRepository.GetAll(Constants.UserId).Count();
            return View("FavouriteServicesCountView", servicesCount);
        }
    }
}
