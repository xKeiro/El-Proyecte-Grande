using AutoMapper;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services;

public class IngredientService : IBasicCrudService<IngredientPublic, IngredientWithoutId>
{
    private readonly ElProyecteGrandeContext _context;
    private readonly IMapper _mapper;
    public IngredientService(ElProyecteGrandeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IngredientPublic> Add(IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = _mapper.Map<IngredientWithoutId, Ingredient>(ingredientWithoutId);
        _ = await _context.Ingredients.AddAsync(ingredient);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Ingredient, IngredientPublic>(ingredient);
    }

    public async Task<List<IngredientPublic>> GetAll()
    {
        var ingredients = await _context
            .Ingredients
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<Ingredient>, List<IngredientPublic>>(ingredients);
    }

    public async Task<IngredientPublic?> Find(int id)
    {
        var ingredient = await _context.Ingredients
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return ingredient switch
        {
            null => null,
            _ => _mapper.Map<Ingredient, IngredientPublic>(ingredient)
        };
    }

    public async Task<IngredientPublic> Update(int id, IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = _mapper.Map<IngredientWithoutId, Ingredient>(ingredientWithoutId);
        ingredient.Id = id;
        _ = _context.Update(ingredient);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Ingredient, IngredientPublic>(ingredient);
    }

    public async Task<bool> IsUnique(IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = _mapper.Map<IngredientWithoutId, Ingredient>(ingredientWithoutId);
        return !await _context.Ingredients.AnyAsync(c => c.Name.ToLower() == ingredient.Name.ToLower());
    }
}