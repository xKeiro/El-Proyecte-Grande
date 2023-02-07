using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Users.User;

namespace ElProyecteGrande.Interfaces.Services;

public interface IUserService<TResponseDto, TRequestDto> :
    IBasicCrudService<TResponseDto, TRequestDto>
    where TResponseDto : class
    where TRequestDto : class
{
    Task<bool> Delete(int id);
    //Task<List<(UserPublic User, RecipePublic Recipe)>> LikedRecipes(int id);

    Task<List<RecipePublic>> LikedRecipes(int userId);

}