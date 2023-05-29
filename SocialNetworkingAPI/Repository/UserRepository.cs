using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetworkingAPI.data;
using SocialNetworkingAPI.Models;
using SocialNetworkingAPI.Repository.IRepository;

namespace SocialNetworkingAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private Mapper _mapper;

        public UserRepository(ApplicationDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
           var user = await _context.Users.Include(x=>x.Photots).ToListAsync();
            return user;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(x => x.Photots).SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string name)
        {
            var user = await _context.Users.Include(x => x.Photots).SingleOrDefaultAsync(x => x.UserName==name);
            return user;
        }

        public async Task<string> GetUserGender(string userName)
        {
            var user = await _context.Users.Where(x=>x.UserName==userName).Select(x=>x.Gender).FirstOrDefaultAsync();
            return user;
        }

        public void UpdateUserAsync(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
