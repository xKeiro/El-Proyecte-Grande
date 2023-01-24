using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Models.Recipes;

public class RecipeIngredient : BaseModel
{
    [Required]
    public required Recipe Recipe { get; set; }
    [Required]
    public required Ingredient Ingredient { get; set; }
    [Required]
    [Precision(6,2)]
    public required decimal Amount { get; set; }

}
