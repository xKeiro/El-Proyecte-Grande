using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Categories
{
    public class DietService : IBasicCrudService<Diet>
    {
        private readonly ElProyecteGrandeContext _context;

        public DietService(ElProyecteGrandeContext context)
        {
            _context = context;
        }
        public async Task<List<Diet>> GetAll()
        {
            return await _context
                .Diets
                .AsNoTracking()
                .ToListAsync();
        }

        public Task Add(Diet model)
        {
            throw new NotImplementedException();
        }

        public async Task<Diet?> Find(int id)
        {
            return await _context.Diets.FindAsync(id);
        }

        public Task Update(Diet model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Diet model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUnique(Diet diet)
        {
            bool isUnique = !await _context.Diets.AnyAsync(c => c.Name == diet.Name);
            return isUnique;
        }
    }
}
