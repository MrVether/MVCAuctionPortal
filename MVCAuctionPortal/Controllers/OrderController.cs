using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;

namespace MVCAuctionPortal.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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



    }
}
