using SocialNetworkingAPI.data;
using SocialNetworkingAPI.Services.Interface;
using SocialNetworkingAPI.Services;
using Microsoft.EntityFrameworkCore;
using SocialNetworkingAPI.Utility;

namespace SocialNetworkingAPI.Expentions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(config.GetConnectionString("SocialConnection")));

            services.AddScoped<ITokenServices, TokenServices>();

            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            return services;
        }
    }
}
