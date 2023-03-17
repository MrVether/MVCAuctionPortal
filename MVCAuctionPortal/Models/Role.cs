using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Role
    {
        [Key]
        [Required]
        public int RoleID { get; set; }
        public string Name { get; set; }
    }
}
