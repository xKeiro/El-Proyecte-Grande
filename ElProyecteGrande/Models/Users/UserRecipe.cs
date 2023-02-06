using ElProyecteGrande.Models.Recipes;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Users;

public class UserRecipe : BaseModel
{
    [Required]
    public required User User { get; set; }

    [Required]
    public required Recipe Recipe { get; set; }

    [Required]
    public required UserRecipeStatus Status { get; set; }
}