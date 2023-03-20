using backend.Dtos.Recipes.PreparationStep;
using backend.Dtos.Recipes.RecipeIngredient;
using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.Recipe;

public class RecipeRequest
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120)]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }
    [Required]
    public required PreparationDifficulty Difficulty { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<int> PreparationStepsId { get; set; }

    [Required]
    [MinLength(1)]
    public required ICollection<RecipeIngredientAddNew> RecipeIngredientsAddNew { get; set; }

    [Required]
    public required int CuisineId { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<int> MealTimeIds { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<int> DietIds { get; set; }
    [Required]
    public required int DishTypeId { get; set; }
}