using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Nip { get; set; }

        [StringLength(15)]
        public string Regon { get; set; }

        [Required]
        [StringLength(30)]
        public string CountryEstablishment { get; set; }

        [Required]
        public DateTime DateOfEstablishment { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CompanyAddressID { get; set; }

        public Address CompanyAddress { get; set; }
    }
}
