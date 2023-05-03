using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using MVCAuctionPortal.ViewModels;
using ServicesAndInterfacesLibary.Services;

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
        private readonly IOrderService _orderService;


        public AuctionController(ILogger<AuctionController> logger, IAuctionService auctionService,
            IItemService itemService, IWarrantyService warrantyService, ISubCategoryService subCategoryService,
            IReviewService reviewService, UserManager<User> userManager, IOrderService orderService)
        {
            _logger = logger;
            _auctionService = auctionService;
            _itemService = itemService;
            _warrantyService = warrantyService;
            _subCategoryService = subCategoryService;
            _reviewService = reviewService;
            _userManager = userManager;
            _orderService = orderService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var allAuctions = _auctionService.GetAllAuctions();

            if (allAuctions == null || !allAuctions.Any())
            {
                return NotFound();
            }

            var auctionViewModels = allAuctions.Select(a => new AuctionAndWarrantyViewModel()
            {
                Auction = a,
                Warranty = _warrantyService.GetWarrantyById(a.WarrantyID)
            }).ToList();

            var random = new Random();
            auctionViewModels = auctionViewModels.OrderBy(a => random.Next()).ToList();

            var selectedAuctionViewModels = auctionViewModels.Take(6).ToList();

            return View(selectedAuctionViewModels);
        }


        [HttpGet]
        [Authorize(Roles = "Seller,Admin")]
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
        [Authorize(Roles = "Seller,Admin")]

        public ActionResult Create(AuctionViewModel model)
        {
            var userId = _userManager.GetUserId(User);

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
                    EndDate = model.EndDate,
                    Price = model.Price,
                    Pieces = model.Pieces,
                    SubCategoryID = model.SubCategoryID,
                    ItemID = model.ItemID,
                    WarrantyID = model.WarrantyID,
                    ImageURL = model.ImageURL,
                    UserID= Int32.Parse(userId)
                };
                _auctionService.AddAuction(newAuction);



                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Seller,Admin")]
        public IActionResult Delete([FromRoute] int? id)
        {
            var auction = _auctionService.GetAuctionById(id);
            var userId = _userManager.GetUserId(User);

            if (auction.UserID != int.Parse(userId))
            {
                return Unauthorized(); 
            }

            _auctionService.DeleteAuction(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Seller,Admin")]
        public IActionResult DeleteConfirmation(int id)
        {
            var auction = _auctionService.GetAuctionById(id);
            var userId = _userManager.GetUserId(User);

            if (auction.UserID != int.Parse(userId))
            {
                return Unauthorized(); 
            }

            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        [Authorize(Roles = "Seller,Admin")]
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

                if (auction.UserID != int.Parse(userId))
                {
                    return Unauthorized();
                }

                return View(auction);
            }
        }

        [Authorize(Roles = "Seller,Admin")]
        [HttpPost]
        public IActionResult Edit(Auction auction)
        {
            var userId = _userManager.GetUserId(User);

            if (auction.UserID != int.Parse(userId))
            {
                return Unauthorized();
            }

            _auctionService.UpdateAuction(auction);
            return RedirectToAction("UserPanel", "User");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var item = _itemService.GetItemById(id);
            var auction = _auctionService.GetAuctionByItemId(id);
            var reviews = _reviewService.GetReviewsByAuctionId(auction.AuctionID);
            ViewData["ImageUrl"] = auction.ImageURL;
            ViewData["Reviews"] = reviews;
            return View(item);
        }

        [AllowAnonymous]
        public IActionResult SubCategoryAuctionsList([FromRoute] int id)
        {
            var auctions = _auctionService.GetAuctionBySubCategory(id).ToList();

            var auctionViewModels = auctions.Select(a => new AuctionAndWarrantyViewModel()
            {
                Auction = a,
                Warranty = _warrantyService.GetWarrantyById(a.WarrantyID)
            }).ToList();

            var auctionAndWarrantyViewModels = auctions.Select(auction => new AuctionAndWarrantyViewModel
            {
                Auction = auction,
                Warranty = auction.Warranty != null
                    ? _warrantyService.GetWarrantyById(auction.Warranty.WarrantyID)
                    : null
            }).ToList();

            return View(auctionAndWarrantyViewModels);
        }


        [Authorize(Roles = "User,Seller,Admin")]

        [HttpGet]
        public IActionResult AddReviews(int orderId)
        {
            var order = _orderService.GetOrderDetailsById(orderId);
            if (order == null)
            {
                return NotFound();
            }

            var model = new OrderReviewsViewModel
            {
                OrderId = orderId,
                Reviews = order.OrderItems.Select(oi => new ReviewViewModel
                {
                    AuctionID = oi.Auction.AuctionID,
                    AuctionName = oi.Auction.Title
                }).ToList()
            };

            return View(model);
        }



        [Authorize(Roles = "User,Seller,Admin")]
        [HttpPost]
        public IActionResult AddReviews(OrderReviewsViewModel model)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }


            foreach (var reviewViewModel in model.Reviews)
            {
                var review = new Review
                {
                    AuctionID = reviewViewModel.AuctionID,
                    UserID = int.Parse(userId),
                    Title = reviewViewModel.Title,
                    Description = reviewViewModel.Description,
                    IsPositive = reviewViewModel.IsPositive
                };

                _reviewService.Create(review);
            }

            return RedirectToAction("UserOrders", "Order");


            return View(model);
        }


    }
}