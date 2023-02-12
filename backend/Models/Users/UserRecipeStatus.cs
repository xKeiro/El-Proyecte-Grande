using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Users;

public class UserRecipeStatus : BaseModel
{
    [Required]
    public required RecipeStatus Name { get; set; }
}