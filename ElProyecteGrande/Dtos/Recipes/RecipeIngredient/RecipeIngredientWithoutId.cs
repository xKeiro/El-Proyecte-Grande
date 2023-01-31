using ElProyecteGrande.Dtos.Ingredient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.RecipeIngredient;

public class RecipeIngredientWithoutId
{
    [Required]
    public required IngredientFull Ingredient { get; set; }
    [Required]
    [Precision(6, 2)]
    public required decimal Amount { get; set; }
}
