using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services
{
    public class MealTimeService : IMealTimeService
    {
        private readonly ElProyecteGrandeContext _context;

        public MealTimeService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MealTime>> GetAllMealTime()
        {
            var result = await _context.MealTimes.ToListAsync();
            return result;
        }
    }
}
