
using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(ILogger<UserController> logger, IAuctionService auctionService, ICompanyService companyService, ICouponService couponService, IAddressService addressService
        , IItemService itemService, IReviewService reviewService, IWarrantyService warrantyService, IUserService userService)
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
      
    }

}

