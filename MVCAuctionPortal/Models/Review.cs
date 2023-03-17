using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int ReviewID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
