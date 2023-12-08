using Diamond_Cleaning.Interfaces;
using Diamond_Cleaning.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View(orders);
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
