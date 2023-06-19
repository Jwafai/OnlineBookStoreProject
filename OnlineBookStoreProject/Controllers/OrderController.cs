using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreProject.Repositries.Abstract;
using System.Diagnostics;

namespace OnlineBookStoreProject.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
        private readonly IUserOrderRepository _userOrderRepo;

        public OrderController(IUserOrderRepository userOrderRepo)
        {
            _userOrderRepo = userOrderRepo;
        }
        public async Task<IActionResult> UserOrders()
        {
            var orders = await _userOrderRepo.UserOrders(0);
            return View(orders);
        }
        public IActionResult Index(int? statusId)
        {
            var order = _userOrderRepo.UserOrders(statusId);
            return View(order);
        }
    }
}