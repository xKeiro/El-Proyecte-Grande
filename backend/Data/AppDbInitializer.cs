using backend.Enums;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using backend.Models.Users;
using backend.Services;
using System;

namespace backend.Data;

public static class AppDbInitializer
{
    /// <summary>
    /// Adds initial data to DB.
    /// </summary>
    /// <param name="applicationBuilder">
    /// The application builder.
    /// </param>
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ElProyecteGrandeContext>();

        if (context == null)
        {
            return;
        }

        _ = context.Database.EnsureCreated();

        // Cuisine
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
        _ = context.SaveChanges();

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
        MealTime dessert = new() { Name = "Dessert" };
        context.MealTimes.AddRange(breakfast, elevenses, lunch, snack, tea, supper, dinner, brunch, dessert);
        _ = context.SaveChanges();

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
        DishType burrito = new() { Name = "Burrito" };
        DishType omelette = new() { Name = "Omelette" };
        DishType muffin = new() { Name = "Muffin" };
        context.DishTypes.AddRange(pasta, pizza, salad, soup, stew, roast, meat, sandwich, curry, pie, cake, bread, pastry, sauce, drink, appetizer, side, iceCream, smoothie, dip, dressing, burrito, omelette, muffin);
        _ = context.SaveChanges();

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
        _ = context.SaveChanges();

        if (context.Ingredients.Any())
        {
            return;
        }

        // Ingredients
        var penne = new Ingredient { Name = "Penne Pasta", UnitOfMeasure = "g", Calorie = 352 };
        var tomato = new Ingredient { Name = "Tomato", UnitOfMeasure = "pcs", Calorie = 18 };
        var cheese = new Ingredient { Name = "Cheese", UnitOfMeasure = "g", Calorie = 402 };
        var basil = new Ingredient { Name = "Basil", UnitOfMeasure = "g", Calorie = 23 };
        var garlic = new Ingredient { Name = "Garlic", UnitOfMeasure = "cloves", Calorie = 4 };
        var oliveOil = new Ingredient { Name = "Olive Oil", UnitOfMeasure = "ml", Calorie = 884 };
        var salt = new Ingredient { Name = "Salt", UnitOfMeasure = "g", Calorie = 0 };
        var pepper = new Ingredient { Name = "Pepper", UnitOfMeasure = "g", Calorie = 251 };
        var chickpeas = new Ingredient { Name = "Chickpeas", UnitOfMeasure = "g", Calorie = 164 };
        var coconutMilk = new Ingredient { Name = "Coconut Milk", UnitOfMeasure = "ml", Calorie = 230 };
        var onion = new Ingredient { Name = "Onion", UnitOfMeasure = "pcs", Calorie = 44 };
        var ginger = new Ingredient { Name = "Ginger", UnitOfMeasure = "g", Calorie = 80 };
        var curryPowder = new Ingredient { Name = "Curry Powder", UnitOfMeasure = "g", Calorie = 325 };
        var cumin = new Ingredient { Name = "Cumin", UnitOfMeasure = "g", Calorie = 375 };
        var turmeric = new Ingredient { Name = "Turmeric", UnitOfMeasure = "g", Calorie = 312 };
        var coriander = new Ingredient { Name = "Coriander", UnitOfMeasure = "g", Calorie = 298 };
        var vegetableOil = new Ingredient { Name = "Vegetable Oil", UnitOfMeasure = "ml", Calorie = 884 };
        var rice = new Ingredient { Name = "Rice", UnitOfMeasure = "g", Calorie = 130 };
        var water = new Ingredient { Name = "Water", UnitOfMeasure = "ml", Calorie = 0 };
        var chicken = new Ingredient { Name = "Chicken", UnitOfMeasure = "g", Calorie = 239 };
        var blackBeans = new Ingredient { Name = "Black Beans", UnitOfMeasure = "g", Calorie = 132 };
        var corn = new Ingredient { Name = "Corn", UnitOfMeasure = "g", Calorie = 86 };
        var salsa = new Ingredient { Name = "Salsa", UnitOfMeasure = "ml", Calorie = 36 };
        var lettuce = new Ingredient { Name = "Lettuce", UnitOfMeasure = "g", Calorie = 15 };
        var sourCream = new Ingredient { Name = "Sour Cream", UnitOfMeasure = "ml", Calorie = 193 };
        var glutenFreeTortilla = new Ingredient { Name = "Gluten-Free Tortilla", UnitOfMeasure = "pcs", Calorie = 130 };
        var spinach = new Ingredient { Name = "Spinach", UnitOfMeasure = "g", Calorie = 23 };
        var cherryTomatoes = new Ingredient { Name = "Cherry Tomatoes", UnitOfMeasure = "pcs", Calorie = 3 };
        var mozzarella = new Ingredient { Name = "Mozzarella", UnitOfMeasure = "g", Calorie = 280 };
        var butter = new Ingredient { Name = "Butter", UnitOfMeasure = "g", Calorie = 717 };
        var vegetableBroth = new Ingredient { Name = "Vegetable Broth", UnitOfMeasure = "ml", Calorie = 9 };
        var lemongrass = new Ingredient { Name = "Lemongrass", UnitOfMeasure = "g", Calorie = 99 };
        var limeJuice = new Ingredient { Name = "Lime Juice", UnitOfMeasure = "ml", Calorie = 22 };
        var soySauce = new Ingredient { Name = "Soy Sauce", UnitOfMeasure = "ml", Calorie = 53 };
        var brownSugar = new Ingredient { Name = "Brown Sugar", UnitOfMeasure = "g", Calorie = 380 };
        var redCurryPaste = new Ingredient { Name = "Red Curry Paste", UnitOfMeasure = "g", Calorie = 114 };
        var tofu = new Ingredient { Name = "Tofu", UnitOfMeasure = "g", Calorie = 76 };
        var mushrooms = new Ingredient { Name = "Mushrooms", UnitOfMeasure = "g", Calorie = 22 };
        var cilantro = new Ingredient { Name = "Cilantro", UnitOfMeasure = "g", Calorie = 23 };
        var yogurt = new Ingredient { Name = "Yogurt", UnitOfMeasure = "ml", Calorie = 61 };
        var garamMasala = new Ingredient { Name = "Garam Masala", UnitOfMeasure = "g", Calorie = 375 };
        var banana = new Ingredient { Name = "Banana", UnitOfMeasure = "g", Calorie = 89 };
        var oatmeal = new Ingredient { Name = "Oatmeal", UnitOfMeasure = "g", Calorie = 68 };
        var almondMilk = new Ingredient { Name = "Almond Milk", UnitOfMeasure = "ml", Calorie = 15 };
        var egg = new Ingredient { Name = "Egg", UnitOfMeasure = "pcs", Calorie = 143 };
        var bakingPowder = new Ingredient { Name = "Baking Powder", UnitOfMeasure = "g", Calorie = 53 };
        var vanillaExtract = new Ingredient { Name = "Vanilla Extract", UnitOfMeasure = "ml", Calorie = 288 };
        var cinnamon = new Ingredient { Name = "Cinnamon", UnitOfMeasure = "g", Calorie = 247 };
        var nutmeg = new Ingredient { Name = "Nutmeg", UnitOfMeasure = "g", Calorie = 525 };
        var blueberry = new Ingredient { Name = "Blueberry", UnitOfMeasure = "g", Calorie = 57 };
        var walnut = new Ingredient { Name = "Walnut", UnitOfMeasure = "g", Calorie = 654 };
        var peanuts = new Ingredient { Name = "Peanuts", UnitOfMeasure = "g", Calorie = 567 };
        var mandel = new Ingredient { Name = "Mandel", UnitOfMeasure = "g", Calorie = 575 };
        var cabbage = new Ingredient { Name = "Cabbage", UnitOfMeasure = "g", Calorie = 25 };
        var carrot = new Ingredient { Name = "Carrot", UnitOfMeasure = "g", Calorie = 41 };
        var scallion = new Ingredient { Name = "Scallion", UnitOfMeasure = "g", Calorie = 32 };
        var sesameOil = new Ingredient { Name = "Sesame Oil", UnitOfMeasure = "ml", Calorie = 884 };
        var mapleSyrup = new Ingredient { Name = "Maple Syrup", UnitOfMeasure = "ml", Calorie = 260 };
        var nutella = new Ingredient { Name = "Nutella", UnitOfMeasure = "g", Calorie = 546 };
        var flour = new Ingredient { Name = "Flour", UnitOfMeasure = "g", Calorie = 364 };
        var heavyCream = new Ingredient { Name = "Heavy Cream", UnitOfMeasure = "ml", Calorie = 340 };
        var chocolate = new Ingredient { Name = "Chocolate", UnitOfMeasure = "g", Calorie = 546 };
        var sprinkles = new Ingredient { Name = "Sprinkles", UnitOfMeasure = "g", Calorie = 389 };
        var parmesan = new Ingredient { Name = "Parmesan", UnitOfMeasure = "g" , Calorie = 411 };
        var sugar = new Ingredient { Name = "Sugar", UnitOfMeasure = "g", Calorie = 387};
        var chocolateChip = new Ingredient { Name = "Chocolate Chip", UnitOfMeasure = "g", Calorie = 479 };

