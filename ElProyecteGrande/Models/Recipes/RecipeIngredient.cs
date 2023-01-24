using Microsoft.Build.Framework;

namespace ElProyecteGrande.Models.Recipes;

public class RecipeIngredient : BaseModel
{
    [Required]
    public required Recipe Recipe { get; set; }
    [Required]
    public required Ingredient Ingredient { get; set; }
    [Required]
    public required decimal Amount { get; set; }

}
