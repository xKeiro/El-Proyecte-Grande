using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services;

public interface IDishTypeService
{
    Task<List<DishTypePublic>> GetAll();
    Task<DishTypePublic> Add(DishTypeWithoutId dishTypeWithoutId);
    Task<DishTypePublic?> Find(int id);
    Task<DishTypePublic> Update(int id, DishTypeWithoutId dishTypeWithoutId);
    Task<bool> IsUnique(DishTypeWithoutId dishTypeWithoutId);
    Task<List<RecipePublic?>> GetRecipesByDishTypeId(int id);
}