using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetworkingAPI.Models;
using SocialNetworkingAPI.Services.Interface;
using SocialNetworkingAPI.ViewModels;

namespace SocialNetworkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IMapper _mapper;
        private ITokenServices _tokenServices;

        public AccountsController(UserManager<ApplicationUser> userManager, IMapper mapper
            , ITokenServices tokenServices, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenServices = tokenServices;
            _signInManager = signInManager;
        }
        [HttpPost("register")]

        public async Task<ActionResult<RegisterView>> Register(RegisterViewModel model)
        {
            if (await UserExists(model.Email))
            {
                return BadRequest();
            }
            var user = _mapper.Map<ApplicationUser>(model);
            user.UserName = model.Email;
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded)
            {
                return BadRequest();
            }
            return new RegisterView
            {
                Email = model.Email,
                Gender = model.Gender,
                Token = await _tokenServices.GetTokenAsync(user)
            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<RegisterView>> Login(LoginViewModel loginViewModel)
        {
            var applicationUser = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == loginViewModel.Email.ToLower());
            if (applicationUser == null) return Unauthorized("Invalid Email");
            var result = await _signInManager.CheckPasswordSignInAsync(applicationUser, loginViewModel.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid Password");
            return new RegisterView
            {
                Email = applicationUser.Email,
                Token = await _tokenServices.GetTokenAsync(applicationUser),
                Gender = applicationUser.Gender
            };
        }


        private async Task<bool> UserExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email);
        }

    }
}
