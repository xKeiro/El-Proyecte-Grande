using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

/// <summary>
/// Different type of ingredients, like - onion, penne, tomato etc.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class Ingredient : BaseModel
{
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    [StringLength(25, MinimumLength = 1)]
    public required string UnitOfMeasure { get; set; }
    [Required]
    public required int Calorie { get; set; }
}