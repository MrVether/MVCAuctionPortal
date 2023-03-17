using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Models
{
    public class BasketAndAuction
    {
        public int BasketID { get; set; }
        public int AuctionID { get; set; }
        public int Quanity { get; set; }

        // Navigation properties
        public Basket Basket { get; set; }
        public Auction Auction { get; set; }
    }

}
