using AutoMapper;
using backend.Dtos.Recipes.Recipe;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class RecipeService : IRecipeService
{
    private readonly ElProyecteGrandeContext _context;
    private readonly IMapper _mapper;
    public RecipeService(ElProyecteGrandeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RecipesPublicWithNextPage> GetFiltered(RecipeFilter filter, int currentPage)
    {
        const int PAGESIZE = 5;
        var recipesQuery = _context.Recipes
            .Where(recipe => filter.Name == null || recipe.Name.ToLower().Contains(filter.Name.ToLower()))
            .Where(recipe => filter.DietIds == null ||
                recipe.Diets.Any(diet => filter.DietIds.Contains(diet.Id)))
            .Where(recipe => filter.MealTimeIds == null ||
                recipe.MealTimes.Any(mealTime => filter.MealTimeIds.Contains(mealTime.Id)))
            .Where(recipe => filter.CuisineIds == null ||
                filter.CuisineIds.Contains(recipe.Cuisine.Id))
            .Where(recipe => filter.DishTypeIds == null ||
                filter.DishTypeIds.Contains(recipe.DishType.Id));
        var recipes = await FilterIngredients(filter, recipesQuery);
        var filteredRecipesQuery = recipes.Where(recipe => filter.MaxDifficulty == null || ((int)filter.MaxDifficulty) >= ((int)recipe.Difficulty));
        var recipeCount = filteredRecipesQuery.Count();
        var filteredRecipes = filteredRecipesQuery
            .Skip((currentPage - 1) * PAGESIZE)
            .Take(PAGESIZE)
            .ToList();
        int? nextPage = null;
        if (currentPage * PAGESIZE < recipeCount)
        {
            nextPage = currentPage + 1;
        }

        return new RecipesPublicWithNextPage()
        {
            NextPage = nextPage,
            Recipes = _mapper.Map<List<Recipe>, List<RecipePublic>>(filteredRecipes)
        };
    }

    private static async Task<List<Recipe>> FilterIngredients(RecipeFilter filter, IQueryable<Recipe> recipesQuery)
    {
        List<Recipe> recipes = new();
        if (filter.IngredientIds == null)
        {
            recipes = filter.MaxNumberOfNotOwnedIngredients == 0
                ? await recipesQuery
                    .AsNoTracking()
                    .ToListAsync()
                : await recipesQuery
                    .Where(recipe => recipe.RecipeIngredients.Count <= filter.MaxNumberOfNotOwnedIngredients)
                    .AsNoTracking()
                    .ToListAsync();
        }
        else
        {
            foreach (var recipe in recipesQuery)
            {
                var matchingIngredientCount = 0;
                foreach (var recipeIngredient in recipe.RecipeIngredients)
                {
                    var ingredientId = recipeIngredient.Ingredient.Id;
                    if (filter.IngredientIds.Contains(ingredientId))
                    {
                        matchingIngredientCount++;
                    }
                }

                if (recipe.RecipeIngredients.Count <= matchingIngredientCount + filter.MaxNumberOfNotOwnedIngredients)
                {
                    recipes.Add(recipe);
                }
            }
        }

        return recipes;
    }

    public async Task<RecipePublic?> Add(RecipeRequest recipeRequest)
    {
        var recipe = GetNewRecipeOrUpdateExisting(recipeRequest);
        switch (recipe)
        {
            case null:
                return null;
        }

        _ = await _context.Recipes.AddAsync(recipe);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Recipe, RecipePublic>(recipe);
    }

    public async Task<RecipePublic?> Find(int id)
    {
        var recipe = await _context.Recipes
            .AsNoTracking()
            .FirstOrDefaultAsync(recipe => recipe.Id == id);
        return recipe switch
        {
            null => null,
            _ => _mapper.Map<Recipe, RecipePublic>(recipe)
        };
    }

    public async Task<RecipePublic?> Update(int id, RecipeRequest recipeRequest)
    {
        var oldRecipe = await _context.Recipes.FindAsync(id);
        switch (oldRecipe)
        {
            case null:
                return null;
        }

        switch (GetNewRecipeOrUpdateExisting(recipeRequest, oldRecipe))
        {
            case null:
                return null;
        }

        _ = _context.Update(oldRecipe);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<Recipe, RecipePublic>(oldRecipe);
    }

    public async Task<bool> Delete(int id)
    {
        var recipe = await _context.Recipes
             .AsNoTracking()
             .FirstOrDefaultAsync(recipe => recipe.Id == id);
        switch (recipe)
        {
            case null:
                return false;
        }

        _ = _context.Recipes.Remove(recipe);
        _ = await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsUnique(RecipeRequest recipeRequest)
    {
        return await IsNameUnique(recipeRequest.Name);
    }

    private async Task<bool> IsNameUnique(string name)
    {
        return !await _context.Recipes.AnyAsync(r => r.Name.ToLower() == name.ToLower());
    }

    private Recipe? GetNewRecipeOrUpdateExisting(RecipeRequest recipeRequest, Recipe? recipeToUpdate = null)
    {
        var cuisine = _context.Cuisines.Find(recipeRequest.CuisineId);
        switch (cuisine)
        {
            case null:
                return null;
        }

        List<MealTime> mealTimes = new();
        foreach (var mealTimeId in recipeRequest.MealTimeIds)
        {
            var mealTime = _context.MealTimes.Find(mealTimeId);
            switch (mealTime)
            {
                case null:
                    return null;
            }

            mealTimes.Add(mealTime);
        }

        List<Diet> diets = new();
        foreach (var dietId in recipeRequest.DietIds)
        {
            var diet = _context.Diets.Find(dietId);
            switch (diet)
            {
                case null:
                    return null;
            }

            diets.Add(diet);
        }

        var dishType = _context.DishTypes.Find(recipeRequest.DishTypeId);
        switch (dishType)
        {
            case null:
                return null;
        }

        List<RecipeIngredient> recipeIngredients = new();
        foreach (var recipeIngredientAddNew in recipeRequest.RecipeIngredientsAddNew)
        {
            var ingredient = _context.Ingredients.Find(recipeIngredientAddNew.IngredientId);
            switch (ingredient)
            {
                case null:
                    return null;
            }

            recipeIngredients.Add(
                new RecipeIngredient()
                {
                    Amount = recipeIngredientAddNew.Amount,
                    Ingredient = ingredient
                });
        }

        List<PreparationStep> preparationSteps = new();
        foreach (var preparationStepId in recipeRequest.PreparationStepsId)
        {
            var preparationStep = _context.PreparationSteps.Find(preparationStepId);
            switch (preparationStep)
            {
                case null:
                    return null;
            }

            preparationSteps.Add(preparationStep);
        }

        switch (recipeToUpdate)
        {
            case null:
                Recipe recipe = new()
                {
                    Name = recipeRequest.Name,
                    Description = recipeRequest.Description,
                    RecipeIngredients = recipeIngredients,
                    Cuisine = cuisine,
                    MealTimes = mealTimes,
                    Diets = diets,
                    DishType = dishType,
                    Difficulty = recipeRequest.Difficulty,
                    PreparationSteps = preparationSteps
                };
                return recipe;
            default:
                recipeToUpdate.Name = recipeRequest.Name;
                recipeToUpdate.Description = recipeRequest.Description;
                recipeToUpdate.RecipeIngredients = recipeIngredients;
                recipeToUpdate.Cuisine = cuisine;
                recipeToUpdate.MealTimes = mealTimes;
                recipeToUpdate.Diets = diets;
                recipeToUpdate.DishType = dishType;
                return recipeToUpdate;
        }
    }
}