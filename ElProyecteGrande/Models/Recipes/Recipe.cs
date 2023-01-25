using ElProyecteGrande.Models.Categories;
using System.Collections;
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
    [MinLength(1)]
    public required ICollection<RecipeIngredient> RecipeIngredients { get; set; }

}
