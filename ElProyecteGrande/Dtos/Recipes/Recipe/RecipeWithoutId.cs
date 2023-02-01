using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe;

public class RecipeWithoutId
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }
    
    [Required]
    public required string Description { get; set; }

    [Required]
    [MinLength(1)]
    public required ICollection<RecipeIngredientPublic> RecipeIngredients { get; set; }

    [Required]
    public CuisinePublic Cuisine { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<MealTimePublic> MealTimes { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<DietPublic> Diets { get; set; }
    [Required]
    public DishTypePublic DishType { get; set; }
}
