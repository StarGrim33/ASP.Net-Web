using Diamond_Cleaning.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    public class OrderController : Controller
    {
        private IOrdersRepository _ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IActionResult GetOrders()
        {
            var orders = _ordersRepository.GetAllOrders();
            var orderViewModels = Mapping.ToOrderViewModels(orders); // Преобразуем список заказов в соответствующие модели представления
            return View(orderViewModels); // Передаем преобразованный список моделей представления в представление
        }

        public IActionResult EditStatus(Guid id)
        {
            var orders = _ordersRepository.GetAllOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == id);
            return View(currentOrder);
        }

        [HttpPost]
        public IActionResult EditStatus(Guid Id, OrderStatuses Status)
        {
            var orders = _ordersRepository.GetAllOrders();
            Order? currentOrder = orders.FirstOrDefault(order => order.Id == Id);
            currentOrder.Status = Status;
            return RedirectToAction("GetOrders");
        }
    }
}
