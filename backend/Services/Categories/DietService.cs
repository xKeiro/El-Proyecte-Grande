﻿using AutoMapper;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Recipes.Recipe;
using backend.Interfaces.Services;
using backend.Models.Categories;
using backend.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Categories;

public class DietService : ICategoryService<DietPublic, DietWithoutId>
{
    private readonly ElProyecteGrandeContext _context;
    private readonly IMapper _mapper;
    public DietService(ElProyecteGrandeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DietPublic> Add(DietWithoutId dietWithoutId)
    {
        var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
        _ = await _context.Diets.AddAsync(diet);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Diet, DietPublic>(diet);
    }

    public async Task<List<DietPublic>> GetAll()
    {
        var diets = await _context
            .Diets
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<Diet>, List<DietPublic>>(diets);
    }

    public async Task<DietPublic?> Find(int id)
    {
        var diet = await _context.Diets
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return diet switch
        {
            null => null,
            _ => _mapper.Map<Diet, DietPublic>(diet),
        };
    }

    public async Task<DietPublic> Update(int id, DietWithoutId dietWithoutId)
    {
        var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
        diet.Id = id;
        _ = _context.Update(diet);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Diet, DietPublic>(diet);
    }

    public async Task<bool> IsUnique(DietWithoutId dietWithoutId)
    {
        var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
        return !await _context.Diets.AnyAsync(c => c.Name.ToLower() == diet.Name.ToLower());
    }

    public async Task<List<RecipePublic>?> GetRecipes(int categoryId)
    {
        var recipes = await _context.Diets
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