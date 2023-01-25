using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Category
{
    public class DishTypeService : IDishTypeService
    {
        private readonly ElProyecteGrandeContext _context;

        public DishTypeService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DishType>> GetAllDishType()
        {
            var result = await _context.DishTypes.ToListAsync();
            return result;
        }

        public async Task AddDishType(DishType dishType)
        {
            await _context.DishTypes.AddAsync(dishType);
            await _context.SaveChangesAsync();
        }
    }
}
