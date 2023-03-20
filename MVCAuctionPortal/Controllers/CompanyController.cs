using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        public IActionResult GetByUserID([FromRoute] int id)
        {
            var company = _companyService.GetCompanyByUserId(id);
            return View(company);
        }
    }
}
