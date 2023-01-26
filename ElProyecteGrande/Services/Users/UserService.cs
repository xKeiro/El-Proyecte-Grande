using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
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
            return await _context.User.AsNoTracking().Select(u => new UserPublic()
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                EmailAddress = u.EmailAddress,
                IsAdmin = u.IsAdmin
            }).ToListAsync();
        }

        public async Task Add(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> Find(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<UserPublic?> FindPublic(int id)
        {
            User? user = await _context.User.FindAsync(id);

            if (user is null) return null;

            return new UserPublic()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                IsAdmin = user.IsAdmin
            };
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(User user)
        {
            return !await _context.User.AnyAsync(u => u.Username == user.Username || u.EmailAddress == user.EmailAddress);
        }
    }
}
