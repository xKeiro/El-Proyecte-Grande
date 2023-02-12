using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.RecipeIngredient;

public class RecipeIngredientAddNew
{
    [Required]
    public required int IngredientId { get; set; }
    [Required]
    [Precision(6, 2)]
    public required decimal Amount { get; set; }
}