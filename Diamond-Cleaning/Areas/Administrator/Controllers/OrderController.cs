using Diamond_Cleaning.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IActionResult GetOrders()
        {
            var orders = _ordersRepository.GetAllOrders();
            return View(orders.Select(x => Mapping.ToOrderViewModel(x)).ToList());
        }

        public IActionResult EditStatus(Guid id)
        {
            var orders = _ordersRepository.GetAllOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == id);
            return View(Mapping.ToOrderViewModel(currentOrder));
        }

        [HttpPost]
        public IActionResult EditStatus(Guid Id, OrderStatuses Status)
        {
            _ordersRepository.UpdateStatus(Id, Status);
            return RedirectToAction("GetOrders");
        }
    }
}
