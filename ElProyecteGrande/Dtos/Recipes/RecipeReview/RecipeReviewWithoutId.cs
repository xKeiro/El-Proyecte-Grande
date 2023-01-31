using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Recipes.RecipeReview;

public class RecipeReviewWithoutId
{
    [Required]
    public required User User { get; set; }

    [Required]
    public required RecipeFull Recipe { get; set; }

    [Required]
    [Range(1, 5)]
    public required int Rate { get; set; }

    public string? Review { get; set; }
}
