using System.Text.Json;
using backend.Enums;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using backend.Models.Users;

namespace BackendTests.Utils;
public static class Util
{
    public static User User1 = new()
    {
        Id = 1,
        Username = "longdon",
        EmailAddress = "ding@dong.com",
        FirstName = null,
        LastName = null,
        IsAdmin = false,
        Password = "12345"
    };

    public static User User2 = new()
    {
        Id = 2,
        Username = "whiskers",
        EmailAddress = "why@you.net",
        FirstName = "John",
        LastName = "Faruga",
        IsAdmin = false,
        Password = "12345"
    };

    public static Recipe ChickenCurryRecipe = new()
    {
        Id = 1,
        Name = "Chicken Curry",
        Description = "A flavorful and low-fat Indian dish with chicken, yogurt, and spices",
        Difficulty = PreparationDifficulty.Medium,
        RecipeIngredients = new List<RecipeIngredient>(),
        Cuisine = new Cuisine() { Name = "Indian"},
        MealTimes = new List<MealTime>(),
        Diets = new List<Diet>(),
        DishType = new DishType() { Name = "Curry"},
        PreparationSteps = new List<PreparationStep>()
    };

    public static Recipe PeanutMandelSaladRecipe = new()
    {
        Id = 2,
        Name = "Peanut Mandel Salad",
        Description = "A crunchy and refreshing salad with cabbage, carrot, scallion, cilantro, peanuts and mandel, tossed in a tangy and sweet dressing",
        Difficulty = PreparationDifficulty.Easy,
        RecipeIngredients = new List<RecipeIngredient>(),
        Cuisine = new Cuisine() { Name = "Thai" },
        MealTimes = new List<MealTime>(),
        Diets = new List<Diet>(),
        DishType = new DishType() { Name = "Salad" },
        PreparationSteps = new List<PreparationStep>()
    };

    public static Recipe SpinachOmeletteRecipeVariation = new()
    {
        Id = 3,
        Name = "Spinach Omelette Variation",
        Description = "A simple and nutritious breakfast with eggs, cheese, spinach, tomato and basil",
        Difficulty = PreparationDifficulty.Easy,
        RecipeIngredients = new List<RecipeIngredient>(),
        Cuisine = new Cuisine() { Name = "Italian" },
        MealTimes = new List<MealTime>(),
        Diets = new List<Diet>(),
        DishType = new DishType() { Name = "Omelette" },
        PreparationSteps = new List<PreparationStep>()
    };

    public static UserRecipeStatus Liked = new() { Name = RecipeStatus.Liked };
    public static UserRecipeStatus Disliked = new() { Name = RecipeStatus.Disliked };
    public static UserRecipeStatus Saved = new() { Name = RecipeStatus.Saved };

    public static List<UserRecipe> UserRecipes = new()
    {
        new()
        {
            Recipe = SpinachOmeletteRecipeVariation,
            User = User1,
            Status = Saved
        },
        new()
        {
            Recipe = PeanutMandelSaladRecipe,
            User = User1,
            Status = Liked
        },
        new()
        {
            Recipe = PeanutMandelSaladRecipe,
            User = User2,
            Status = Liked
        },
        new()
        {
            Recipe = SpinachOmeletteRecipeVariation,
            User = User2,
            Status = Disliked
        },
        new()
        {
            Recipe = ChickenCurryRecipe,
            User = User1,
            Status = Saved
        },
        new()
        {
            Recipe = ChickenCurryRecipe,
            User = User2,
            Status = Liked
        }
    };

    public static List<Recipe> Recipes = new() { ChickenCurryRecipe, PeanutMandelSaladRecipe, SpinachOmeletteRecipeVariation };

    public static void AreEqualByJson(object? expected, object? actual)
    {
        var expectedJson = JsonSerializer.Serialize(expected);
        var actualJson = JsonSerializer.Serialize(actual);
        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
