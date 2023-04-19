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

        public int? Nip { get; set; }
    }

}
