using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe;

public class RecipeWithoutId
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    required public string Name { get; set; }

    [Required]
    required public string Description { get; set; }

    [Required]
    [MinLength(1)]
    required public ICollection<RecipeIngredientPublic> RecipeIngredients { get; set; }

    [Required]
    public required CuisinePublic Cuisine { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<MealTimePublic> MealTimes { get; set; }
    [Required]
    [MinLength(1)]
    public required ICollection<DietPublic> Diets { get; set; }
    [Required]
    public required DishTypePublic DishType { get; set; }
}