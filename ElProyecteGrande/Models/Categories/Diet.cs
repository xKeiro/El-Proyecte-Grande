using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

/// <summary>
/// Different type of diets, like - vegetarian, gluten free, paleo etc.
/// </summary>
/// 
[Index(nameof(Name), IsUnique = true)]
public class Diet : BaseCategory
{
    [Required]
    public ICollection<Categorization> Categorizations { get; set; }
}
