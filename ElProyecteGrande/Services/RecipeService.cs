using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services
{
    public class RecipeService : IRecipeService<RecipePublic, RecipeWithoutId>
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public RecipeService(ElProyecteGrandeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RecipePublic>> GetAll()
        {
            var recipes = await _context.Recipes
                .Include(recipe => recipe.Diets)
                .Include(recipe => recipe.MealTimes)
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.DishType)
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                //.Select(recipe => new Recipe()
                //{
                //    Id = recipe.Id,
                //    Name = recipe.Name,
                //    Description = recipe.Description,
                //    Cuisine = recipe.Cuisine,
                //    MealTimes = recipe.MealTimes,
                //    Diets = recipe.Diets,
                //    DishType = recipe.DishType,
                //    RecipeIngredients = recipe.RecipeIngredients.Select(recipeIngredient => new RecipeIngredient()
                //    {
                //        Amount = recipeIngredient.Amount,
                //        Ingredient = new Ingredient()
                //        {
                //            Name = recipeIngredient.Ingredient.Name,
                //            UnitOfMeasure = recipeIngredient.Ingredient.UnitOfMeasure,
                //        }
                //    }).ToList()
                //})
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<Recipe>, List<RecipePublic>>(recipes);
        }

        public Task<RecipePublic> Add(RecipeWithoutId recipeWithoutId)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipePublic?> Find(int id)
        {
            var recipe = await _context.Recipes
                .Include(recipe => recipe.Diets)
                .Include(recipe => recipe.MealTimes)
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.DishType)
                .Include(recipe => recipe.RecipeIngredients)
                .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .AsNoTracking()
                .FirstOrDefaultAsync(recipe => recipe.Id == id);
            if (recipe is null)
            {
                return null;
            }
            return _mapper.Map<Recipe, RecipePublic>(recipe);
        }

        public Task<RecipePublic> Update(int id, RecipeWithoutId RecipeWithoutId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
           var recipe = await _context.Recipes
                .Include(recipe => recipe.Diets)
                .Include(recipe => recipe.MealTimes)
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.DishType)
                .Include(recipe => recipe.RecipeIngredients)
                .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .AsNoTracking()
                .FirstOrDefaultAsync(recipe => recipe.Id == id);
            if (recipe is null)
            {
                return false;
            }
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsUnique(RecipeWithoutId recipeWithoutId)
        {
            return !await _context.Recipes.AnyAsync(r => r.Name == recipeWithoutId.Name);
        }
    }
}
