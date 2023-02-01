using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Dtos.Categories.MealTime;
using AutoMapper;

namespace ElProyecteGrande.Services.Categories
{
    public class MealTimeService : IBasicCrudService<MealTimePublic, MealTimeWithoutId>
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public MealTimeService(ElProyecteGrandeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MealTimePublic> Add(MealTimeWithoutId mealTimeWithoutId)
        {
            var mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(mealTimeWithoutId);
            await _context.MealTimes.AddAsync(mealTime);
            await _context.SaveChangesAsync();
            return _mapper.Map<MealTime, MealTimePublic>(mealTime);
        }

        public async Task<List<MealTimePublic>> GetAll()
        {
            var mealTimes = await _context
                .MealTimes
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<MealTime>, List<MealTimePublic>>(mealTimes);
        }

        public async Task<MealTimePublic?> Find(int id)
        {
            var mealTime = await _context.MealTimes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (mealTime is null)
            {
                return null;
            }
            return _mapper.Map<MealTime, MealTimePublic>(mealTime);
        }

        public async Task<MealTimePublic> Update(int id, MealTimeWithoutId mealTimeWithoutId)
        {
            var mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(mealTimeWithoutId);
            mealTime.Id = id;
            _context.Update(mealTime);
            await _context.SaveChangesAsync();
            return _mapper.Map<MealTime, MealTimePublic>(mealTime);
        }

        public async Task<bool> IsUnique(MealTimeWithoutId mealTimeWithoutId)
        {
            var mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(mealTimeWithoutId);
            return !await _context.MealTimes.AnyAsync(c => c.Name == mealTime.Name);
        }

    }
}
