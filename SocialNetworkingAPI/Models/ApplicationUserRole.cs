using Microsoft.AspNetCore.Identity;

namespace SocialNetworkingAPI.Models
{
    public class ApplicationUserRole:IdentityUserRole<int>
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
