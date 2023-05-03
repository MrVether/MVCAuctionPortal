using AuctionPortal.Models;

namespace MVCAuctionPortal.Models
{
    public class BasketAndAuction
    {

        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public bool Selected { get; set; }
        public int Quantity { get; set; }
    }

}
