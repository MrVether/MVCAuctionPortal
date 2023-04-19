using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models.ViewModels
{
    public class UpdateUserViewModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        public int? Nip { get; set; }
    }
}
