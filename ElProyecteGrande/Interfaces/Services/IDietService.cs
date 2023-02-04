using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services;

public interface IDietService
{
    Task<List<DietPublic>> GetAll();
    Task<DietPublic> Add(DietWithoutId dietWithoutId);
    Task<DietPublic?> Find(int id);
    Task<DietPublic> Update(int id, DietWithoutId dietWithoutId);
    Task<bool> IsUnique(DietWithoutId dietWithoutId);
    Task<List<RecipePublic?>> GetRecipesByDietId(int id);
}