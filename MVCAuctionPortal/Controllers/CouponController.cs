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
        public IActionResult Create(Coupon coupon)
        {
            _couponService.Create(coupon);
            return RedirectToAction("ListOfCoupons");
        }

        public IActionResult Edit(int id)
        {
            var coupon = _couponService.GetCouponById(id);
            return View(coupon);
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