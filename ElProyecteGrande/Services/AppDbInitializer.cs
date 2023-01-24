﻿using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Users;

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
                if (!context.Cuisines.Any())
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
                }

                // Meal Time
                if (!context.MealTimes.Any())
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
                }

                // Dish Type
                if (!context.DishTypes.Any())
                {
                    context.DishTypes.AddRange(new List<DishType>()
                    {
                        new() { Name = "Pasta" },
                        new() { Name = "Pizza" },
                        new() { Name = "Salad" },
                        new() { Name = "Soup" },
                        new() { Name = "Stew" },
                        new() { Name = "Dessert" },
                        new() { Name = "Roast" },
                        new() { Name = "Meat" },
                        new() { Name = "Sandwich" },
                    });
                    context.SaveChanges();
                }

                if (context.Ingredients.Any())
                {
                    return;
                }

                //Ingredients
                Ingredient penne = new Ingredient { Name = "Penne Pasta", UnitOfMeasure = "oz" };
                Ingredient tomato = new Ingredient { Name = "Tomatoes", UnitOfMeasure = "lb" };
                Ingredient basil = new Ingredient { Name = "Basil", UnitOfMeasure = "g" };
                Ingredient parmesan = new Ingredient { Name = "Parmesan", UnitOfMeasure = "oz" };
                Ingredient chicken = new Ingredient { Name = "Chicken Breast", UnitOfMeasure = "lb" };
                Ingredient romanianLettuce = new Ingredient
                { Name = "Romaine Lettuce", UnitOfMeasure = "bunch" };
                Ingredient flour = new Ingredient { Name = "Flour", UnitOfMeasure = "cup" };
                Ingredient sugar = new Ingredient { Name = "Sugar", UnitOfMeasure = "cup" };
                Ingredient eggs = new Ingredient { Name = "Eggs", UnitOfMeasure = "unit" };
                Ingredient chocolateChip = new Ingredient { Name = "Chocolate Chip", UnitOfMeasure = "cup" };
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
                context.Users.AddRange(user1, user2);
                context.SaveChanges();

                var user3 = new User
                {
                    Username = "MichaelSmit",
                    EmailAddress = "smith@example.com",
                    Password = "pw1234567",
                    IsAdmin = false
                };
                context.Users.AddRange(user1, user2);
                context.SaveChanges();

            }
        }
    }
}