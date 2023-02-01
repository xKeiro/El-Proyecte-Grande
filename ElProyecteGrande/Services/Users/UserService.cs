using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using AutoMapper;
using ElProyecteGrande.Models.Users;
using ElProyecteGrande.Dtos.Users.User;

namespace ElProyecteGrande.Services.Categories
{
    public class UserService : IUserService<UserPublic, UserWithoutId>
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public UserService(ElProyecteGrandeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserPublic> Add(UserWithoutId userWithoutId)
        {
            var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserPublic>(user);
        }

        public async Task<List<UserPublic>> GetAll()
        {
            var users = await _context
                .Users
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<User>, List<UserPublic>>(users);
        }

        public async Task<UserPublic?> Find(int id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (user is null)
            {
                return null;
            }
            return _mapper.Map<User, UserPublic>(user);
        }

        public async Task<UserPublic> Update(int id, UserWithoutId userWithoutId)
        {
            var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
            user.Id = id;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserPublic>(user);
        }

        public async Task<bool> IsUnique(UserWithoutId userWithoutId)
        {
            var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
            return !await _context.Users.AnyAsync(u => u.Username == user.Username || u.EmailAddress == user.EmailAddress);
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users
                 .FirstOrDefaultAsync(user => user.Id == id);
            var userRecipe = await _context.UserRecipes
                .FirstOrDefaultAsync(userRecipe => userRecipe.User == user);
            if (user is null)
            {
                return false;
            }
            if (userRecipe is not null)
            {
                _context.UserRecipes.Remove(userRecipe);
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
