using ElProyecteGrande.Enums;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Users.UserRecipeStatus;

public class UserRecipeStatusWithoutId
{
    [Required]
    public required RecipeStatus Name { get; set; }
}