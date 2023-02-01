using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Dtos.Users.UserRecipeStatus;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Users.UserRecipe;

public class UserRecipeWithoutId
{
    [Required]
    public required UserPublic User { get; set; }

    [Required]
    public required RecipePublic Recipe { get; set; }

    [Required]
    public required UserRecipeStatusPublic Status { get; set; }
}
