using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

public class Categorization : BaseModel
{
    [Required]
    public required Cuisine Cuisine { get; set; }
    [Required]
    public required List<MealTime> Meals { get; set; }
    [Required]
    public required List<Diet> Diets { get; set; }
    [Required]
    public required DishType DishType { get; set; }
}
