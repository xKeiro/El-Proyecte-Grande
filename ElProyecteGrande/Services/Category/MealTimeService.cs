using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Category
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

        public async Task AddMealTime(MealTime mealTime)
        {
            await _context.MealTimes.AddAsync(mealTime);
            await _context.SaveChangesAsync();
        }

        public async Task<MealTime> GetMealTimeByName(string name)
        {
            MealTime? mealTime = await _context.MealTimes.FirstOrDefaultAsync(m => m.Name == name);
            return mealTime;
        }
    }
}
