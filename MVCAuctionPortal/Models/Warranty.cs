using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Warranty
    {
        [Key]
        [Required]
        public int WarrantyID { get; set; }
        public string Name { get; set; }
        public int Durantion { get; set; }
        public string Description { get; set; }
    }
}
