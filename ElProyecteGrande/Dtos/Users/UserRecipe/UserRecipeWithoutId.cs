using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Dtos.Users.UserRecipeStatus;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Users.UserRecipe;

public class UserRecipeWithoutId
{
    [Required]
    required public UserPublic User { get; set; }

    [Required]
    required public RecipePublic Recipe { get; set; }

    [Required]
    required public UserRecipeStatusPublic Status { get; set; }
}