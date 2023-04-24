using System.Linq;
using System.Threading.Tasks;
using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly ICouponService _couponService;


        public BasketController(ILogger<BasketController> logger, IBasketService basketService,UserManager<User> userManager, ICouponService couponService)
        {
            _logger = logger;
            _basketService = basketService;
            _userManager = userManager;
            _couponService = couponService;
        }

        public async Task<IActionResult> GetBasket()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await _basketService.CreateBasket(int.Parse(userId));
            var basket = await _basketService.GetBasketByUserId(int.Parse(userId));

            var user = await _userManager.FindByIdAsync(userId);
            var availableCoupons = user != null ? _couponService.GetCouponsForUser(user).ToList() : new List<Coupon>();

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
                }).ToList(),
                AvailableCoupons = availableCoupons 
            };

            return View(basketViewModel);
        }



        public async Task<IActionResult> AddToBasket(int auctionId, int quantity)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }


            await _basketService.AddAuctionToBasket(int.Parse(userId), auctionId, quantity);
            return RedirectToAction(nameof(GetBasket));

        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromBasket(int auctionId)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await _basketService.RemoveAuctionFromBasket(int.Parse(userId), auctionId);

            return RedirectToAction("GetBasket", new { id = userId });
        }

        public async Task<IActionResult> UpdateBasket(IFormCollection form)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var auctionIdList = form["AuctionId[]"].Select(int.Parse).ToList();
            var quantityList = form["Quantity[]"].Select(int.Parse).ToList();

            for (int i = 0; i < auctionIdList.Count; i++)
            {
                int auctionId = auctionIdList[i];
                int quantity = quantityList[i];

                await _basketService.UpdateAuctionQuantityInBasket(int.Parse(userId), auctionId, quantity);
            }

            return RedirectToAction("GetBasket", new { id = userId });
        }

        public ActionResult OrderForm(IFormCollection form)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var auctionIds = form["AuctionId[]"].Select(int.Parse).ToList();
            var quantities = form["Quantity[]"].Select(int.Parse).ToList();
            decimal discountPercentage = decimal.Parse(form["DiscountPercentage"]);

            return RedirectToAction("OrderForm", "Order", new { auctionIds = auctionIds, quantities = quantities, discountPercentage });
        }


    }
}