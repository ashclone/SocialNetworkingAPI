using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SocialNetworkingAPI.Models;
using SocialNetworkingAPI.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNetworkingAPI.Services
{
    public class TokenServices : ITokenServices
    {
        private UserManager<ApplicationUser> _userManager;

        private SymmetricSecurityKey symmetricSecurityKey;

        public TokenServices(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token"]));
        }

        public async Task<string> GetTokenAsync(ApplicationUser   applicationUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId , applicationUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName , applicationUser.UserName)
            };
            var roles = await _userManager.GetRolesAsync(applicationUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token= jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);


        }
    }
}
