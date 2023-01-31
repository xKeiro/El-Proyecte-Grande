using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe;

public class RecipeWithoutId
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }
    
    [Required]
    public required string Description { get; set; }

    [Required]
    [MinLength(1)]
    public required ICollection<RecipeIngredientFull> RecipeIngredients { get; set; }

    [Required]
    public CuisineFull Cuisine { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<MealTimeFull> MealTimes { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<DietFull> Diets { get; set; }
    [Required]
    public DishTypeFull DishType { get; set; }
}
