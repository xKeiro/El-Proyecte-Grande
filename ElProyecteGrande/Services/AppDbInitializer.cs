using ElProyecteGrande.Models.Categories;

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
            }
        }
    }
}