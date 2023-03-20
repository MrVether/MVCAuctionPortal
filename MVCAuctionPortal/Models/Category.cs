using System.ComponentModel.DataAnnotations;
using AuctionPortal.Models;

namespace MVCAuctionPortal.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string ImageURL { get; set; }


        public ICollection<Auction> Auctions { get; set; }
        public IEnumerable<SubCategory> SubCategory { get; set; }
    }

}
