using ElProyecteGrande.Models;
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

                if (context == null)
                {
                    return;
                }
                context.Database.EnsureCreated();

                //Cuisine
                if (context.Cuisines.Any())
                {
                    return;
                }
                Cuisine hungarian = new() { Name = "Hungarian" };
                Cuisine japanese = new() { Name = "Japanese" };
                Cuisine italian = new() { Name = "Italian" };
                Cuisine indian = new() { Name = "Indian" };
                Cuisine korean = new() { Name = "Korean" };
                Cuisine thai = new() { Name = "Thai" };
                Cuisine mexican = new() { Name = "Mexican" };
                Cuisine american = new() { Name = "American" };
                Cuisine greek = new() { Name = "Greek" };
                Cuisine french = new() { Name = "French" };
                Cuisine turkis = new() { Name = "Turkish" };
                Cuisine german = new() { Name = "German" };
                Cuisine chinese = new() { Name = "Chinese" };
                Cuisine spanish = new() { Name = "Spanish" };
                Cuisine english = new() { Name = "English" };
                Cuisine irish = new() { Name = "Irish" };
                Cuisine scottish = new() { Name = "Scottish" };
                Cuisine russian = new() { Name = "Russian" };
                Cuisine polish = new() { Name = "Polish" };
                Cuisine czech = new() { Name = "Czech" };
                Cuisine swedish = new() { Name = "Swedish" };
                Cuisine danish = new() { Name = "Danish" };
                Cuisine norwegian = new() { Name = "Norwegian" };
                Cuisine finnish = new() { Name = "Finnish" };
                Cuisine belgian = new() { Name = "Belgian" };
                Cuisine dutch = new() { Name = "Dutch" };
                Cuisine portuguese = new() { Name = "Portuguese" };
                Cuisine brazilian = new() { Name = "Brazilian" };
                Cuisine argentinian = new() { Name = "Argentinian" };
                Cuisine australian = new() { Name = "Australian" };
                context.Cuisines.AddRange(hungarian, japanese, italian, indian, korean, thai, mexican, american, greek, french, turkis, german, chinese, spanish, english, irish, scottish, russian, polish, czech, swedish, danish, norwegian, finnish, belgian, dutch, portuguese, brazilian, argentinian, australian);
                context.SaveChanges();

                // Meal Time
                if (context.MealTimes.Any())
                {
                    return;
                }
                MealTime breakfast = new() { Name = "Breakfast" };
                MealTime elevenses = new() { Name = "Elevenses" };
                MealTime lunch = new() { Name = "Lunch" };
                MealTime snack = new() { Name = "Snack" };
                MealTime tea = new() { Name = "Tea" };
                MealTime supper = new() { Name = "Supper" };
                MealTime dinner = new() { Name = "Dinner" };
                MealTime brunch = new() { Name = "Brunch" };
                context.MealTimes.AddRange(breakfast, elevenses, lunch, snack, tea, supper, dinner, brunch);
                context.SaveChanges();

                // Dish Type
                if (context.DishTypes.Any())
                {
                    return;
                }
                DishType pasta = new() { Name = "Pasta" };
                DishType pizza = new() { Name = "Pizza" };
                DishType salad = new() { Name = "Salad" };
                DishType soup = new() { Name = "Soup" };
                DishType stew = new() { Name = "Stew" };
                DishType dessert = new() { Name = "Dessert" };
                DishType roast = new() { Name = "Roast" };
                DishType meat = new() { Name = "Meat" };
                DishType sandwich = new() { Name = "Sandwich" };
                DishType curry = new() { Name = "Curry" };
                DishType pie = new() { Name = "Pie" };
                DishType cake = new() { Name = "Cake" };
                DishType bread = new() { Name = "Bread" };
                DishType pastry = new() { Name = "Pastry" };
                DishType sauce = new() { Name = "Sauce" };
                DishType drink = new() { Name = "Drink" };
                DishType appetizer = new() { Name = "Appetizer" };
                DishType side = new() { Name = "Side" };
                DishType iceCream = new() { Name = "Ice Cream" };
                DishType smoothie = new() { Name = "Smoothie" };
                DishType dip = new() { Name = "Dip" };
                DishType dressing = new() { Name = "Dressing" };
                context.DishTypes.AddRange(pasta, pizza, salad, soup, stew, dessert, roast, meat, sandwich, curry, pie, cake, bread, pastry, sauce, drink, appetizer, side, iceCream, smoothie, dip, dressing);
                context.SaveChanges();

                // Diets
                if (context.Diets.Any())
                {
                    return;
                }
                
                Diet vegetarian = new() { Name = "Vegetarian" };
                Diet vegan = new() { Name = "Vegan" };
                Diet glutenFree = new() { Name = "Gluten Free" };
                Diet dairyFree = new() { Name = "Dairy Free" };
                Diet nutFree = new() { Name = "Nut Free" };
                Diet eggFree = new() { Name = "Egg Free" };
                Diet paleo = new() { Name = "Paleo" };
                Diet primal = new() { Name = "Primal" };
                Diet whole30 = new() { Name = "Whole30" };
                Diet keto = new() { Name = "Keto" };
                Diet pescatarian = new() { Name = "Pescatarian" };
                Diet ketogenic = new() { Name = "Ketogenic" };
                Diet lowCarb = new() { Name = "Low Carb" };
                Diet lowFat = new() { Name = "Low Fat" };
                Diet lowSodium = new() { Name = "Low Sodium" };
                Diet lowSugar = new() { Name = "Low Sugar" };
                Diet highFiber = new() { Name = "High Fiber" };
                Diet highProtein = new() { Name = "High Protein" };
                Diet highIron = new() { Name = "High Iron" };
                Diet highCalcium = new() { Name = "High Calcium" };
                Diet highPotassium = new() { Name = "High Potassium" };
                Diet highVitaminA = new() { Name = "High Vitamin A" };
                Diet highVitaminC = new() { Name = "High Vitamin C" };
                Diet highVitaminD = new() { Name = "High Vitamin D" };
                Diet highVitaminE = new() { Name = "High Vitamin E" };
                Diet highVitaminK = new() { Name = "High Vitamin K" };
                Diet highVitaminB1 = new() { Name = "High Vitamin B1" };
                Diet highVitaminB2 = new() { Name = "High Vitamin B2" };
                Diet highVitaminB3 = new() { Name = "High Vitamin B3" };
                Diet highVitaminB5 = new() { Name = "High Vitamin B5" };
                Diet highVitaminB6 = new() { Name = "High Vitamin B6" };
                Diet highVitaminB12 = new() { Name = "High Vitamin B12" };
                Diet highFolate = new() { Name = "High Folate" };
                Diet highBiotin = new() { Name = "High Biotin" };
                Diet highCholine = new() { Name = "High Choline" };
                Diet highZinc = new() { Name = "High Zinc" };
                Diet highCopper = new() { Name = "High Copper" };
                Diet highManganese = new() { Name = "High Manganese" };
                Diet highSelenium = new() { Name = "High Selenium" };
                Diet highChromium = new() { Name = "High Chromium" };
                Diet highMolybdenum = new() { Name = "High Molybdenum" };
                Diet highIodine = new() { Name = "High Iodine" };
                Diet highMagnesium = new() { Name = "High Magnesium" };
                Diet highPhosphorus = new() { Name = "High Phosphorus" };
                context.Diets.AddRange(vegetarian, vegan, glutenFree, dairyFree, nutFree, eggFree, paleo, primal, whole30, keto, pescatarian, ketogenic, lowCarb, lowFat, lowSodium, lowSugar, highFiber, highProtein, highIron, highCalcium, highPotassium, highVitaminA, highVitaminC, highVitaminD, highVitaminE, highVitaminK, highVitaminB1, highVitaminB2, highVitaminB3, highVitaminB5, highVitaminB6, highVitaminB12, highFolate, highBiotin, highCholine, highZinc, highCopper, highManganese, highSelenium, highChromium, highMolybdenum, highIodine, highMagnesium, highPhosphorus);




                //Categorization
                if (context.Categorizations.Any())
                {
                    return;
                }
                Categorization italianPasta = new()
                {
                    Cuisine = italian,
                    DishType = pasta,
                    Diets = new List<Diet>()
                    {
                        vegetarian
                    },
                    MealTimes = new List<MealTime>()
                    {
                        lunch
                    }
                };
                context.Categorizations.AddRange(italianPasta);


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