        context.Ingredients.AddRange(
            penne,
            tomato,
            cheese,
            basil,
            garlic,
            oliveOil,
            salt,
            pepper,
            chickpeas,
            coconutMilk,
            onion,
            ginger,
            curryPowder,
            cumin,
            turmeric,
            coriander,
            vegetableOil,
            rice,
            water,
            chicken,
            blackBeans,
            corn,
            salsa,
            lettuce,
            sourCream,
            glutenFreeTortilla,
            spinach,
            cherryTomatoes,
            mozzarella,
            butter,
            vegetableBroth,
            lemongrass,
            limeJuice,
            soySauce,
            brownSugar,
            redCurryPaste,
            tofu,
            mushrooms,
            cilantro,
            yogurt,
            garamMasala,
            banana,
            oatmeal,
            almondMilk,
            egg,
            bakingPowder,
            vanillaExtract,
            cinnamon,
            nutmeg,
            blueberry,
            walnut,
            peanuts,
            mandel,
            cabbage,
            carrot,
            scallion,
            sesameOil,
            mapleSyrup,
            nutella,
            flour,
            heavyCream,
            chocolate,
            sprinkles,
            parmesan,
            sugar,
            chocolateChip
        );
        _ = context.SaveChanges();

        // Recipe ingredients
        if (context.RecipeIngredients.Any())
        {
            return;
        }

