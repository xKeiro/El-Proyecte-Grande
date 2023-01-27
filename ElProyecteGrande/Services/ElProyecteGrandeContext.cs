using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Enums;
using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElProyecteGrande.Services;

public class ElProyecteGrandeContext : DbContext
{
    public ElProyecteGrandeContext(DbContextOptions<ElProyecteGrandeContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; } = default!;
    public DbSet<RecipeReview> RecipeReviews { get; set; } = default!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = default!;
    public DbSet<Ingredient> Ingredients { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserRecipe> UserRecipes { get; set; } = default!;
    public DbSet<UserRecipeStatus> UserRecipeStatuses { get; set; } = default!;
    public DbSet<Cuisine> Cuisines { get; set; } = default!;
    public DbSet<Diet> Diets { get; set; } = default!;
    public DbSet<MealTime> MealTimes { get; set; } = default!;
    public DbSet<DishType> DishType { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<UserRecipeStatus>()
            .Property(userRecipeStatus => userRecipeStatus.Name)
            .HasConversion(new EnumToStringConverter<RecipeStatus>());
    }
}
