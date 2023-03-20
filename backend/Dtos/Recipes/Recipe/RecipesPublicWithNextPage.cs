using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.Recipe;

public class RecipesPublicWithNextPage
{
    [Required]
    public required int? NextPage { get; set; }
    [Required]
    public required List<RecipePublic> Recipes { get; set; }
}
