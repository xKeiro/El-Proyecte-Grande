using ElProyecteGrande.Interfaces.Services.Categories;
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
    }
}
