using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionPortal.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int AuctionId { get; set; }

        [Required]
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("AuctionId")]
        public virtual Auction Auction { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}