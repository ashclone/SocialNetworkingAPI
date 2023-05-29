using AutoMapper;
using SocialNetworkingAPI.Models;
using SocialNetworkingAPI.ViewModels;

namespace SocialNetworkingAPI.Utility
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>();
        }
    }
}
