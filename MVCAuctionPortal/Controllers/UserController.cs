/*
Jeżeli Sprzedawca:
Dodawanie aukcji
Edycja swoich aukcji
Edycja przedmiotów w aukcjach
Edycja informacji o sobie i swojej firmie
Dodawanie i edycja własnych gwarancji
Dodawanie własnych kuponów
Wszystkie akcje które ma zwykły user
    
Jeżeli user:
Obsługa zakupów
Obsługa koszyka
Dodawanie swoich ocen
Podgląd dostępnych kuponów
Edycja swoich danych.
*/


using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
  
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IAuctionService _auctionService;
        private readonly ICompanyService _companyService;
        private readonly ICouponService _couponService;
        private readonly IAddressService _addressService;
        private readonly IItemService _itemService;
        private readonly IReviewService _reviewService;
        private readonly IWarrantyService _warrantyService;

        public UserController(ILogger<UserController> logger, IAuctionService auctionService, ICompanyService companyService,ICouponService couponService, IAddressService addressService
        ,IItemService itemService, IReviewService reviewService, IWarrantyService warrantyService,IUserService userService)
        {
            _logger = logger;
            _auctionService = auctionService;
            _companyService = companyService;
            _couponService = couponService;
            _addressService = addressService;
            _itemService = itemService;
            _reviewService = reviewService;
            _warrantyService = warrantyService;
            _userService = userService;
        }
        public IActionResult UserPanel()
        {
            var tempUser = _userService.GetUserById(1);
            List<Auction> auctions = _auctionService.GetAuctionsForUser(tempUser.UserID);
            IEnumerable<Company> companies = _companyService.GetCompaniesForUser(tempUser.UserID);
            IEnumerable<Coupon> coupons = _couponService.GetCouponsForUser(tempUser);
            IEnumerable<Address> addresses = _addressService.GetAddressesForUser(tempUser);
            var reviews = _reviewService.GetReviewById(tempUser.UserID);

            var viewModel = new UserPanelViewModel
            {
                Auctions = auctions,
                Companies = companies,
                Coupons = coupons,
                Addresses = addresses,
            };

            return View(viewModel);
        }
        /*
        // Seller actions
            [HttpGet]
            public IActionResult AddAuction()
            {
                // Code for the AddAuction view
            }

            [HttpPost]
            public IActionResult AddAuction(Auction auction)
            {
                // Code for adding an auction
            }

            public IActionResult EditAuction(int id)
            {
                // Code for the EditAuction view
            }

            [HttpPost]
            public IActionResult EditAuction(Auction auction)
            {
                // Code for updating an auction
            }

            public IActionResult EditItem(int id)
            {
                // Code for the EditItem view
            }

            [HttpPost]
            public IActionResult EditItem(Item item)
            {
                // Code for updating an item
            }

            public IActionResult EditCompanyInfo()
            {
                // Code for the EditCompanyInfo view
            }

            [HttpPost]
            public IActionResult EditCompanyInfo(Company company)
            {
                // Code for updating company information
            }

            public IActionResult AddEditWarranty(int id = 0)
            {
                // Code for the AddEditWarranty view
            }

            [HttpPost]
            public IActionResult AddEditWarranty(Warranty warranty)
            {
                // Code for adding or updating a warranty
            }

            public IActionResult AddCoupon()
            {
                // Code for the AddCoupon view
            }

            [HttpPost]
            public IActionResult AddCoupon(Coupon coupon)
            {
                // Code for adding a coupon
            }

            // User actions
            public IActionResult ManagePurchases()
            {
                // Code for the ManagePurchases view
            }

            public IActionResult ManageCart()
            {
                // Code for the ManageCart view
            }

            public IActionResult AddReview()
            {
                // Code for the AddReview view
            }

            [HttpPost]
            public IActionResult AddReview(Review review)
            {
                // Code for adding a review
            }

            public IActionResult ViewCoupons()
            {
                // Code for the ViewCoupons view
            }

            public IActionResult EditUserDetails()
            {
                // Code for the EditUserDetails view
            }

            [HttpPost]
            public IActionResult EditUserDetails(User user)
            {
                // Code for updating user details
            }
          */
    }

}

