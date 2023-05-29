using SocialNetworkingAPI.Models;

namespace SocialNetworkingAPI.Services.Interface
{
    public interface ITokenServices
    {
        Task<string> GetTokenAsync(ApplicationUser applicationUser);
    }
}
