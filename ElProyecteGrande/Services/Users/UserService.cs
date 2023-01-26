using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Users
{
    public class UserService : IBasicCrudService<User>
    {
        private readonly ElProyecteGrandeContext _context;

        public UserService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUnique(User user)
        {
            throw new NotImplementedException();
        }
    }
}
