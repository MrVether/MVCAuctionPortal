using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionPortal.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int ReviewID { get; set; }

        [Required]
        public int AuctionID { get; set; }

        [Required]
        public int UserID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsPositive { get; set; }

        [ForeignKey("AuctionID")]
        public virtual Auction Auction { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}