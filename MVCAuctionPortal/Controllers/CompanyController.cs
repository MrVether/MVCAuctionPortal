using AuctionPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using MVCAuctionPortal.ViewModels;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;
        private readonly UserManager<User> _userManager;


        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService, UserManager<User> userManager)
        {
            _logger = logger;
            _companyService = companyService;
            _userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCompany(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new SellerRegistrationViewModel { UserId = user.Id.ToString() };
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCompany(SellerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var company = new Company
                    {
                        Name = model.Company.Name,
                        Nip = model.Company.Nip,
                        Regon = model.Company.Regon,
                        CountryEstablishment = model.Company.CountryEstablishment,
                        DateOfEstablishment = model.Company.DateOfEstablishment,
                        Description = model.Company.Description,
                    };

                    _companyService.Create(company);

                    user.CompanyID = company.CompanyID;
                    await _userManager.UpdateAsync(user);

                    return RedirectToAction("Index", "Auction");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error: user not found.");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult GetByUserID([FromRoute] int? id)
        {
            var company = _companyService.GetCompaniesForUser(id);
            return View(company);
        }
        [Authorize(Roles = "Seller,Admin")]
        public IActionResult Edit()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _userManager.FindByIdAsync(userId).Result;
            var companies = _companyService.GetCompaniesForUser(int.Parse(userId));
            var company = companies.FirstOrDefault();

            if (company == null || user.CompanyID != company.CompanyID)
            {
                return Unauthorized(); // Return unauthorized if the company IDs do not match
            }

            var viewModel = new EditCompanyViewModel
            {
                Company = company,
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Seller,Admin")]
        public IActionResult Edit(EditCompanyViewModel viewModel)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _userManager.FindByIdAsync(userId).Result;
            var company = _companyService.GetCompanyById(viewModel.Company.CompanyID);

            if (company == null || user.CompanyID != company.CompanyID)
            {
                return Unauthorized(); // Return unauthorized if the company IDs do not match
            }

            company.Name = viewModel.Company.Name;
            company.Nip = viewModel.Company.Nip;
            company.Regon = viewModel.Company.Regon;
            company.CountryEstablishment = viewModel.Company.CountryEstablishment;
            company.DateOfEstablishment = viewModel.Company.DateOfEstablishment;
            company.Description = viewModel.Company.Description;

            _companyService.Update(company);

            return RedirectToAction(nameof(GetByUserID), new { id = userId });
        }

    }
}
