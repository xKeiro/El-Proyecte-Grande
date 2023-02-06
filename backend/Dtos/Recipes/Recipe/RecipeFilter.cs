using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe;

public class RecipeFilter
{
    [StringLength(120, MinimumLength = 2)]
    required public string? Name { get; set; } = null;
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
    public int? MaxNumberOfNotOwnedIngredients { get; set; } = null;
}