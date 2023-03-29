using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using ServicesAndInterfacesLibary.Services;
using System.Diagnostics;

namespace MVCAuctionPortal.Controllers
{
    public class AuctionController : Controller
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly IAuctionService _auctionService;
        private readonly IItemService _itemService;
        private readonly IWarrantyService _warrantyService;
        private readonly ISubCategoryService _subCategoryService;

        public AuctionController(ILogger<AuctionController> logger, IAuctionService auctionService, IItemService itemService, IWarrantyService warrantyService, ISubCategoryService subCategoryService)
        {
            _logger = logger;
            _auctionService = auctionService;
            _itemService = itemService;
            _warrantyService = warrantyService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            var allAuctions = _auctionService.GetAllAuctions();
            return View(allAuctions);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new AuctionViewModel
            {
                Items = _itemService.GetAllItems(),
                Warranties = _warrantyService.GetAllWarranties(),
                SubCategories = _subCategoryService.GetAllSubCategories()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(AuctionViewModel model)
        {

            if (model.ItemID == 0 && !string.IsNullOrEmpty(model.NewItemName))
            {
                var newItem = new Item
                {
                    Name = model.NewItemName,
                    Description = model.NewItemDescription,
                    Manufacturer = model.NewItemManufacturer,
                    Condition = model.NewItemCondition,
                    Model = model.NewItemModel,
                    Other = model.NewItemOther
                };
                _itemService.Create(newItem);

                model.ItemID = newItem.ItemID;

            }

            {
                var newAuction = new Auction
                {
                    Title = model.Title,
                    BuyItNow = model.BuyItNow,
                    EndDate = model.EndDate,
                    Price = model.Price,
                    Pieces = model.Pieces,
                    SubCategoryID = model.SubCategoryID,
                    ItemID = model.ItemID,
                    WarrantyID = model.WarrantyID,
                    ImageURL = model.ImageURL
                };
                _auctionService.AddAuction(newAuction);



                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id)
        {
            _auctionService.DeleteAuction(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteConfirmation(int id)
        {
            var auction = _auctionService.GetAuctionById(id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            if (id == null)
            {
                var auctions = _auctionService.GetAuctionsForUser(2);
                return View("SellerAuctionList", auctions);
            }
            else
            {
                var auction = _auctionService.GetAuctionById(id);

                return View(auction);
            }
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
    }
}