        var penneIngredient1 = new RecipeIngredient { Amount = 250, Ingredient = penne };
        var tomatoIngredient1 = new RecipeIngredient { Amount = 4, Ingredient = tomato };
        var cheeseIngredient1 = new RecipeIngredient { Amount = 100, Ingredient = cheese };
        var basilIngredient1 = new RecipeIngredient { Amount = 10, Ingredient = basil };
        var garlicIngredient1 = new RecipeIngredient { Amount = 2, Ingredient = garlic };
        var oliveOilIngredient1 = new RecipeIngredient { Amount = 30, Ingredient = oliveOil };
        var saltIngredient1 = new RecipeIngredient { Amount = 5, Ingredient = salt };
        var pepperIngredient1 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var chickpeasIngredient2 = new RecipeIngredient { Amount = 400, Ingredient = chickpeas };
        var coconutMilkIngredient2 = new RecipeIngredient { Amount = 400, Ingredient = coconutMilk };
        var onionIngredient2 = new RecipeIngredient { Amount = 1, Ingredient = onion };
        var gingerIngredient2 = new RecipeIngredient { Amount = 20, Ingredient = ginger };
        var garlicIngredient2 = new RecipeIngredient { Amount = 3, Ingredient = garlic };
        var curryPowderIngredient2 = new RecipeIngredient { Amount = 10, Ingredient = curryPowder };
        var cuminIngredient2 = new RecipeIngredient { Amount = 5, Ingredient = cumin };
        var turmericIngredient2 = new RecipeIngredient { Amount = 5, Ingredient = turmeric };
        var corianderIngredient2 = new RecipeIngredient { Amount = 5, Ingredient = coriander };
        var saltIngredient2 = new RecipeIngredient { Amount = 5, Ingredient = salt };
        var pepperIngredient2 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var vegetableOilIngredient2 = new RecipeIngredient { Amount = 30, Ingredient = vegetableOil };
        var riceIngredient2 = new RecipeIngredient { Amount = 200, Ingredient = rice };
        var waterIngredient2 = new RecipeIngredient { Amount = 400, Ingredient = water };
        var chickenIngredient3 = new RecipeIngredient { Amount = 500, Ingredient = chicken };
        var blackBeansIngredient3 = new RecipeIngredient { Amount = 200, Ingredient = blackBeans };
        var cornIngredient3 = new RecipeIngredient { Amount = 100, Ingredient = corn };
        var salsaIngredient3 = new RecipeIngredient { Amount = 100, Ingredient = salsa };
        var cheeseIngredient3 = new RecipeIngredient { Amount = 100, Ingredient = cheese };
        var lettuceIngredient3 = new RecipeIngredient { Amount = 50, Ingredient = lettuce };
        var sourCreamIngredient3 = new RecipeIngredient { Amount = 50, Ingredient = sourCream };
        var glutenFreeTortillaIngredient3 = new RecipeIngredient { Amount = 4, Ingredient = glutenFreeTortilla };
        var saltIngredient3 = new RecipeIngredient { Amount = 5, Ingredient = salt };
        var pepperIngredient3 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var vegetableOilIngredient3 = new RecipeIngredient { Amount = 30, Ingredient = vegetableOil };
        var eggsIngredient4 = new RecipeIngredient { Amount = 4, Ingredient = egg };
        var spinachIngredient4 = new RecipeIngredient { Amount = 100, Ingredient = spinach };
        var cherryTomatoesIngredient4 = new RecipeIngredient { Amount = 8, Ingredient = cherryTomatoes };
        var mozzarellaIngredient4 = new RecipeIngredient { Amount = 50, Ingredient = mozzarella };
        var basilIngredient4 = new RecipeIngredient { Amount = 10, Ingredient = basil };
        var saltIngredient4 = new RecipeIngredient { Amount = 2, Ingredient = salt };
        var pepperIngredient4 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var butterIngredient4 = new RecipeIngredient { Amount = 10, Ingredient = butter };
        var coconutMilkIngredient5 = new RecipeIngredient { Amount = 400, Ingredient = coconutMilk };
        var vegetableBrothIngredient5 = new RecipeIngredient { Amount = 800, Ingredient = vegetableBroth };
        var lemongrassIngredient5 = new RecipeIngredient { Amount = 20, Ingredient = lemongrass };
        var gingerIngredient5 = new RecipeIngredient { Amount = 10, Ingredient = ginger };
        var garlicIngredient5 = new RecipeIngredient { Amount = 5, Ingredient = garlic };
        var limeJuiceIngredient5 = new RecipeIngredient { Amount = 30, Ingredient = limeJuice };
        var soySauceIngredient5 = new RecipeIngredient { Amount = 15, Ingredient = soySauce };
        var brownSugarIngredient5 = new RecipeIngredient { Amount = 10, Ingredient = brownSugar };
        var redCurryPasteIngredient5 = new RecipeIngredient { Amount = 15, Ingredient = redCurryPaste };
        var tofuIngredient5 = new RecipeIngredient { Amount = 200, Ingredient = tofu };
        var mushroomsIngredient5 = new RecipeIngredient { Amount = 100, Ingredient = mushrooms };
        var cilantroIngredient5 = new RecipeIngredient { Amount = 10, Ingredient = cilantro };
        var saltIngredient5 = new RecipeIngredient { Amount = 2, Ingredient = salt };
        var pepperIngredient5 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var vegetableOilIngredient5 = new RecipeIngredient { Amount = 15, Ingredient = vegetableOil };
        var chickenIngredient6 = new RecipeIngredient { Amount = 500, Ingredient = chicken };
        var yogurtIngredient6 = new RecipeIngredient { Amount = 200, Ingredient = yogurt };
        var onionIngredient6 = new RecipeIngredient { Amount = 100, Ingredient = onion };
        var garlicIngredient6 = new RecipeIngredient { Amount = 10, Ingredient = garlic };
        var gingerIngredient6 = new RecipeIngredient { Amount = 10, Ingredient = ginger };
        var tomatoIngredient6 = new RecipeIngredient { Amount = 100, Ingredient = tomato };
        var cilantroIngredient6 = new RecipeIngredient { Amount = 10, Ingredient = cilantro };
        var cuminIngredient6 = new RecipeIngredient { Amount = 5, Ingredient = cumin };
        var corianderIngredient6 = new RecipeIngredient { Amount = 5, Ingredient = coriander };
        var turmericIngredient6 = new RecipeIngredient { Amount = 5, Ingredient = turmeric };
        var garamMasalaIngredient6 = new RecipeIngredient { Amount = 5, Ingredient = garamMasala };
        var saltIngredient6 = new RecipeIngredient { Amount = 5, Ingredient = salt };
        var pepperIngredient6 = new RecipeIngredient { Amount = 5, Ingredient = pepper };
        var vegetableOilIngredient6 = new RecipeIngredient { Amount = 15, Ingredient = vegetableOil };
        var waterIngredient6 = new RecipeIngredient { Amount = 500, Ingredient = water };
        var riceIngredient6 = new RecipeIngredient { Amount = 200, Ingredient = rice };
        var eggsIngredient7 = new RecipeIngredient { Amount = 100, Ingredient = egg };
        var cheeseIngredient7 = new RecipeIngredient { Amount = 50, Ingredient = cheese };
        var spinachIngredient7 = new RecipeIngredient { Amount = 50, Ingredient = spinach };
        var tomatoIngredient7 = new RecipeIngredient { Amount = 50, Ingredient = tomato };
        var basilIngredient7 = new RecipeIngredient { Amount = 10, Ingredient = basil };
        var saltIngredient7 = new RecipeIngredient { Amount = 2, Ingredient = salt };
        var pepperIngredient7 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var butterIngredient7 = new RecipeIngredient { Amount = 10, Ingredient = butter };
        var bananaIngredient8 = new RecipeIngredient { Amount = 200, Ingredient = banana };
        var oatmealIngredient8 = new RecipeIngredient { Amount = 200, Ingredient = oatmeal };
        var almondMilkIngredient8 = new RecipeIngredient { Amount = 100, Ingredient = almondMilk };
        var eggIngredient8 = new RecipeIngredient { Amount = 50, Ingredient = egg };
        var bakingPowderIngredient8 = new RecipeIngredient { Amount = 5, Ingredient = bakingPowder };
        var vanillaExtractIngredient8 = new RecipeIngredient { Amount = 5, Ingredient = vanillaExtract };
        var cinnamonIngredient8 = new RecipeIngredient { Amount = 2, Ingredient = cinnamon };
        var nutmegIngredient8 = new RecipeIngredient { Amount = 2, Ingredient = nutmeg };
        var saltIngredient8 = new RecipeIngredient { Amount = 2, Ingredient = salt };
        var blueberryIngredient8 = new RecipeIngredient { Amount = 100, Ingredient = blueberry };
        var walnutIngredient8 = new RecipeIngredient { Amount = 50, Ingredient = walnut };
        var peanutsIngredient9 = new RecipeIngredient { Amount = 50, Ingredient = peanuts };
        var mandelIngredient9 = new RecipeIngredient { Amount = 50, Ingredient = mandel };
        var cabbageIngredient9 = new RecipeIngredient { Amount = 300, Ingredient = cabbage };
        var carrotIngredient9 = new RecipeIngredient { Amount = 100, Ingredient = carrot };
        var scallionIngredient9 = new RecipeIngredient { Amount = 50, Ingredient = scallion };
        var cilantroIngredient9 = new RecipeIngredient { Amount = 20, Ingredient = cilantro };
        var limeJuiceIngredient9 = new RecipeIngredient { Amount = 30, Ingredient = limeJuice };
        var soySauceIngredient9 = new RecipeIngredient { Amount = 15, Ingredient = soySauce };
        var sesameOilIngredient9 = new RecipeIngredient { Amount = 15, Ingredient = sesameOil };
        var mapleSyrupIngredient9 = new RecipeIngredient { Amount = 15, Ingredient = mapleSyrup };
        var gingerIngredient9 = new RecipeIngredient { Amount = 10, Ingredient = ginger };
        var garlicIngredient9 = new RecipeIngredient { Amount = 5, Ingredient = garlic };
        var saltIngredient9 = new RecipeIngredient { Amount = 2, Ingredient = salt };
        var pepperIngredient9 = new RecipeIngredient { Amount = 2, Ingredient = pepper };
        var nutellaIngredient10 = new RecipeIngredient { Amount = 400, Ingredient = nutella };
        var butterIngredient10 = new RecipeIngredient { Amount = 200, Ingredient = butter };
        var sugarIngredient10 = new RecipeIngredient { Amount = 200, Ingredient = sugar };
        var eggIngredient10 = new RecipeIngredient { Amount = 200, Ingredient = egg };
        var flourIngredient10 = new RecipeIngredient { Amount = 200, Ingredient = flour };
        var bakingPowderIngredient10 = new RecipeIngredient { Amount = 5, Ingredient = bakingPowder };
        var saltIngredient10 = new RecipeIngredient { Amount = 2, Ingredient = salt };
        var heavyCreamIngredient10 = new RecipeIngredient { Amount = 300, Ingredient = heavyCream };
        var vanillaExtractIngredient10 = new RecipeIngredient { Amount = 5, Ingredient = vanillaExtract };
        var chocolateIngredient10 = new RecipeIngredient { Amount = 100, Ingredient = chocolate };
        var sprinklesIngredient10 = new RecipeIngredient { Amount = 50, Ingredient = sprinkles };

