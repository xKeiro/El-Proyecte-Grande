using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
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
                var ingredinent = _context.Ingredients.Find(recipeIngredientAddNew.IngredientId);
                switch (ingredinent)
                {
                    case null: return null;
                };
                recipeIngredients.Add(
                    new RecipeIngredient()
                    {
                        Amount = recipeIngredientAddNew.Amount,
                        Ingredient = ingredinent
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
