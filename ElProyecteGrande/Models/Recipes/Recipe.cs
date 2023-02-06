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
    [MinLength(1)]
    public required ICollection<RecipeIngredient> RecipeIngredients { get; set; }

    [Required]
    public required Cuisine Cuisine { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<MealTime> MealTimes { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<Diet> Diets { get; set; }
    [Required]
    public required DishType DishType { get; set; }
}