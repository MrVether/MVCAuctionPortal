using Microsoft.AspNetCore.Identity;

namespace AuctionPortal.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime RegistationDate { get; set; }
        public int? CompanyID { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual Company Companies { get; set; }

        public User()
        {
            Name = "Default";
            Surname = "Default";
            Coupons = new List<Coupon>();
        }
    }
}