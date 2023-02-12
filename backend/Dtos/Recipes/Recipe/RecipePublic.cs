using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Recipes.PreparationStep;
using backend.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.Recipe;

public class RecipePublic
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    [StringLength(4000, MinimumLength = 2)]
    public required string Description { get; set; }
    [Required]
    public required PreparationStepPublic Difficulty { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<PreparationStepPublic> PreparationSteps { get; set; }

    [Required]
    [MinLength(1)]
    public required ICollection<RecipeIngredientPublic> RecipeIngredients { get; set; }

    [Required]
    public required CuisinePublic Cuisine { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<MealTimePublic> MealTimes { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<DietPublic> Diets { get; set; }
    [Required]
    public required DishTypePublic DishType { get; set; }
    [Required]
}