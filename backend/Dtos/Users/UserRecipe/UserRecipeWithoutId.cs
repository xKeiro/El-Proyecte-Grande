using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Users.User;
using backend.Dtos.Users.UserRecipeStatus;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Users.UserRecipe;

public class UserRecipeWithoutId
{
    [Required]
    public required UserPublic User { get; set; }

    [Required]
    public required RecipePublic Recipe { get; set; }

    [Required]
    public required UserRecipeStatusPublic Status { get; set; }
}