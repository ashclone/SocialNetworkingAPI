using Microsoft.AspNetCore.Identity;

namespace SocialNetworkingAPI.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string Gender { get; set; }
        public string? Interest { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<ApplicationUserLike> SenderLikes { get; set; }
        public ICollection<ApplicationUserLike> ReceiverLikes { get; set; }
        public ICollection<Message> SenderMessages { get; set; }
        public ICollection<Message> ReceiverMessages { get; set; }
        public ICollection<Photo> Photots { get; set; }
        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
