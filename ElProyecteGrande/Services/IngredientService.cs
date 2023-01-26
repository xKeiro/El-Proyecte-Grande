using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;

namespace ElProyecteGrande.Services
{
    public class IngredientService: IBasicCrudService<Ingredient>
    {
        private readonly ElProyecteGrandeContext _context;
        public IngredientService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task Add(Ingredient ingredient)
        {
            await _context.Ingredient.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Ingredient ingredient)
        {
            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return await _context
                .Ingredient
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ingredient?> Find(int id)
        {
            return await _context.Ingredient.FindAsync(id);
        }
        
        public async Task Update(Ingredient ingredient)
        {
            _context.Update(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(Ingredient ingredient)
        {
            return !await _context.Ingredient.AnyAsync(i => i.Name == ingredient.Name);
        }
    }
}
