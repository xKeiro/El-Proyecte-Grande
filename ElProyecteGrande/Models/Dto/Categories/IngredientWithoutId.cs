using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.DTOs.Categories;

/// <summary>
/// Different type of ingredients, like - Hungarian, Italian, French, etc.
/// </summary>

[Index(nameof(Name), IsUnique = true)]
public class IngredientWithoutId
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    public string UnitOfMeasure { get; set; }

    public void MapTo(Ingredient ingredient)
    {
        ingredient.Name = Name;
        ingredient.UnitOfMeasure = UnitOfMeasure;
    }
}
