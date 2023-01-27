﻿using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services
{
    public class RecipeService : IBasicCrudService<Recipe>
    {
        private readonly ElProyecteGrandeContext _context;
        public RecipeService(ElProyecteGrandeContext context)
        {
            _context = context;
        }
        public async Task<List<Recipe>> GetAll()
        {
            var allRecipes = await _context.Recipes
                .Include(recipe => recipe.Diets)
                .Include(recipe => recipe.MealTimes)
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.DishType)
                .Include(recipe => recipe.RecipeIngredients).ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Select(recipe => new Recipe()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Cuisine = recipe.Cuisine,
                    MealTimes = recipe.MealTimes,
                    Diets = recipe.Diets,
                    DishType = recipe.DishType,
                    RecipeIngredients = recipe.RecipeIngredients.Select(recipeIngredient => new RecipeIngredient()
                    {
                        Amount = recipeIngredient.Amount,
                        Ingredient = new Ingredient()
                        {
                            Name = recipeIngredient.Ingredient.Name,
                            UnitOfMeasure = recipeIngredient.Ingredient.UnitOfMeasure,
                        }
                    }).ToList()
                })
                .ToListAsync();
            return allRecipes;
        }

        public Task Add(Recipe model)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe?> Find(int id)
        {
            var recipeById =  _context.Recipes
                .Include(recipe => recipe.Diets)
                .Include(recipe => recipe.MealTimes)
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.DishType)
                .Include(recipe => recipe.RecipeIngredients)
                .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Where(recipe => recipe.Id == id);
            return await Task.FromResult(recipeById.FirstOrDefault());
        }

        public Task Update(Recipe model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(Recipe recipe)
        {
            return !await _context.Recipes.AnyAsync(r => r.Name == recipe.Name);
        }
    }
}
