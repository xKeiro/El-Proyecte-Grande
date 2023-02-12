using backend.Dtos.Recipes.Recipe;
using backend.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.RecipeReview;

public class RecipeReviewWithoutId
{
    [Required]
    public required User User { get; set; }

    [Required]
    public required RecipePublic Recipe { get; set; }

    [Required]
    [Range(1, 5)]
    public required int Rate { get; set; }

    public string? Review { get; set; }
}