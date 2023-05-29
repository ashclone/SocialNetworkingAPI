using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetworkingAPI.Models;

namespace SocialNetworkingAPI.data
{
    public static class DataSeed
    {
        public static async Task Seed(UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {
            if (await _userManager.Users.AnyAsync()) return;
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole{Name = "Member"},
                new ApplicationRole{Name = "Admin"},
                new ApplicationRole{Name = "Moderator"},
            };
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }
            var admin = new ApplicationUser {
                Name="Admin",
                Bio="Admin",
                City="Admin",
                Country="Admin",
                Gender="Admin",
                Interest = "Admin",
                BirthDate = DateTime.UtcNow,
                UserName = "admin"
            };
            try
            {
            await _userManager.CreateAsync(admin , "Admin@123");
            await _userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
