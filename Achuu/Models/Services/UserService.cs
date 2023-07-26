using Microsoft.EntityFrameworkCore;

namespace Achuu.Models.Services
{
    public class UserService
    {
        private readonly AchuuContext _context;

        public UserService(AchuuContext context)
        {
            _context = context;
        }

        //Create User
        public async Task CreateUserAsync(User user)
        {
            _context.Users?.Add(user);
            await _context.SaveChangesAsync();
        }

        //Edit User
        public async Task EditUserAsync(User user)
        {
            _context.Users?.Update(user);
            await _context.SaveChangesAsync();
        }

        

    }
}
