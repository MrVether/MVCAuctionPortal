﻿using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface ICouponService
{
    int Create(Coupon dto);
    int Delete(int id);
    void Update(Coupon coupon);
    IEnumerable<Coupon> GetAllCoupons();
    Coupon GetCouponById(int id);
}