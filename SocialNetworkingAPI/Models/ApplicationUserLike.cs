using System.ComponentModel.DataAnnotations;

namespace SocialNetworkingAPI.Models
{
    public class ApplicationUserLike
    {
        public ApplicationUser Sender { get; set; }

        public int SenderId { get; set; }

        public ApplicationUser Receiver { get; set; }

        public int ReceiverId { get; set; }
    }
}
