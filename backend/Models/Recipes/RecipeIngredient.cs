using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Recipes;

public class RecipeIngredient : BaseModel
{
    [Required]
    public required Ingredient Ingredient { get; set; }
    [Required]
    [Range(0.01, double.MaxValue)]
    [Precision(6, 2)]
    public required decimal Amount { get; set; }
}