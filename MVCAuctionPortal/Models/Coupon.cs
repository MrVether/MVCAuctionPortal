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
        [Range(1, 100)]
        public int DiscountPercentage { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }


        [Required]
        public DateTime ExpireDate { get; set; }

        [Required] public int NumberOfUses { get; set; } = 0;

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}