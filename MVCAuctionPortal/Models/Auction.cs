using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MVCAuctionPortal.Models;
using ServicesAndInterfacesLibary.Models;

namespace AuctionPortal.Models
{
    public class Auction
    {
        [Key]
        [Required]
        public int AuctionID { get; set; }
        public string Title { get; set; }
        public bool BuyItNow { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public int Pieces { get; set; }
        public int PurchaseCounter { get; set; }
        public int SubCategoryID { get; set; }
        public int ItemID { get; set; }
        public int WarrantyID { get; set; }
        public int ReviewID { get; set; }
        public int UserID { get; set; }

        public string ImageURL { get; set; }

        public User User { get; set; }
        public SubCategory SubCategory { get; set; }
        public Item Item { get; set; }
        public Warranty Warranty { get; set; }
        public Review Review { get; set; }
    }
}