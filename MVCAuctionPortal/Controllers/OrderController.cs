using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace MVCAuctionPortal.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;


        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public IActionResult Details(int id)
        {
            Order order = _orderService.GetOrderDetailsById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult UserOrders()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            List<Order> orders = _orderService.GetOrdersByUserId(int.Parse(userId));
            return View(orders);
        }

        [HttpGet]
        public ActionResult OrderForm(List<int> auctionIds, List<int> quantities)
        {
            var orderViewModel = new OrderViewModel
            {
                AuctionIds = auctionIds,
                Quantities = quantities
            };

            return View(orderViewModel);
        }

        public async Task<IActionResult> Payment(int id)
        {
            var order = await _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(IFormCollection form)
        {
            var order = new Order
            {
                FirstName = form["FirstName"],
                Surname = form["Surname"],
                City= form["City"],
                Street = form["Street"],
                HouseNumber = form["HouseNumber"],
                LocalNumber = form["LocalNumber"],
                ZipCode = form["ZipCode"],
                PaymentMethod = form["PaymentMethod"],
            };

            var auctionIds = form["AuctionIds[]"].Select(int.Parse).ToList();
            var quantities = form["Quantities[]"].Select(int.Parse).ToList();

            await _orderService.CreateOrderAsync(order, auctionIds, quantities);
            return RedirectToAction("Payment", new { id = order.OrderID });
        }
        public async Task<IActionResult> PaymentSuccess(int id, string paymentMethod)
        {
            var order = await _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            await _orderService.UpdateOrderStatusAsync(id, "Payment success", paymentMethod);

            return View(order);
        }
        public async Task<IActionResult> PaymentFailed(int id)
        {
           
            return View();
        }




    }
}
