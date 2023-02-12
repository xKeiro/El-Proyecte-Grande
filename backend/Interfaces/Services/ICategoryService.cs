using backend.Dtos.Recipes.Recipe;

namespace backend.Interfaces.Services;

public interface ICategoryService<TResponseDto, TRequestDto> : IBasicCrudService<TResponseDto, TRequestDto>
    where TResponseDto : class
    where TRequestDto : class
{
    Task<List<RecipePublic>?> GetRecipes(int categoryId);
}