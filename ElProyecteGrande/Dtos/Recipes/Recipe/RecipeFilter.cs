using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Recipes.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.Recipe
{
    public class RecipeFilter
    {
        [StringLength(120, MinimumLength = 2)]
        public required string? Name { get; set; } = null;
        [MinLength(1)]
        public IEnumerable<int>? IngredientIds { get; set; } = null;
        [MinLength(1)]
        public IEnumerable<int>? CuisineIds { get; set; } = null;
        [MinLength(1)]
        public IEnumerable<int>? MealTimeIds { get; set; } = null;
        [MinLength(1)]
        public IEnumerable<int>? DietIds { get; set; } = null;
        [MinLength(1)]
        public IEnumerable<int>? DishTypeIds { get; set; } = null;
        public int? MaxNumberOfNotOwnedIngredients { get; set; } = null;
    }
}
