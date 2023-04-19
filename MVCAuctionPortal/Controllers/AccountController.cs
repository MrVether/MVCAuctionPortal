using AuctionPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using System.Security.Claims;

namespace MVCAuctionPortal.Controllers
{
    public class AccountController : Controller
    {
      

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

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IRoleService roleService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleService = roleService;
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
        public IActionResult ExternalUserRegistration(string email)
        {
            var model = new ExternalUserRegistrationViewModel { Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalUserRegistration(ExternalUserRegistrationViewModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Error: user with this email address already exists.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Nip = model.Nip,
                    RegistationDate = DateTime.Now,
                    AddressID = 1,
                };

                var createUserResult = await _userManager.CreateAsync(user);

                if (createUserResult.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(model.Email);

                    await _roleService.AssignRoleToUserAsync(user.Id, 2);

                    if (user != null)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Auction");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error: user not found.");
                    }
                }

            }

            return View(model);
        }


    }
}
