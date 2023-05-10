using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Users.UserRecipe;

public class UserRecipeAddNew
{
    [Required]
    public required RecipeStatus RecipeStatus { get; set; }
}
