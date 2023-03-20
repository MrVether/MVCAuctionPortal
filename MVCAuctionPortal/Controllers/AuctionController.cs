using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using System.Diagnostics;
using AuctionPortal.Models;
using AuctionPortal.Services;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class AuctionController : Controller
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly IAuctionService _auctionService;
        private readonly IItemService _itemService;

        public AuctionController(ILogger<AuctionController> logger, IAuctionService auctionService, IItemService itemService)
        {
            _logger = logger;
            _auctionService = auctionService;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var allAuctions =  _auctionService.GetAllAuctions();
            return View(allAuctions);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit([FromRoute] int id)
        {
            var auction = _auctionService.GetAuctionById(id);

            return View(auction);
        }
        [HttpPost]
        public IActionResult Edit(Auction auction)
        {

_auctionService.UpdateAuction(auction);
            return View(auction);
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var item = _itemService.GetItemById(id);
            return View(item);
        }
        public IActionResult SubCategoryAuctionsList([FromRoute] int id)
        {
            var auction = _auctionService.GetAuctionBySubCategory(id);
            return View(auction);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}