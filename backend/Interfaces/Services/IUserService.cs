using backend.Dtos.Recipes.Recipe;
using backend.Models.Users;

namespace backend.Interfaces.Services;

public interface IUserService<TResponseDto, TRequestDto> :
    IBasicCrudService<TResponseDto, TRequestDto>
    where TResponseDto : class
    where TRequestDto : class
{
    Task<bool> Delete(int id);
    Task<User> FindByUsername(string username);
    Task<List<RecipePublic>> LikedRecipes(int userId);
    Task<List<RecipePublic>> SavedRecipes(int userId);
    Task<List<RecipePublic>> DislikedRecipes(int userId);
}