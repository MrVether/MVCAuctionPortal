﻿using AuctionPortal.Models;

public class UserPanelViewModel
{
    public List<Auction> Auctions { get; set; }
    public IEnumerable<Company> Companies { get; set; }
    public IEnumerable<Coupon> Coupons { get; set; }
    public IEnumerable<Address> Addresses { get; set; }
    public List<Item> Items { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Warranty> Warranties { get; set; }
}