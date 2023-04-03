using System.ComponentModel.DataAnnotations;
using AuctionPortal.Models;

namespace MVCAuctionPortal.Models;

public class Basket
{
    [Key]
    [Required]
    public int BasketID { get; set; }
    public int NumberOfItems { get; set; }
    public float SummaryPrice { get; set; }
    public int UserID { get; set; }
    public User User { get; set; }
    public List<BasketAndAuction> BasketAndAuctions { get; set; }
}