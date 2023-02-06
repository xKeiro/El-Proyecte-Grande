using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe;

public class RecipeRequest
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    [MinLength(1)]
    public required ICollection<RecipieIngredientAddNew> RecipieIngredientsAddNew { get; set; }

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