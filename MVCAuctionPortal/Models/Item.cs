using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int ItemID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(10)]
        public string Condition { get; set; }

        [StringLength(20)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Other { get; set; }
    }
}
