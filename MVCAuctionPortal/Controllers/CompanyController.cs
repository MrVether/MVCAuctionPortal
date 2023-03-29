using AuctionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using MVCAuctionPortal.Models;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;
        private readonly IAddressService _addressService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService, IAddressService addressService)
        {
            _logger = logger;
            _companyService = companyService;
            _addressService = addressService;
        }
        public IActionResult GetByUserID([FromRoute] int? id)
        {
            var company = _companyService.GetCompaniesForUser(id);
            return View(company);
        }

        public IActionResult Edit()
        {
            var companies = _companyService.GetCompaniesForUser(2);
            var company = companies.FirstOrDefault();
            var viewModel = new EditCompanyViewModel
            {
                Company = company,
                Address = _addressService.GetAddressById(company.CompanyAddressID)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCompanyViewModel viewModel)
        {
         
                var company = new Company
                {
                    CompanyID = viewModel.Company.CompanyID,
                    Name = viewModel.Company.Name,
                    Nip = viewModel.Company.Nip,
                    Regon = viewModel.Company.Regon,
                    CountryEstablishment = viewModel.Company.CountryEstablishment,
                    DateOfEstablishment = viewModel.Company.DateOfEstablishment,
                    Description = viewModel.Company.Description,
                    CompanyAddressID = viewModel.Address.AddressID
                };

                var address = new Address
                {
                    AddressID = viewModel.Address.AddressID,
                    Street = viewModel.Address.Street,
                    HouseNumber = viewModel.Address.HouseNumber,
                    LocalNumber = viewModel.Address.LocalNumber,
                    ZipCode = viewModel.Address.ZipCode
                };

                _companyService.Update(company);
                _addressService.Update(address);

                return RedirectToAction(nameof(GetByUserID), new { id = 2 });
            

        }
    }
}
