﻿using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Users;
using System.IO;
using System.Reflection;
using System;
using ElProyecteGrande.Models.Recipes;

namespace ElProyecteGrande.Services
{
    public static class AppDbInitializer
    {
        /// <summary>
        /// Adds initial data to DB
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ElProyecteGrandeContext>();

                context.Database.EnsureCreated();

                //Cuisine
                /*if (!context.Cuisines.Any())
                {
                    context.Cuisines.AddRange(new List<Cuisine>()
                    {
                        new() { Name = "Hungarian" },
                        new() { Name = "Japanese" },
                        new() { Name = "Italian" },
                        new() { Name = "Indian" },
                        new() { Name = "Korean" },
                        new() { Name = "Thai" },
                        new() { Name = "Mexican" },
                        new() { Name = "American" },
                        new() { Name = "Greek" },
                        new() { Name = "French" },
                        new() { Name = "Turkish" },
                        new() { Name = "German" },
                        new() { Name = "Chinese" },
                        new() { Name = "Spanish" },
                        new() { Name = "English" }
                    });
                    context.SaveChanges();
                }*/

                //Cuisine refactor
                if (context.Cuisines.Any())
                {
                    return;
                }
                var hungarianCuisine = new Cuisine { Name = "Hungarian" };
                var italianCuisine = new Cuisine { Name = "Italian" };
                var japaneseCuisine = new Cuisine { Name = "Japanese" };
                var indianCuisine = new Cuisine { Name = "Indian" };
                var koreanCuisine = new Cuisine { Name = "Korean" };
                var thaiCuisine = new Cuisine { Name = "Thai" };
                var mexicanCuisine = new Cuisine { Name = "Mexican" };
                var americanCuisine = new Cuisine { Name = "American" };
                var greekCuisine = new Cuisine { Name = "Greek" };
                var frenchCuisine = new Cuisine { Name = "American" };
                context.Cuisines.AddRange(hungarianCuisine, italianCuisine, japaneseCuisine, indianCuisine,
                    koreanCuisine,thaiCuisine, americanCuisine,greekCuisine,mexicanCuisine,frenchCuisine);
                context.SaveChanges();

                // Meal Time
                /*if (!context.MealTimes.Any())
                {
                    context.MealTimes.AddRange(new List<MealTime>()
                    {
                        new() { Name = "Breakfast" },
                        new() { Name = "Elevenses" },
                        new() { Name = "Lunch" },
                        new() { Name = "Snack" },
                        new() { Name = "Tea" },
                        new() { Name = "Supper" },
                        new() { Name = "Dinner" }
                    });
                    context.SaveChanges();
                }*/

                //Mealtime refactor
                if (context.MealTimes.Any())
                {
                    return;
                }
                var lunchMealTime = new MealTime { Name = "Lunch" };
                var dinnerMealTime = new MealTime { Name = "Dinner" };
                var breakfastMealTime = new MealTime { Name = "Breakfast" };
                var elevensesMealTime = new MealTime { Name = "Elevenses" };
                var snackMealTimeMealTime = new MealTime { Name = "Snack" };
                var teaMealTime = new MealTime { Name = "Tea" };
                context.MealTimes.AddRange(lunchMealTime, dinnerMealTime, breakfastMealTime, elevensesMealTime, snackMealTimeMealTime,
                    teaMealTime);
                context.SaveChanges();

                // Dish Type
                /*if (!context.DishTypes.Any())
                {
                    context.DishTypes.AddRange(new List<DishType>()
                    {
                        new() { Name = "Pasta" },
                        new() { Name = "Pizza" },
                        new() { Name = "Salad" },
                        new() { Name = "Soup" },
                        new() { Name = "Stew" },
                        new() { Name = "Stew" },
                        new() { Name = "Dessert" },
                        new() { Name = "Roast" },
                        new() { Name = "Meat" },
                        new() { Name = "Sandwich" },
                    });
                    context.SaveChanges();
                }*/

                //Dish Type II
                if (context.DishTypes.Any())
                {
                    return;
                }
                var pasta = new DishType { Name = "Pasta" };
                var soup = new DishType { Name = "Soup" };
                context.DishTypes.AddRange(pasta, soup);
                context.SaveChanges();

                //Diet
                /*if (!context.Diets.Any())
                {
                    context.Diets.AddRange(new List<Diet>()
                    {
                        new() { Name = "Vegetarian" },
                        new() { Name = "Gluten Free" },
                        new() { Name = "Paleo" },
                        new() { Name = "Diary Free" },
                        new() { Name = "Vegan" },
                        new() { Name = "Low-Carb" },
                    });
                    context.SaveChanges();
                }*/

