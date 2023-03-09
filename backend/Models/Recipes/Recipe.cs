using backend.Enums;
using backend.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Recipes;

public class Recipe : BaseModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120)]
    public required string Name { get; set; }

    [Required]
    [StringLength(4000, MinimumLength = 2)]
    public required string Description { get; set; }

    [Required]
    public required PreparationDifficulty Difficulty { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<PreparationStep> PreparationSteps { get; set; }

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