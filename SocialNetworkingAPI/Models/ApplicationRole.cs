using Microsoft.AspNetCore.Identity;

namespace SocialNetworkingAPI.Models
{
    public class ApplicationRole:IdentityRole<int>
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
