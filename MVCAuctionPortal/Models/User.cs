using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Nip { get; set; }
        public DateTime RegistationDate { get; set; }
        public int? CouponID { get; set; }
        public int AddressID { get; set; }
        public int? CompanyID { get; set; }

        public virtual Coupon Coupons { get; set; }
        public virtual Address Address { get; set; }
        public virtual Company Companies { get; set; }

        public User()
        {
            Name = "Default";
            Surname = "Default";
            Nip = 0000000000;

        }
    }
}