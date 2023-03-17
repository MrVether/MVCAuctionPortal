using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressID { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }

        public string? LocalNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }

}

