using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe;

public class RecipeAddNew
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    [MinLength(1)]
    public required ICollection<RecipieIngredientAddNew> RecipieIngredientsAddNew { get; set; }

    [Required]
    public int CuisineId { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<int> MealTimeIds { get; set; }
    [Required]
    [MinLength(1)]
    public ICollection<int> DietIds { get; set; }
    [Required]
    public int DishTypeId { get; set; }
}
