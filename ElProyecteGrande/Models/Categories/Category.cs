using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

public class Category : BaseModel
{
    [Required]
    public required Cuisine Cuisine { get; set; }
    [Required]
    public required List<Meal> Meals { get; set; }
    [Required]
    public required List<Diet> Diets { get; set; }
    [Required]
    public required MealType MealType { get; set; }
}