                //Diet II
                /*if (context.Diets.Any())
                {
                    return;
                }
                var vegetarian = new Diet { Name = "Vegetarian" };
                var glutenFree = new Diet { Name = "Gluten Free" };
                context.Diets.AddRange(vegetarian, glutenFree);
                context.SaveChanges();

                //Categorization
                if (context.Categorizations.Any())
                {
                    return;
                }
                var categorization1 = new Categorization
                {
                    Cuisine = italian,
                    Meals = new List<MealTime> { lunch, dinner },
                    Diets = new List<Diet> { vegetarian},
                    DishType = pasta,
                };
                var categorization2= new Categorization
                {
                    Cuisine = hungarian,
                    Meals = new List<MealTime> {dinner },
                    Diets = new List<Diet> { glutenFree },
                    DishType = soup,
                };
                context.Categorizations.AddRange(categorization1, categorization2);
                context.SaveChanges();


                if (context.Ingredients.Any())
                {
                    return;
                }*/

                //Ingredients
                Ingredient penne = new Ingredient { Name = "Penne Pasta", UnitOfMeasure = "g" };
                Ingredient tomato = new Ingredient { Name = "Tomatoes", UnitOfMeasure = "g" };
                Ingredient basil = new Ingredient { Name = "Basil", UnitOfMeasure = "g" };
                Ingredient parmesan = new Ingredient { Name = "Parmesan", UnitOfMeasure = "g" };
                Ingredient chicken = new Ingredient { Name = "Chicken Breast", UnitOfMeasure = "g" };
                Ingredient romanianLettuce = new Ingredient
                { Name = "Romaine Lettuce", UnitOfMeasure = "bunch" };
                Ingredient flour = new Ingredient { Name = "Flour", UnitOfMeasure = "g" };
                Ingredient sugar = new Ingredient { Name = "Sugar", UnitOfMeasure = "" };
                Ingredient eggs = new Ingredient { Name = "Eggs", UnitOfMeasure = "unit" };
                Ingredient chocolateChip = new Ingredient { Name = "Chocolate Chip", UnitOfMeasure = "g" };
                context.Ingredients.AddRange(
                    penne,
                    tomato,
                    basil,
                    parmesan,
                    chicken,
                    romanianLettuce,
                    flour,
                    sugar,
                    eggs,
                    chocolateChip
                );
                context.SaveChanges();



                /*//Recipe ingredients
                if (context.RecipeIngredients.Any())
                {
                    return;
                }
                var ingredient1 = new RecipeIngredient { Amount = 10, Ingredient = tomato, Recipe = tomatoPasta };
                var ingredient2 = new RecipeIngredient { Amount = 25, Ingredient = basil, Recipe = tomatoPasta };
                context.RecipeIngredients.AddRange(ingredient1, ingredient2);
                context.SaveChanges();*/

                //Recipe
                /*var recipe = new Recipe
                {
                    Name = "Tomato Basil Pasta",
                    Description = "Penne pasta tossed with fresh tomatoes, basil, and Parmesan",
                    Categorization = categorization1,
                    RecipeIngredients = new List<RecipeIngredient>()
                };

                // Add ingredients to recipe
                recipe.RecipeIngredients.Add(new RecipeIngredient { Recipe = recipe, Ingredient = context.Ingredients.FirstOrDefault(i => i.Id == 1), Amount = 8 });
                recipe.RecipeIngredients.Add(new RecipeIngredient { Recipe = recipe, Ingredient = context.Ingredients.FirstOrDefault(i => i.Id == 2), Amount = 2 });
                recipe.RecipeIngredients.Add(new RecipeIngredient { Recipe = recipe, Ingredient = context.Ingredients.FirstOrDefault(i => i.Id == 3), Amount = 1 });
                recipe.RecipeIngredients.Add(new RecipeIngredient { Recipe = recipe, Ingredient = context.Ingredients.FirstOrDefault(i => i.Id == 4), Amount = 4 });

                var recipe2 = new Recipe
                {
                    Name = "French Onion Soup",
                    Description = "Rich beef broth with caramelized onions and croutons",
                    Categorization = categorization2,
                    RecipeIngredients = new List<RecipeIngredient>()
                };

                // Add ingredients to recipe
                recipe2.RecipeIngredients.Add(new RecipeIngredient
                    { Recipe = recipe, Ingredient = context.Ingredients.FirstOrDefault(i => i.Id == 5), Amount = 8 });
                    // Add recipe to the database
                context.Recipes.Add(recipe);
                context.Recipes.Add(recipe2);
                context.SaveChanges();*/

                //Users
                if (context.Users.Any())
                {
                    return;
                }
                var user1 = new User
                {
                    Username = "FoodLover123",
                    EmailAddress = "ilovefood@example.com",
                    Password = "12345678",
                    IsAdmin = false
                };
                var user2 = new User
                {
                    Username = "JaneDoe",
                    EmailAddress = "jane@example.com",
                    Password = "87654321",
                    IsAdmin = false
                };

                var user3 = new User
                {
                    Username = "MichaelSmit",
                    EmailAddress = "smith@example.com",
                    Password = "pw1234567",
                    IsAdmin = false
                };
                context.Users.AddRange(user1, user2, user3);
                context.SaveChanges();

            }
        }
    }
}