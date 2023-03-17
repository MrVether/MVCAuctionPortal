using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Coupon
    {
        [Key]
        [Required]
        public int CouponID { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required] public int NumberOfUses { get; set; } = 0;
    }
}
