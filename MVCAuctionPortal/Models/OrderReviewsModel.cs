namespace MVCAuctionPortal.ViewModels
{
    public class OrderReviewsViewModel
    {
        public int OrderId { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }

    public class ReviewViewModel
    {
        public int AuctionID { get; set; }
        public string AuctionName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPositive { get; set; }
    }
}