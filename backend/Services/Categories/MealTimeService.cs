using AutoMapper;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Recipes.Recipe;
using backend.Interfaces.Services;
using backend.Models.Categories;
using backend.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Categories;

public class MealTimeService : ICategoryService<MealTimePublic, MealTimeWithoutId>
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
        _ = await _context.MealTimes.AddAsync(mealTime);
        _ = await _context.SaveChangesAsync();
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
        return mealTime switch
        {
            null => null,
            _ => _mapper.Map<MealTime, MealTimePublic>(mealTime)
        };
    }

    public async Task<MealTimePublic> Update(int id, MealTimeWithoutId mealTimeWithoutId)
    {
        var mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(mealTimeWithoutId);
        mealTime.Id = id;
        _ = _context.Update(mealTime);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<MealTime, MealTimePublic>(mealTime);
    }

    public async Task<bool> IsUnique(MealTimeWithoutId mealTimeWithoutId)
    {
        var mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(mealTimeWithoutId);
        return !await _context.MealTimes.AnyAsync(c => c.Name.ToLower() == mealTime.Name.ToLower());
    }

    public async Task<List<RecipePublic>?> GetRecipes(int categoryId)
    {
        var recipes = await _context.MealTimes
            .Where(c => c.Id == categoryId)
            .Select(c => c.Recipes.ToList())
            .FirstOrDefaultAsync();
        return recipes switch
        {
            null => null,
            _ => _mapper.Map<List<Recipe>, List<RecipePublic>>(recipes),
        };
    }
}