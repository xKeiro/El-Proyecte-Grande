using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

/// <summary>
/// Time of a meal, like - breakfast, lunch, dinner
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class MealTime : BaseCategory
{
    [Required]
    public ICollection<Categorization> Categorizations { get; set; }
}
