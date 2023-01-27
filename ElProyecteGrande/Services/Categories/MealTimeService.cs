using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Categories
{
    public class MealTimeService : IBasicCrudService<MealTime>
    {
        private readonly ElProyecteGrandeContext _context;

        public MealTimeService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task<List<MealTime>> GetAll()
        {
            return await _context.MealTimes.AsNoTracking().ToListAsync();
        }

        public async Task Add(MealTime mealTime)
        {
            await _context.MealTimes.AddAsync(mealTime);
            await _context.SaveChangesAsync();
        }

        public async Task<MealTime?> Find(int id)
        {
            return await _context.MealTimes.FindAsync(id);
        }

        public async Task Update(MealTime newMealTime)
        {
            _context.MealTimes.Update(newMealTime);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(MealTime mealTime)
        {
            _context.MealTimes.Remove(mealTime);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(MealTime mealTime)
        {
            return !await _context.MealTimes.AnyAsync(m =>  m.Name == mealTime.Name);
        }
    }
}
