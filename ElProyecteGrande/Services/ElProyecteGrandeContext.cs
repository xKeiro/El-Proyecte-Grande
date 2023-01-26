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

    public DbSet<Recipe> Recipe { get; set; } = default!;
    public DbSet<RecipeReview> RecipeReview { get; set; } = default!;
    public DbSet<RecipeIngredient> RecipeIngredient { get; set; } = default!;
    public DbSet<Ingredient> Ingredient { get; set; } = default!;
    public DbSet<User> User { get; set; } = default!;
    public DbSet<UserRecipe> UserRecipe { get; set; } = default!;
    public DbSet<UserRecipeStatus> UserRecipeStatuse { get; set; } = default!;
    public DbSet<Cuisine> Cuisine { get; set; } = default!;
    public DbSet<Diet> Diet { get; set; } = default!;
    public DbSet<MealTime> MealTime { get; set; } = default!;
    public DbSet<DishType> DietType { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<UserRecipeStatus>()
            .Property(userRecipeStatus => userRecipeStatus.Name)
            .HasConversion(new EnumToStringConverter<RecipeStatus>());
    }
}
