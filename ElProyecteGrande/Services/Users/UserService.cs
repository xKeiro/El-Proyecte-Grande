using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Dto.Users;
using ElProyecteGrande.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ElProyecteGrandeContext _context;

        public UserService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task<List<UserPublic>> GetAll()
        {
            return await _context.Users.AsNoTracking().Select(u => new UserPublic()
            {
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                EmailAddress = u.EmailAddress,
                IsAdmin = u.IsAdmin
            }).ToListAsync();
        }

        public async Task<User?> Find(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
