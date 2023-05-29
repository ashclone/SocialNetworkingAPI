using SocialNetworkingAPI.Models;

namespace SocialNetworkingAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(int id);
        Task<ApplicationUser> GetUserByNameAsync(string name);
        void UpdateUserAsync(ApplicationUser user);
        Task<string> GetUserGender(string userName);
    }
}
