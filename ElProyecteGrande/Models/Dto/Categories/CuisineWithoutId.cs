using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.DTOs.Categories;

/// <summary>
/// Different type of cuisines, like - Hungarian, Italian, French, etc.
/// </summary>

[Index(nameof(Name), IsUnique = true)]
public class CuisineWithoutId
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public required string Name { get; set; }

    public void MapTo(Cuisine cuisine)
    {
        cuisine.Name = Name;
    }
}
