using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services;

public interface ICategoryService<TResponseDto, TRequestDto> : IBasicCrudService<TResponseDto, TRequestDto>
    where TResponseDto : class
    where TRequestDto : class
{
    Task<List<RecipePublic>?> GetRecipes(int categoryId);
}