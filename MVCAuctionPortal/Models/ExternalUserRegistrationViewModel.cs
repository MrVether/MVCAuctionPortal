using System.ComponentModel.DataAnnotations;

namespace MVCAuctionPortal.Models
{
    public class ExternalUserRegistrationViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }

        [Display(Name = "I want to be a Seller")]
        public bool IsSeller { get; set; }
        public int UserId { get; set; }


    }

}
