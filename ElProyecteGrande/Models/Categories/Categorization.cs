using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

public class Categorization : BaseModel
{
    [Required]
    public required Cuisine Cuisine { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<MealTime> MealTimes { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<Diet> Diets { get; set; }
    [Required]
    public required DishType DishType { get; set; }
}
