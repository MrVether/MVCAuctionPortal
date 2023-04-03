namespace MVCAuctionPortal.Models
{
    public class BasketAuctionViewModel
    {
        public int AuctionId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool Selected { get; set; }
    }
}