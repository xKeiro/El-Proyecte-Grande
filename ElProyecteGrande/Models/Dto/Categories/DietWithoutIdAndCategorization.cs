using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.DTOs.Categories;

/// <summary>
/// Different type of diets, like - vegetarian, gluten free, paleo etc.
/// </summary>

[Index(nameof(Name), IsUnique = true)]
public class DietWithoutIdAndCategorization
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public required string Name { get; set; }


    public void MapTo(Diet diet)
    {
        diet.Name = Name;
    }
}