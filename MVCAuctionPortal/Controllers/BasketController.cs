using System.Linq;
using System.Threading.Tasks;
using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAuctionPortal.Models;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class BasketController : Controller
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(ILogger<BasketController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        public async Task<IActionResult> GetBasket(int id)
        {
            id = 2;
            await _basketService.CreateBasket(id);
            var basket = await _basketService.GetBasketByUserId(id);
            var basketViewModel = new BasketViewModel
            {
                BasketId = basket.BasketID,
                SummaryPrice = basket.SummaryPrice,
                BasketAuctions = basket.BasketAndAuctions.Select(ba => new BasketAuctionViewModel
                {
                    AuctionId = ba.AuctionId,
                    Title = ba.Auction.Title,
                    Price = ba.Auction.Price,
                    Quantity = ba.Quantity,
                    Selected = ba.Selected
                }).ToList()
            };

            return View(basketViewModel);
        }

        public async Task<IActionResult> AddToBasket(int auctionId, int quantity)
        {
            int userId = 2;


            await _basketService.AddAuctionToBasket(userId, auctionId, quantity);
            return RedirectToAction(nameof(GetBasket), new { id = 2 });

        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromBasket(int auctionId)
        {
            int userId = 2;

            await _basketService.RemoveAuctionFromBasket(userId, auctionId);

            return RedirectToAction("GetBasket", new { id = userId });
        }

        public async Task<IActionResult> UpdateBasket(IFormCollection form)
        {
            int userId = 2;

            var auctionIdList = form["AuctionId[]"].Select(int.Parse).ToList();
            var quantityList = form["Quantity[]"].Select(int.Parse).ToList();

            for (int i = 0; i < auctionIdList.Count; i++)
            {
                int auctionId = auctionIdList[i];
                int quantity = quantityList[i];

                await _basketService.UpdateAuctionQuantityInBasket(userId, auctionId, quantity);
            }

            return RedirectToAction("GetBasket", new { id = userId });
        }

        public ActionResult OrderForm(IFormCollection form)
        {
            int userId = 2;

            var auctionIds = form["AuctionId[]"].Select(int.Parse).ToList();
            var quantities = form["Quantity[]"].Select(int.Parse).ToList();

            return RedirectToAction("OrderForm", "Order", new { auctionIds = auctionIds, quantities = quantities });
        }

    }
}