        //context.RecipeIngredients.AddRange(
        //    tomatoIngredient,
        //    basilIngredient,
        //    penneIngredient,
        //    onionIngredient,
        //    parmesanCheese,
        //    flourIngredient,
        //    sugarIngredient,
        //    chocolateChipIngredient,
        //    chickenIngredient,
        //    romanianLettuceIngredient);
        //_ = context.SaveChanges();

        // Preparation Steps

        var pennePreparation1 = new PreparationStep { Description = "Bring a large pot of salted water to a boil. Add the penne and cook until al dente, about 10 minutes. Drain and set aside.", Step = 1 };
        var pennePreparation2 = new PreparationStep { Description = "In a large skillet over medium-high heat, heat the olive oil. Add the garlic and cook until fragrant, about 2 minutes. Add the tomatoes and cook until soft, about 15 minutes. Season with salt and pepper to taste.", Step = 2 };
        var pennePreparation3 = new PreparationStep { Description = "Add the cheese and basil to the tomato sauce and stir until melted. Add the penne and toss to coat. Serve hot or cold.", Step = 3 };
        var chickpeaCurryPreparation1 = new PreparationStep { Description = "Rinse and drain the chickpeas and set aside.", Step = 1 };
        var chickpeaCurryPreparation2 = new PreparationStep { Description = "Peel and dice the onion, ginger and garlic and set aside.", Step = 2 };
        var chickpeaCurryPreparation3 = new PreparationStep { Description = "In a large pot over medium-high heat, heat the vegetable oil. Add the onion, ginger and garlic and cook until soft, stirring occasionally, about 15 minutes.", Step = 3 };
        var chickpeaCurryPreparation4 = new PreparationStep { Description = "Add the curry powder, cumin, turmeric, coriander, salt and pepper and cook for another 5 minutes, stirring frequently, until fragrant.", Step = 4 };
        var chickpeaCurryPreparation5 = new PreparationStep { Description = "Add the chickpeas and coconut milk and bring to a boil. Reduce the heat and simmer, uncovered, for 20 minutes, stirring occasionally, until the sauce is thickened.", Step = 5 };
        var chickpeaCurryPreparation6 = new PreparationStep { Description = "In a small pot over high heat, bring the water to a boil. Add the rice and a pinch of salt and stir. Cover and reduce the heat to low. Cook for 15 minutes, or until the rice is tender and fluffy.", Step = 6 };
        var chickpeaCurryPreparation7 = new PreparationStep { Description = "Serve the chickpea curry over the rice, garnished with some fresh coriander if desired.", Step = 7 };
        var chickenBurritoPreparation1 = new PreparationStep { Description = "Cut the chicken into bite-sized pieces and season with salt and pepper.", Step = 1 };
        var chickenBurritoPreparation2 = new PreparationStep { Description = "In a large skillet over medium-high heat, heat the vegetable oil. Add the chicken and cook, stirring occasionally, until golden and cooked through, about 15 minutes.", Step = 2 };
        var chickenBurritoPreparation3 = new PreparationStep { Description = "In a small pot over medium heat, bring the black beans and some water to a boil. Simmer until heated through, about 10 minutes. Drain and set aside.", Step = 3 };
        var chickenBurritoPreparation4 = new PreparationStep { Description = "In a small bowl, toss the corn with some salt and pepper.", Step = 4 };
        var chickenBurritoPreparation5 = new PreparationStep { Description = "In a microwave-safe bowl, heat the salsa for about 30 seconds, or until warm.", Step = 5 };
        var chickenBurritoPreparation6 = new PreparationStep { Description = "In another microwave-safe bowl, heat the cheese for about 15 seconds, or until melted.", Step = 6 };
        var chickenBurritoPreparation7 = new PreparationStep { Description = "In a large plate, place one gluten-free tortilla and spread some sour cream over it. Top with some chicken, black beans, corn, salsa and cheese. Fold the bottom edge over the filling, then fold in the sides and roll up tightly.", Step = 7 };
        var chickenBurritoPreparation8 = new PreparationStep { Description = "Repeat with the remaining tortillas and fillings.", Step = 8 };
        var chickenBurritoPreparation9 = new PreparationStep { Description = "Serve the burritos with some lettuce on the side, or cut them in half and enjoy.", Step = 9 };
        var spinachOmelettePreparation1 = new PreparationStep { Description = "In a small bowl, whisk the eggs with a pinch of salt and pepper.", Step = 1 };
        var spinachOmelettePreparation2 = new PreparationStep { Description = "In a large nonstick skillet over medium-high heat, melt the butter. Add the spinach and cook, stirring occasionally, until wilted, about 5 minutes.", Step = 2 };
        var spinachOmelettePreparation3 = new PreparationStep { Description = "Reduce the heat to medium-low and pour the egg mixture over the spinach. Sprinkle the mozzarella over the eggs. Cover and cook until the eggs are set, about 10 minutes.", Step = 3 };
        var spinachOmelettePreparation4 = new PreparationStep { Description = "Cut the cherry tomatoes in half and scatter them over the omelette. Sprinkle the basil over the tomatoes.", Step = 4 };
        var spinachOmelettePreparation5 = new PreparationStep { Description = "Carefully slide the omelette onto a large plate and cut into wedges. Serve hot or cold.", Step = 5 };
        var coconutSoupPreparation1 = new PreparationStep { Description = "Cut the tofu into bite-sized pieces and press them with paper towels to remove excess moisture.", Step = 1 };
        var coconutSoupPreparation2 = new PreparationStep { Description = "In a small bowl, whisk together the lime juice, soy sauce, brown sugar and red curry paste. Set aside.", Step = 2 };
        var coconutSoupPreparation3 = new PreparationStep { Description = "In a large pot over medium-high heat, heat the vegetable oil. Add the lemongrass, ginger and garlic and cook, stirring, until fragrant, about 5 minutes.", Step = 3 };
        var coconutSoupPreparation4 = new PreparationStep { Description = "Add the coconut milk and vegetable broth and bring to a boil. Reduce the heat and simmer for 10 minutes.", Step = 4 };
        var coconutSoupPreparation5 = new PreparationStep { Description = "Add the tofu and mushrooms and cook until heated through, about 10 minutes.", Step = 5 };
        var coconutSoupPreparation6 = new PreparationStep { Description = "Stir in the lime juice mixture and season with salt and pepper to taste.", Step = 6 };
        var coconutSoupPreparation7 = new PreparationStep { Description = "Sprinkle some cilantro over the soup and serve hot or cold.", Step = 7 };
        var chickenCurryPreparation1 = new PreparationStep { Description = "Cut the chicken into bite-sized pieces and place them in a large bowl. Add the yogurt, half of the garlic, half of the ginger, half of the cumin, half of the coriander, half of the turmeric, half of the garam masala, and a pinch of salt and pepper. Mix well and refrigerate for at least 2 hours or overnight.", Step = 1 };
        var chickenCurryPreparation2 = new PreparationStep { Description = "Peel and chop the onion. Peel and mince the remaining garlic and ginger. Chop the tomato and cilantro.", Step = 2 };
        var chickenCurryPreparation3 = new PreparationStep { Description = "In a large pot over high heat, bring the water to a boil. Add the rice, a pinch of salt, and a drizzle of oil. Reduce the heat and simmer, covered, until the rice is tender and fluffy, about 15 to 20 minutes. Fluff with a fork and keep warm.", Step = 3 };
        var chickenCurryPreparation4 = new PreparationStep { Description = "In a large skillet over medium-high heat, heat the oil. Add the onion and cook, stirring occasionally, until soft and golden, about 15 minutes.", Step = 4 };
        var chickenCurryPreparation5 = new PreparationStep { Description = "Add the remaining garlic, ginger, cumin, coriander, turmeric, garam masala, and a pinch of salt and pepper. Cook, stirring, until fragrant, about 2 minutes.", Step = 5 };
        var chickenCurryPreparation6 = new PreparationStep { Description = "Add the tomato and cook, stirring, until soft, about 10 minutes.", Step = 6 };
        var chickenCurryPreparation7 = new PreparationStep { Description = "Add the chicken and yogurt mixture and bring to a boil. Reduce the heat and simmer, uncovered, until the chicken is cooked through and the sauce is thickened, about 20 to 25 minutes.", Step = 7 };
        var chickenCurryPreparation8 = new PreparationStep { Description = "Stir in some cilantro and taste for seasoning. Adjust as needed.", Step = 8 };
        var chickenCurryPreparation9 = new PreparationStep { Description = "Serve the chicken curry over the rice and garnish with more cilantro if desired.", Step = 9 };
        var spinachOmeletteVariationPreparation1 = new PreparationStep { Description = "Crack the eggs into a small bowl and whisk well. Add some cheese, salt and pepper and whisk again.", Step = 1 };
        var spinachOmeletteVariationPreparation2 = new PreparationStep { Description = "Wash and chop the spinach, tomato and basil.", Step = 2 };
        var spinachOmeletteVariationPreparation3 = new PreparationStep { Description = "In a non-stick skillet over medium-high heat, melt the butter. Add the spinach and cook, stirring, until wilted, about 5 minutes.", Step = 3 };
        var spinachOmeletteVariationPreparation4 = new PreparationStep { Description = "Reduce the heat to low and pour the egg mixture over the spinach. Tilt the pan to spread the eggs evenly.", Step = 4 };
        var spinachOmeletteVariationPreparation5 = new PreparationStep { Description = "Cook until the eggs are set, about 10 minutes, lifting the edges occasionally to let the uncooked eggs run underneath.", Step = 5 };
        var spinachOmeletteVariationPreparation6 = new PreparationStep { Description = "Sprinkle some cheese, tomato and basil over half of the omelette. Fold the other half over and slide onto a plate.", Step = 6 };
        var spinachOmeletteVariationPreparation7 = new PreparationStep { Description = "Serve hot or cold, with some more basil if desired.", Step = 7 };
        var bananaMuffinPreparation1 = new PreparationStep { Description = "Preheat the oven to 180°C (350°F) and line a 12-cup muffin tin with paper liners.", Step = 1 };
        var bananaMuffinPreparation2 = new PreparationStep { Description = "Peel and mash the bananas in a large bowl with a fork. Add the almond milk, egg, and vanilla extract and whisk well.", Step = 2 };
        var bananaMuffinPreparation3 = new PreparationStep { Description = "In a blender or food processor, grind the oatmeal into a fine flour. Transfer to a medium bowl and whisk in the baking powder, cinnamon, nutmeg, and salt.", Step = 3 };
        var bananaMuffinPreparation4 = new PreparationStep { Description = "Add the oatmeal mixture to the banana mixture and stir until well combined. Fold in the blueberries and walnuts.", Step = 4 };
        var bananaMuffinPreparation5 = new PreparationStep { Description = "Scoop the batter into the prepared muffin cups, filling them about 3/4 full. Bake for 20 to 25 minutes or until a toothpick inserted in the center comes out clean.", Step = 5 };
        var bananaMuffinPreparation6 = new PreparationStep { Description = "Let the muffins cool slightly in the pan before transferring to a wire rack to cool completely.", Step = 6 };
        var bananaMuffinPreparation7 = new PreparationStep { Description = "Enjoy as a healthy snack or breakfast, or store in an airtight container for up to 3 days.", Step = 7 };
        var peanutMandelSaladPreparation1 = new PreparationStep { Description = "Toast the peanuts and mandel in a small skillet over medium heat, stirring occasionally, until golden and fragrant, about 10 minutes. Transfer to a plate and let cool slightly.", Step = 1 };
        var peanutMandelSaladPreparation2 = new PreparationStep { Description = "Chop the cabbage, carrot, scallion and cilantro and toss them in a large bowl.", Step = 2 };
        var peanutMandelSaladPreparation3 = new PreparationStep { Description = "In a small bowl, whisk together the lime juice, soy sauce, sesame oil, maple syrup, ginger, garlic, salt and pepper.", Step = 3 };
        var peanutMandelSaladPreparation4 = new PreparationStep { Description = "Drizzle the dressing over the salad and toss well to coat.", Step = 4 };
        var peanutMandelSaladPreparation5 = new PreparationStep { Description = "Sprinkle the peanuts and mandel over the salad and serve, or refrigerate for up to 2 hours to let the flavors meld.", Step = 5 };
        var nutellaCakePreparation1 = new PreparationStep { Description = "Preheat the oven to 180°C (350°F) and grease and flour a 9-inch round cake pan.", Step = 1 };
        var nutellaCakePreparation2 = new PreparationStep { Description = "In a large microwave-safe bowl, combine the nutella and butter and microwave for 30 seconds or until melted and smooth. Stir in the sugar and let cool slightly.", Step = 2 };
        var nutellaCakePreparation3 = new PreparationStep { Description = "Add the eggs, one at a time, whisking well after each addition. Sift in the flour, baking powder and salt and fold gently until well combined.", Step = 3 };
        var nutellaCakePreparation4 = new PreparationStep { Description = "Pour the batter into the prepared cake pan and bake for 25 to 30 minutes or until a toothpick inserted in the center comes out clean.", Step = 4 };
        var nutellaCakePreparation5 = new PreparationStep { Description = "Let the cake cool completely in the pan on a wire rack.", Step = 5 };
        var nutellaCakePreparation6 = new PreparationStep { Description = "In a small saucepan over low heat, heat the heavy cream until simmering. Remove from heat and add the chocolate, stirring until melted and smooth. Stir in the vanilla extract and let cool slightly.", Step = 6 };
        var nutellaCakePreparation7 = new PreparationStep { Description = "Place the cake on a serving plate and pour the chocolate ganache over the top, spreading it evenly with a spatula. Sprinkle the sprinkles over the ganache and place the candle in the center of the cake.", Step = 7 };
        var nutellaCakePreparation8 = new PreparationStep { Description = "Light the candle and sing happy birthday to the lucky person. Enjoy the delicious nutella cake!", Step = 8 };
        //// Recipes
        //if (context.Recipes.Any())
        //{
        //    return;
        //}

