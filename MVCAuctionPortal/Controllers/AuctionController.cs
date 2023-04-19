using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IReviewService _reviewService;
        private readonly UserManager<User> _userManager;


        public AuctionController(ILogger<AuctionController> logger, IAuctionService auctionService, IItemService itemService, IWarrantyService warrantyService, ISubCategoryService subCategoryService,IReviewService reviewService, UserManager<User> userManager)
        {
            _logger = logger;
            _auctionService = auctionService;
            _itemService = itemService;
            _warrantyService = warrantyService;
            _subCategoryService = subCategoryService;
            _reviewService= reviewService;
            _userManager = userManager;
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
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null)
            {
                var auctions = _auctionService.GetAuctionsForUser(int.Parse(userId));
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
            var auction = _auctionService.GetAuctionByItemId(id);
            var reviews = _reviewService.GetReviewsByAuctionId(auction.AuctionID);
            ViewData["Reviews"] = reviews;
            return View(item);
        }

        public IActionResult SubCategoryAuctionsList([FromRoute] int id)
        {
            var auction = _auctionService.GetAuctionBySubCategory(id);
            return View(auction);
        }
        [HttpGet]
        public IActionResult AddReview(int auctionId)
        {
            var review = new Review { AuctionID = auctionId };
            return View(review);
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            review.UserID = int.Parse(userId); 
                _reviewService.Create(review);
                return RedirectToAction("UserOrders", "Order"); 
            
            return View(review);
        }
    }
}