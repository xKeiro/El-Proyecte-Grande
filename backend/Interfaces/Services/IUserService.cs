using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Users.User;
using backend.Dtos.Users.UserRecipe;
using backend.Dtos.Users.UserRecipeStatus;
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
    Task<List<UserRecipeStatusPublic?>> GetUserRecipeStatusByRecipeId(int recipeId);
    Task<UserRecipeStatusPublic?> GetUserRecipeStatusByRecipeIdAndUsername(int recipeId, string username);
    Task<UserRecipePublic?> AddUserRecipe(string username, int recipeId, UserRecipeAddNew userRecipeAddNew);
    Task<bool> RemoveUserRecipe(string username, int recipeId);
}