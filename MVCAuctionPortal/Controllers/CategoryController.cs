using AuctionPortal.Services;
using Microsoft.AspNetCore.Mvc;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
        public IActionResult Index()
        {
            var allCategories = _categoryService.GetAllCategories();
            return View(allCategories);
        }
        public IActionResult SubCategories([FromRoute] int id)
        {
            var allSubCategories = _subCategoryService.GetAllSubCategories(id);
            return View(allSubCategories);
        }


    }
}
