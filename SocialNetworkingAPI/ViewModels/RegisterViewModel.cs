using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SocialNetworkingAPI.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}
