using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Categories;

public class CuisineService : ICategoryService<CuisinePublic, CuisineWithoutId>
{
    private readonly ElProyecteGrandeContext _context;
    private readonly IMapper _mapper;
    public CuisineService(ElProyecteGrandeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CuisinePublic> Add(CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
        _ = await _context.Cuisines.AddAsync(cuisine);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Cuisine, CuisinePublic>(cuisine);
    }

    public async Task<List<CuisinePublic>> GetAll()
    {
        var cuisines = await _context
            .Cuisines
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<Cuisine>, List<CuisinePublic>>(cuisines);
    }

    public async Task<CuisinePublic?> Find(int id)
    {
        var cuisine = await _context.Cuisines
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return cuisine switch
        {
            null => null,
            _ => _mapper.Map<Cuisine, CuisinePublic>(cuisine)
        };
    }

    public async Task<CuisinePublic> Update(int id, CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
        cuisine.Id = id;
        _ = _context.Update(cuisine);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Cuisine, CuisinePublic>(cuisine);
    }

    public async Task<bool> IsUnique(CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
        return !await _context.Cuisines.AnyAsync(c => c.Name.ToLower() == cuisine.Name.ToLower());
    }

    public async Task<List<RecipePublic>?> GetRecipes(int categoryId)
    {
        var recipes = await _context.Cuisines
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