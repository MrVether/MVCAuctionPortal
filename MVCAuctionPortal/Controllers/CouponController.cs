using AuctionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesAndInterfacesLibary.Services;

namespace MVCAuctionPortal.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Coupon coupon = new Coupon
                {
                    Name = formCollection["Name"],
                    Description = formCollection["Description"],
                    ExpireDate = DateTime.Parse(formCollection["ExpireDate"]),
                    DiscountPercentage = int.Parse(formCollection["DiscountPercentage"]),
                    NumberOfUses = int.Parse(formCollection["NumberOfUses"])

                };

                string userEmail = formCollection["UserEmail"];

                bool created = await _couponService.CreateUserCouponAsync(coupon, userEmail);
                if (created)
                {
                    return RedirectToAction("ListOfCoupons");
                }
                ModelState.AddModelError("UserEmail", "User not found with the provided email.");
            }
            return RedirectToAction("ListOfCoupons");
        }

        [HttpPost]
        public IActionResult Edit(Coupon coupon)
        {
            _couponService.Update(coupon);
            return RedirectToAction("ListOfCoupons");
        }

        public IActionResult ListOfCoupons()
        {
            var coupons = _couponService.GetAllCoupons();
            return View(coupons);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _couponService.Delete(id);
            return RedirectToAction("ListOfCoupons");
        }
    }
}