using AutoMapper;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Recipes.Recipe;
using backend.Interfaces.Services;
using backend.Models.Categories;
using backend.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Categories;

public class DishTypeService : ICategoryService<DishTypePublic, DishTypeWithoutId>
{
    private readonly ElProyecteGrandeContext _context;
    private readonly IMapper _mapper;
    public DishTypeService(ElProyecteGrandeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DishTypePublic> Add(DishTypeWithoutId dishTypeWithoutId)
    {
        var dishType = _mapper.Map<DishTypeWithoutId, DishType>(dishTypeWithoutId);
        _ = await _context.DishTypes.AddAsync(dishType);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<DishType, DishTypePublic>(dishType);
    }

    public async Task<List<DishTypePublic>> GetAll()
    {
        var dishTypes = await _context
            .DishTypes
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<DishType>, List<DishTypePublic>>(dishTypes);
    }

    public async Task<DishTypePublic?> Find(int id)
    {
        var dishType = await _context.DishTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return dishType switch
        {
            null => null,
            _ => _mapper.Map<DishType, DishTypePublic>(dishType)
        };
    }

    public async Task<DishTypePublic> Update(int id, DishTypeWithoutId dishTypeWithoutId)
    {
        var dishType = _mapper.Map<DishTypeWithoutId, DishType>(dishTypeWithoutId);
        dishType.Id = id;
        _ = _context.Update(dishType);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<DishType, DishTypePublic>(dishType);
    }

    public async Task<bool> IsUnique(DishTypeWithoutId dishTypeWithoutId)
    {
        var dishType = _mapper.Map<DishTypeWithoutId, DishType>(dishTypeWithoutId);
        return !await _context.DishTypes.AnyAsync(c => c.Name.ToLower() == dishType.Name.ToLower());
    }

    public async Task<List<RecipePublic>?> GetRecipes(int categoryId)
    {
        var recipes = await _context.DishTypes
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