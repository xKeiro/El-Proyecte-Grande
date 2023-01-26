using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
                .Diet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Add(Diet diet)
        {
            await _context.Diet.AddAsync(diet);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Diet?> Find(int id)
        {
            return await _context.Diet.FindAsync(id);
        }

        public async Task Update(Diet diet)
        {
            EntityEntry entityEntry = _context.Entry(diet);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Diet diet)
        {
            _context.Diet.Remove(diet);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(Diet diet)
        {
            bool isUnique = !await _context.Diet.AnyAsync(d => d.Name == diet.Name);
            return isUnique;
        }
    }
}
