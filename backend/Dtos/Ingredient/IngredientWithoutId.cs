using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Ingredient;

/// <summary>
/// Different type of ingredients, like - onion, penne, tomato etc.
/// </summary>
public class IngredientWithoutId
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(60, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    [StringLength(25, MinimumLength = 1)]
    public required string UnitOfMeasure { get; set; }
    [Required]
    public required int Calorie { get; set; }
}