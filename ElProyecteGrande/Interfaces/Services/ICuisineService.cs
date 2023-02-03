using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface ICuisineService     
    {
        Task<List<CuisinePublic>> GetAll();
        Task<CuisinePublic?> Add(CuisineWithoutId cuisineWithoutId);
        Task<CuisinePublic?> Find(int id);
        Task<CuisinePublic> Update(int id, CuisineWithoutId cuisineWithoutId);
        Task<bool> IsUnique(CuisineWithoutId cuisineWithoutId);
        Task<List<RecipePublic?>> GetRecipesByCuisine(int id);

    }
}
