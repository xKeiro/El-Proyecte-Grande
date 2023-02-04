using AutoMapper;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public RecipeService(ElProyecteGrandeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RecipePublic>> GetFiltered(RecipeFilter filter)
        {
            var recipes = await _context.Recipes
                .Where(recipe => filter.Name == null || recipe.Name.ToLower().Contains(filter.Name.ToLower()))
                .Where(recipe => filter.DietIds == null || 
                    recipe.Diets.Where(diet => filter.DietIds.Contains(diet.Id)).Count() > 0)
                .Where(recipe => filter.MealTimeIds == null ||
                    recipe.MealTimes.Where(mealTime => filter.MealTimeIds.Contains(mealTime.Id)).Count() > 0)
                .Where(recipe => filter.CuisineIds == null || 
                    filter.CuisineIds.Contains(recipe.Cuisine.Id))
                .Where(recipe => filter.DishTypeIds == null || 
                    filter.DishTypeIds.Contains(recipe.DishType.Id))
                .Where(recipe => filter.IngredientIds == null ||
                    recipe.RecipeIngredients.Where(recipeIngredient => filter.IngredientIds.Contains(recipeIngredient.Ingredient.Id)).Count() > 0)
                .Include(recipe => recipe.Diets)
                .Include(recipe => recipe.MealTimes)
                .Include(recipe => recipe.Cuisine)
                .Include(recipe => recipe.DishType)
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<Recipe>, List<RecipePublic>>(recipes);
        }

        public async Task<RecipePublic?> Add(RecipeAddNew recipeAddNew)
        {
            var cuisine = _context.Cuisines.Find(recipeAddNew.CuisineId);
            switch(cuisine)
            {
                case null: return null;
            };
            List<MealTime> mealTimes = new();
            foreach(var mealTimeId in recipeAddNew.MealTimeIds)
            {
                var mealTime = _context.MealTimes.Find(mealTimeId);
                switch (mealTime)
                {
                    case null: return null;
                }
                mealTimes.Add(mealTime);
            }


            List<Diet> diets = new();
            foreach (var dietId in recipeAddNew.DietIds)
            {
                var diet = _context.Diets.Find(dietId);
                switch(diet)
                {
                    case null: return null;
                }
                diets.Add(diet);
            }

            var dishType = _context.DishTypes.Find(recipeAddNew.DishTypeId);
            switch (dishType)
            {
                case null: return null;
            };
            List<RecipeIngredient> recipeIngredients = new();
            foreach ( var recipeIngredientAddNew in recipeAddNew.RecipieIngredientsAddNew) 
            {
                var ingredient = _context.Ingredients.Find(recipeIngredientAddNew.IngredientId);
                switch (ingredient)
                {
                    case null: return null;
                };
                recipeIngredients.Add(
                    new RecipeIngredient()
                    {
                        Amount = recipeIngredientAddNew.Amount,
                        Ingredient = ingredient
                    });
            }
            Recipe recipe = new() 
            { 
                Name = recipeAddNew.Name,
                Description = recipeAddNew.Description,
                RecipeIngredients = recipeIngredients,
                Cuisine = cuisine,
                MealTimes = mealTimes,
                Diets = diets,
                DishType = dishType
            };
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return _mapper.Map<Recipe, RecipePublic>(recipe);
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
            return await IsNameUnique(recipeWithoutId.Name);
        }
        public async Task<bool> IsUnique(RecipeAddNew recipeAddNew)
        {
            return await IsNameUnique(recipeAddNew.Name);
        }
        private async Task<bool> IsNameUnique(string name)
        {
            return !await _context.Recipes.AnyAsync(r => r.Name.ToLower() == name.ToLower());
        }
    }
}