        var penneRecipe = new Recipe
        {
            Name = "Penne with Tomato and Cheese Sauce",
            Description = "A simple and delicious pasta dish with a creamy tomato and cheese sauce",
            Difficulty = PreparationDifficulty.Easy,
            RecipeIngredients = new List<RecipeIngredient>() { penneIngredient1, tomatoIngredient1, cheeseIngredient1, basilIngredient1, garlicIngredient1, oliveOilIngredient1, saltIngredient1, pepperIngredient1 },
            Cuisine = hungarian,
            MealTimes = new List<MealTime> { breakfast },
            Diets = new List<Diet> { vegetarian },
            DishType = pasta,
            PreparationSteps = new List<PreparationStep>()
            { pennePreparation1, pennePreparation2, pennePreparation3 }
        };
        var chickpeaCurryRecipe = new Recipe
        {
            Name = "Chickpea Curry",
            Description = "A spicy and creamy vegan curry with chickpeas and coconut milk",
            Difficulty = PreparationDifficulty.Medium,
            RecipeIngredients = new List<RecipeIngredient>() { chickpeasIngredient2, coconutMilkIngredient2, onionIngredient2, gingerIngredient2, garlicIngredient2, curryPowderIngredient2, cuminIngredient2, turmericIngredient2, corianderIngredient2, saltIngredient2, pepperIngredient2, vegetableOilIngredient2, riceIngredient2, waterIngredient2 },
            Cuisine = indian,
            MealTimes = new List<MealTime> { lunch },
            Diets = new List<Diet> { vegan },
            DishType = curry,
            PreparationSteps = new List<PreparationStep>
            {chickpeaCurryPreparation1, chickpeaCurryPreparation2, chickpeaCurryPreparation3, chickpeaCurryPreparation4, chickpeaCurryPreparation5, chickpeaCurryPreparation6, chickpeaCurryPreparation7 }
        };
        var chickenBurritoRecipe = new Recipe
        {
            Name = "Chicken Burrito",
            Description = "A hearty and delicious gluten-free burrito with chicken, black beans, corn, salsa and cheese",
            Difficulty = PreparationDifficulty.Medium,
            RecipeIngredients = new List<RecipeIngredient>() { chickenIngredient3, blackBeansIngredient3, cornIngredient3, salsaIngredient3, cheeseIngredient3, lettuceIngredient3, sourCreamIngredient3, glutenFreeTortillaIngredient3, saltIngredient3, pepperIngredient3, vegetableOilIngredient3 },
            Cuisine = mexican,
            MealTimes = new List<MealTime> { dinner },
            Diets = new List<Diet> { glutenFree },
            DishType = burrito,
            PreparationSteps = new List<PreparationStep>
            {chickenBurritoPreparation1, chickenBurritoPreparation2, chickenBurritoPreparation3, chickenBurritoPreparation4, chickenBurritoPreparation5, chickenBurritoPreparation6, chickenBurritoPreparation7, chickenBurritoPreparation8, chickenBurritoPreparation9 }
        };
        var spinachOmeletteRecipe = new Recipe
        {
            Name = "Spinach Omelette",
            Description = "A fluffy and cheesy omelette with spinach, cherry tomatoes and basil",
            Difficulty = PreparationDifficulty.Easy,
            RecipeIngredients = new List<RecipeIngredient>() { eggsIngredient4, spinachIngredient4, cherryTomatoesIngredient4, mozzarellaIngredient4, basilIngredient4, saltIngredient4, pepperIngredient4, butterIngredient4 },
            Cuisine = italian,
            MealTimes = new List<MealTime> { breakfast, brunch },
            Diets = new List<Diet> { vegetarian, keto },
            DishType = omelette,
            PreparationSteps = new List<PreparationStep>
            { spinachOmelettePreparation1, spinachOmelettePreparation2, spinachOmelettePreparation3, spinachOmelettePreparation4, spinachOmelettePreparation5 }
        };
        var coconutSoupRecipe = new Recipe
        {
            Name = "Coconut Soup",
            Description = "A creamy and spicy vegan soup with coconut milk, tofu, mushrooms and lemongrass",
            Difficulty = PreparationDifficulty.Easy,
            RecipeIngredients = new List<RecipeIngredient>() { coconutMilkIngredient5, vegetableBrothIngredient5, lemongrassIngredient5, gingerIngredient5, garlicIngredient5, limeJuiceIngredient5, soySauceIngredient5, brownSugarIngredient5, redCurryPasteIngredient5, tofuIngredient5, mushroomsIngredient5, cilantroIngredient5, saltIngredient5, pepperIngredient5, vegetableOilIngredient5 },
            Cuisine = thai,
            MealTimes = new List<MealTime> { lunch },
            Diets = new List<Diet> { vegan },
            DishType = soup,
            PreparationSteps = new List<PreparationStep> { coconutSoupPreparation1, coconutSoupPreparation2, coconutSoupPreparation3, coconutSoupPreparation4, coconutSoupPreparation5, coconutSoupPreparation6, coconutSoupPreparation7 }
        };
        var chickenCurryRecipe = new Recipe
        {
            Name = "Chicken Curry",
            Description = "A flavorful and low-fat Indian dish with chicken, yogurt, and spices",
            Difficulty = PreparationDifficulty.Medium,
            RecipeIngredients = new List<RecipeIngredient>() { chickenIngredient6, yogurtIngredient6, onionIngredient6, garlicIngredient6, gingerIngredient6, tomatoIngredient6, cilantroIngredient6, cuminIngredient6, corianderIngredient6, turmericIngredient6, garamMasalaIngredient6, saltIngredient6, pepperIngredient6, vegetableOilIngredient6, waterIngredient6, riceIngredient6 },
            Cuisine = indian,
            MealTimes = new List<MealTime> { dinner },
            Diets = new List<Diet> { lowFat },
            DishType = curry,
            PreparationSteps = new List<PreparationStep>
            {chickenCurryPreparation1, chickenCurryPreparation2, chickenCurryPreparation3, chickenCurryPreparation4, chickenCurryPreparation5, chickenCurryPreparation6, chickenCurryPreparation7, chickenCurryPreparation8, chickenCurryPreparation9 }
        };
        var spinachOmeletteRecipeVariation = new Recipe
        {
            Name = "Spinach Omelette Variation",
            Description = "A simple and nutritious breakfast with eggs, cheese, spinach, tomato and basil",
            Difficulty = PreparationDifficulty.Easy,
            RecipeIngredients = new List<RecipeIngredient>() { eggsIngredient7, cheeseIngredient7, spinachIngredient7, tomatoIngredient7, basilIngredient7, saltIngredient7, pepperIngredient7, butterIngredient7 },
            Cuisine = italian,
            MealTimes = new List<MealTime> { breakfast },
            Diets = new List<Diet> { lowCarb, glutenFree, highProtein, vegetarian },
            DishType = omelette,
            PreparationSteps = new List<PreparationStep>
            { spinachOmeletteVariationPreparation1, spinachOmeletteVariationPreparation2, spinachOmeletteVariationPreparation3, spinachOmeletteVariationPreparation4, spinachOmeletteVariationPreparation5, spinachOmeletteVariationPreparation6, spinachOmeletteVariationPreparation7 }
        };
        var bananaMuffinRecipe = new Recipe
        {
            Name = "Banana Muffin",
            Description = "A healthy and delicious muffin with banana, oatmeal, blueberries and walnuts",
            Difficulty = PreparationDifficulty.Hard,
            RecipeIngredients = new List<RecipeIngredient>() { bananaIngredient8, oatmealIngredient8, almondMilkIngredient8, eggIngredient8, bakingPowderIngredient8, vanillaExtractIngredient8, cinnamonIngredient8, nutmegIngredient8, saltIngredient8, blueberryIngredient8, walnutIngredient8 },
            Cuisine = american,
            MealTimes = new List<MealTime> { snack },
            Diets = new List<Diet> { lowSugar, highFiber },
            DishType = muffin,
            PreparationSteps = new List<PreparationStep>
            {bananaMuffinPreparation1, bananaMuffinPreparation2, bananaMuffinPreparation3, bananaMuffinPreparation4, bananaMuffinPreparation5, bananaMuffinPreparation6, bananaMuffinPreparation7}
        };
        var peanutMandelSaladRecipe = new Recipe
        {
            Name = "Peanut Mandel Salad",
            Description = "A crunchy and refreshing salad with cabbage, carrot, scallion, cilantro, peanuts and mandel, tossed in a tangy and sweet dressing",
            Difficulty = PreparationDifficulty.Easy,
            RecipeIngredients = new List<RecipeIngredient>() { peanutsIngredient9, mandelIngredient9, cabbageIngredient9, carrotIngredient9, scallionIngredient9, cilantroIngredient9, limeJuiceIngredient9, soySauceIngredient9, sesameOilIngredient9, mapleSyrupIngredient9, gingerIngredient9, garlicIngredient9, saltIngredient9, pepperIngredient9 },
            Cuisine = thai,
            MealTimes = new List<MealTime> { lunch },
            Diets = new List<Diet> { lowFat, lowSodium, vegan, glutenFree },
            DishType = salad,
            PreparationSteps = new List<PreparationStep>
            {peanutMandelSaladPreparation1, peanutMandelSaladPreparation2, peanutMandelSaladPreparation3, peanutMandelSaladPreparation4, peanutMandelSaladPreparation5 }
        };
        var nutellaCakeRecipe = new Recipe
        {
            Name = "Nutella Birthday Cake",
            Description = "A decadent and moist cake with nutella and chocolate ganache, topped with sprinkles and a candle for a special occasion",
            Difficulty = PreparationDifficulty.Medium,
            RecipeIngredients = new List<RecipeIngredient>() { nutellaIngredient10, butterIngredient10, sugarIngredient10, eggIngredient10, flourIngredient10, bakingPowderIngredient10, saltIngredient10, heavyCreamIngredient10, vanillaExtractIngredient10, chocolateIngredient10, sprinklesIngredient10 },
            Cuisine = german,
            MealTimes = new List<MealTime> { dessert },
            Diets = new List<Diet> { vegetarian },
            DishType = cake,
            PreparationSteps = new List<PreparationStep>
            {nutellaCakePreparation1, nutellaCakePreparation2, nutellaCakePreparation3, nutellaCakePreparation4, nutellaCakePreparation5, nutellaCakePreparation6, nutellaCakePreparation7, nutellaCakePreparation8}
        };


