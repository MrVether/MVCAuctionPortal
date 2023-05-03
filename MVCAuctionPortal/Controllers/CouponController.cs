using AuctionPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAndInterfacesLibary.Services;
using System.Security.Claims;

namespace MVCAuctionPortal.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Coupon coupon)
        {
            _couponService.Update(coupon);
            return RedirectToAction("ListOfCoupons");
        }
        [AllowAnonymous]
        public async Task<IActionResult> ListOfCoupons()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var coupons = await _couponService.GetCouponsForUser(userId);
            return View(coupons.ToList());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _couponService.Delete(id);
            return RedirectToAction("ListOfCoupons");
        }
    }
}