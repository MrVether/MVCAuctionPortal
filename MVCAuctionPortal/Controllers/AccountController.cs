using AuctionPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using MVCAuctionPortal.ViewModels;
using ServicesAndInterfacesLibary.Services;
using System.Security.Claims;

namespace MVCAuctionPortal.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Auction");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IRoleService _roleService;
        private readonly ICompanyService _companyService;


        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager,
            IRoleService roleService, ICompanyService companyService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleService = roleService;
            _companyService = companyService;

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SellerRegistration()
        {
            var model = new SellerRegistrationViewModel();
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback()
        {


            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result =
                await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                    isPersistent: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Auction");

            }

            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    var addLoginResult = await _userManager.AddLoginAsync(existingUser, info);
                    if (addLoginResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(existingUser, isPersistent: false);
                        return RedirectToAction("Index", "Auction");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error adding external login for existing user.");
                        return View("Login");
                    }
                }

                var viewModel = new ExternalUserRegistrationViewModel { Email = email };

                TempData["Email"] = email;
                return View("ExternalUserRegistration", viewModel);
            }

        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult ExternalUserRegistration(string email)
        {
            var model = new ExternalUserRegistrationViewModel { Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalUserRegistration(ExternalUserRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    RegistationDate = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    int defaultRoleId = 2;
                    await _roleService.AssignRoleToUserAsync(user.Id, defaultRoleId, model.IsSeller);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (model.IsSeller)
                    {
                        return RedirectToAction("RegisterCompany", "Company", new { email = model.Email });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Auction");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


    }
}