        context.Recipes.AddRange(penneRecipe, chickpeaCurryRecipe, chickenBurritoRecipe, spinachOmeletteRecipe, coconutSoupRecipe, chickenCurryRecipe, spinachOmeletteRecipeVariation, bananaMuffinRecipe, peanutMandelSaladRecipe, nutellaCakeRecipe);
        _ = context.SaveChanges();

        // Users
        if (context.Users.Any())
        {
            return;
        }

        var user1 = new User
        {
            Username = "FoodLover123",
            EmailAddress = "ilovefood@example.com",
            Password = "12345678",
            IsAdmin = true
        };
        var user2 = new User
        {
            Username = "JaneDoe",
            FirstName = "Jane",
            LastName = "Doe",
            EmailAddress = "jane@example.com",
            Password = "87654321",
            IsAdmin = false
        };
        var user3 = new User
        {
            Username = "MichaelSmith",
            EmailAddress = "smith@example.com",
            Password = "pw1234567",
            IsAdmin = false
        };
        context.Users.AddRange(user1, user2, user3);
        _ = context.SaveChanges();

        // Recipe reviews
        if (context.RecipeReviews.Any())
        {
            return;
        }

        var review1 = new RecipeReview
        {
            User = user1,
            Recipe = spinachOmeletteRecipe,
            Rate = 4,
        };
        var review2 = new RecipeReview
        {
            User = user1,
            Recipe = spinachOmeletteRecipe,
            Rate = 3,
            Review = "This recipe should be more detailed."
        };
        var review3 = new RecipeReview
        {
            User = user2,
            Recipe = chickpeaCurryRecipe,
            Rate = 2,
            Review = "I would add more onions to this recipe."
        };
        var review4 = new RecipeReview
        {
            User = user2,
            Recipe = nutellaCakeRecipe,
            Rate = 5,
            Review = "Best cake recipe!"
        };
        var review5 = new RecipeReview
        {
            User = user3,
            Recipe = nutellaCakeRecipe,
            Rate = 4,
        };
        var review6 = new RecipeReview
        {
            User = user3,
            Recipe = nutellaCakeRecipe,
            Rate = 4,
        };
        var review7 = new RecipeReview
        {
            User = user1,
            Recipe = peanutMandelSaladRecipe,
            Rate = 5,
            Review = "Very easy, best dinner!"
        };
        var review8 = new RecipeReview
        {
            User = user3,
            Recipe = spinachOmeletteRecipeVariation,
            Rate = 5,
        };

