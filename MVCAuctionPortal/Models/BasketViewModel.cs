namespace MVCAuctionPortal.Models
{
    public class BasketViewModel
    {
        public int BasketId { get; set; }
        public float SummaryPrice { get; set; }
        public List<BasketAuctionViewModel> BasketAuctions { get; set; }
    }

}
