using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? Nip { get; set; }
        public string Password { get; set; }
        public DateTime RegistationDate { get; set; }
        public int RoleID { get; set; }
        public int? CouponID { get; set; }
        public int AddressID { get; set; }
        public int? CompanyID { get; set; }

        public virtual Role Roles { get; set; }
        public virtual Coupon Coupons { get; set; }
        public virtual Address Address { get; set; }
        public virtual Company Companies { get; set; }


    }
}
