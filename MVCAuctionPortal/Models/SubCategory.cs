using ServicesAndInterfacesLibary.Models;
using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class SubCategory
    {
        [Key]
        [Required]
        public int SubCategoryID { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public Category Categories { get; set; }
    }
}
