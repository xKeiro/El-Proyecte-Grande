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
            return await _context.DishTypes.AsNoTracking().ToListAsync();
        }

        public async Task Add(DishType dishType)
        {
            await _context.DishTypes.AddAsync(dishType);
            await _context.SaveChangesAsync();
        }

        public async Task<DishType?> Find(int id)
        {
            return await _context.DishTypes.FindAsync(id);
        }

        public async Task Update(DishType newDishType)
        {
            _context.DishTypes.Update(newDishType);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DishType dishType)
        {
            _context.DishTypes.Remove(dishType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(DishType dishType)
        {
            return !await _context.DishTypes.AnyAsync(d => d.Name == dishType.Name);
        }
    }
}
