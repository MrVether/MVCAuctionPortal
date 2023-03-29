using AuctionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly IWarrantyService _warrantyService;
        public WarrantyController(IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Warranty warranty)
        {
            _warrantyService.Create(warranty);
            return RedirectToAction("ListOfWarranties");
        }



        public IActionResult Edit([FromRoute] int id)
        {
            var warranty = _warrantyService.GetWarrantyById(id);
            return View(warranty);
        }

        public IActionResult ListOfWarranties()
        {
         var warranty =  _warrantyService.GetAllWarranties();
            return View(warranty);
        }
       
        [HttpPost]
        public IActionResult Edit(Warranty warranty)
        {
           _warrantyService.Update(warranty);
           return RedirectToAction("ListOfWarranties");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id)
        {
            _warrantyService.Delete(id);
            return RedirectToAction("ListOfWarranties");
        }
    }
}
