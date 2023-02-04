using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface IRecipeService     
    {
        Task<List<RecipePublic>> GetFiltered(RecipeFilter filter);
        Task<RecipePublic?> Add(RecipeRequest recipeAddNew);
        Task<RecipePublic?> Find(int id);
        Task<RecipePublic?> Update(int id, RecipeRequest recipeAddNew);
        Task<bool> IsUnique(RecipeWithoutId recipeWithoutId);
        Task<bool> IsUnique(RecipeRequest recipeAddNew);
        Task<bool> Delete(int id);
    }
}
