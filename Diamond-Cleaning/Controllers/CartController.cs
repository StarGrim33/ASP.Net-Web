using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly CartsRepository _cartsRepository;

        public CartController()
        {
            _productRepository = new();
            _cartsRepository = new();
        }

        public void AddItem(int id)
        {
            try
            {
                Service item = _productRepository.TryGetService(id);

                if(item != null)
                {
                    _cartsRepository.AddItem(item);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Index()
        {

        }
    }
}
