using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Users.User;
using backend.Dtos.Users.UserRecipe;
using backend.Enums;
using backend.Models.Recipes;
using backend.Models.Users;

namespace backend.Interfaces.Services;

public interface IUserService<TResponseDto, TRequestDto> :
    IBasicCrudService<TResponseDto, TRequestDto>
    where TResponseDto : class
    where TRequestDto : class
{
    Task<bool> Delete(int id);
    Task<User?> FindByUsername(string username);
    Task<bool> IsUniqueUsername(UserWithoutId userWithoutId);
    Task<bool> IsUniqueEmail(UserWithoutId userWithoutId);
    Task<List<RecipePublic>> LikedRecipes(int userId);
    Task<List<RecipePublic>> SavedRecipes(int userId);
    Task<List<RecipePublic>> DislikedRecipes(int userId);
    Task<UserRecipePublic?> AddUserRecipe(string username, UserRecipeAddNew userRecipeAddNew);
}