using backend.Dtos.Recipes.Recipe;

namespace backend.Interfaces.Services;

public interface IRecipeService
{
    Task<List<RecipePublic>> GetFiltered(RecipeFilter filter);
    Task<RecipePublic?> Add(RecipeRequest recipeRequest);
    Task<RecipePublic?> Find(int id);
    Task<RecipePublic?> Update(int id, RecipeRequest recipeRequest);
    Task<bool> IsUnique(RecipeWithoutId recipeWithoutId);
    Task<bool> IsUnique(RecipeRequest recipeRequest);
    Task<bool> Delete(int id);
}