using backend.Dtos.Ingredient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.RecipeIngredient;

public class RecipeIngredientWithoutId
{
    [Required]
    public required IngredientPublic Ingredient { get; set; }
    [Required]
    [Precision(6, 2)]
    public required decimal Amount { get; set; }
}