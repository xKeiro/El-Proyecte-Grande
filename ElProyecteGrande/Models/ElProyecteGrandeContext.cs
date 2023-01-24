using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Models;

public class ElProyecteGrandeContext : DbContext
{
    public ElProyecteGrandeContext(DbContextOptions<ElProyecteGrandeContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; } = default!;
    public DbSet<Ingredient> Ingredients { get; set;} = default!;
    public DbSet<RecipeReview> RecipeReviews { get; set; } = default!;
    public DbSet<UserRecipe> UserRecipes { get; set; } = default!;
    public DbSet<UserRecipeStatus> UserRecipeStatuses { get; set; } = default!;
}
