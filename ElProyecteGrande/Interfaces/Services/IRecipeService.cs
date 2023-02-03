using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface IRecipeService     
    {
        Task<List<RecipePublic>> GetAll();
        Task<RecipePublic?> Add(RecipeAddNew recipeAddNew);
        Task<RecipePublic?> Find(int id);
        Task<RecipePublic> Update(int id, RecipeWithoutId recipeWithoutId);
        Task<bool> IsUnique(RecipeWithoutId recipeWithoutId);
        Task<bool> IsUnique(RecipeAddNew recipeAddNew);
        Task<bool> Delete(int id);
    }
}
