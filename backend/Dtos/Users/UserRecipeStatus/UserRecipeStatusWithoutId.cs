using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Users.UserRecipeStatus;

public class UserRecipeStatusWithoutId
{
    [Required]
    public required RecipeStatus Name { get; set; }
}