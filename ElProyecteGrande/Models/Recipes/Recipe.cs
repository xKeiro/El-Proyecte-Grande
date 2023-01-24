using ElProyecteGrande.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Recipes;

public class Recipe : BaseModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required Categorization Categorization { get; set; }

    [Required]
    public required List<RecipeIngredient> RecipeIngredients { get; set; }

}
