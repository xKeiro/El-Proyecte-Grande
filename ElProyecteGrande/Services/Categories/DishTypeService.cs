using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Categories
{
    public class DishTypeService : IBasicCrudService<DishType>
    {
        private readonly ElProyecteGrandeContext _context;

        public DishTypeService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task<List<DishType>> GetAll()
        {
            return await _context.DishType.AsNoTracking().ToListAsync();
        }

        public async Task Add(DishType dishType)
        {
            await _context.DishType.AddAsync(dishType);
            await _context.SaveChangesAsync();
        }

        public async Task<DishType?> Find(int id)
        {
            return await _context.DishType.FindAsync(id);
        }

        public async Task Update(DishType newDishType)
        {
            _context.DishType.Update(newDishType);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DishType dishType)
        {
            _context.DishType.Remove(dishType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(DishType dishType)
        {
            return !await _context.DishType.AnyAsync(d => d.Name == dishType.Name);
        }
    }
}
