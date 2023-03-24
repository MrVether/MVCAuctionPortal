using System.ComponentModel.DataAnnotations;
using AuctionPortal.Models;

namespace AuctionPortal.Models
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int OrderItemID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int AuctionID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Auction Auction { get; set; }
    }
}