        context.RecipeReviews.AddRange(review1, review2, review3, review4, review5, review6, review7, review8);
        _ = context.SaveChanges();

        // User recipe status
        if (context.UserRecipeStatuses.Any())
        {
            return;
        }

        var liked = new UserRecipeStatus
        {
            Name = RecipeStatus.Liked
        };
        var disliked = new UserRecipeStatus
        {
            Name = RecipeStatus.Disliked,
        };
        var saved = new UserRecipeStatus
        {
            Name = RecipeStatus.Saved,
        };
        context.UserRecipeStatuses.AddRange(liked, disliked, saved);
        _ = context.SaveChanges();

        // User recipe
        if (context.UserRecipes.Any())
        {
            return;
        }

        var userRecipe1 = new UserRecipe
        {
            Recipe = spinachOmeletteRecipeVariation,
            User = user1,
            Status = saved
        };
        var userRecipe2 = new UserRecipe
        {
            Recipe = peanutMandelSaladRecipe,
            User = user1,
            Status = liked
        };
        var userRecipe3 = new UserRecipe
        {
            Recipe = peanutMandelSaladRecipe,
            User = user2,
            Status = disliked
        };
        var userRecipe4 = new UserRecipe
        {
            Recipe = spinachOmeletteRecipeVariation,
            User = user2,
            Status = liked
        };
        var userRecipe5 = new UserRecipe
        {
            Recipe = chickenCurryRecipe,
            User = user1,
            Status = saved
        };
        var userRecipe6 = new UserRecipe
        {
            Recipe = chickenCurryRecipe,
            User = user3,
            Status = saved
        };
        var userRecipe7 = new UserRecipe
        {
            Recipe = coconutSoupRecipe,
            User = user3,
            Status = saved
        };
        context.UserRecipes.AddRange(
            userRecipe1,
            userRecipe2,
            userRecipe3,
            userRecipe4,
            userRecipe5,
            userRecipe6,
            userRecipe7);
        _ = context.SaveChanges();
    }
}