using backend.Dtos.Recipes.Recipe;

namespace backend.Interfaces.Services;

public interface IRecipeService
{
    Task<RecipesPublicWithNextPage> GetFiltered(RecipeFilter filter, int currentPage);
    Task<RecipePublic?> Add(RecipeRequest recipeRequest);
    Task<RecipePublic?> Find(int id);
    Task<RecipePublic?> Update(int id, RecipeRequest recipeRequest);
    Task<bool> IsUnique(RecipeRequest recipeRequest);
    Task<bool> Delete(int id);
}