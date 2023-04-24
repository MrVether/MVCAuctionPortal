using AuctionPortal.Models;

namespace MVCAuctionPortal.Models;

public class OrderViewModel
{
    public Order Order { get; set; }
    public List<int> AuctionIds { get; set; }
    public List<int> Quantities { get; set; }
    public decimal DiscountPercentage { get; set; }
}