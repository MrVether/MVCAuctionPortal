
using AuctionPortal.Models;
using AuctionPortal.Models.ViewModels;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserController(ILogger<UserController> logger, IAuctionService auctionService, ICompanyService companyService, ICouponService couponService, IAddressService addressService
        , IItemService itemService, IReviewService reviewService, IWarrantyService warrantyService, IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager)
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
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> UserPanel()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = _userService.GetUserById(int.Parse(userId));
            List<Auction> auctions = _auctionService.GetAuctionsForUser(user.Id);
            IEnumerable<Company> companies = _companyService.GetCompaniesForUser(user.Id);
            IEnumerable<Coupon> coupons = _couponService.GetCouponsForUser(user);
            IEnumerable<Address> addresses = _addressService.GetAddressesForUser(user);
            var reviews = _reviewService.GetReviewById(user.Id);

            var viewModel = new UserPanelViewModel
            {
                Auctions = auctions,
                Companies = companies,
                Coupons = coupons,
                Addresses = addresses,
                IsUserSeller = await IsUserSellerAsync()
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult UpdateProfile()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = _userService.GetUserById(int.Parse(userId));
            var viewModel = new UpdateUserViewModel
            {
                UserID = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Nip = user.Nip
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUserProfile(model);

                return RedirectToAction("UserDetails", "User");
            }

            return View(model);
        }
        public IActionResult UserDetails()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var userDetails = _userService.GetUserDetails(int.Parse(userId));
            return View(userDetails);
        }

        public async Task<bool> IsUserSellerAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return false;
            }
            var roles = await _userManager.GetRolesAsync(user);
            return roles.Contains("Seller");
        }



    }

}

