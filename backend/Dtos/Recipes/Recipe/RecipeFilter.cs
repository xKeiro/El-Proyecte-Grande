using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.Recipe;

public class RecipeFilter
{
    [StringLength(120)]
    public required string? Name { get; set; } = null;
    [MinLength(1)]
    public IEnumerable<int>? IngredientIds { get; set; } = null;
    [MinLength(1)]
    public IEnumerable<int>? CuisineIds { get; set; } = null;
    [MinLength(1)]
    public IEnumerable<int>? MealTimeIds { get; set; } = null;
    [MinLength(1)]
    public IEnumerable<int>? DietIds { get; set; } = null;
    [MinLength(1)]
    public IEnumerable<int>? DishTypeIds { get; set; } = null;
    public PreparationDifficulty? MaxDifficulty { get; set; } = null;
    public int MaxNumberOfNotOwnedIngredients { get; set; } = 0;
}