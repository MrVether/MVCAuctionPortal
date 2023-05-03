using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class ItemController : Controller
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly IAuctionService _auctionService;
        private readonly IItemService _itemService;
        private readonly UserManager<User> _userManager;



        public ItemController(ILogger<AuctionController> logger, IAuctionService auctionService,
            IItemService itemService, UserManager<User> userManager)
        {
            _logger = logger;
            _auctionService = auctionService;
            _itemService = itemService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult ListOfItems()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var auctions = _auctionService.GetAuctionsForUser(int.Parse(userId));
            var items = new List<Item>();

            foreach (var auction in auctions)
            {
                items.Add(auction.Item);
            }

            return View(items);
        }
        [Authorize(Roles = "Seller,Admin")]
        public IActionResult Edit([FromRoute] int? id)
        {

            var item = _itemService.GetItemById(id);
            return View(item);

        }
        [Authorize(Roles = "Seller,Admin")]

        [HttpPost]
        public IActionResult Edit(Item item)
        {

            _itemService.Update(item);
            return RedirectToAction("ListOfItems");
        }

        [HttpPost]
        [Authorize(Roles = "Seller,Admin")]

        public IActionResult Delete([FromRoute] int? id)
        {
            _itemService.Delete(id);
            return RedirectToAction("ListOfItems");
        }
        [Authorize(Roles = "Seller,Admin")]

        public IActionResult DeleteConfirmation(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

    }
}


