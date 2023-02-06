using ElProyecteGrande.Enums;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Users;

public class UserRecipeStatus : BaseModel
{
    [Required]
    public required RecipeStatus Name { get; set; }
}