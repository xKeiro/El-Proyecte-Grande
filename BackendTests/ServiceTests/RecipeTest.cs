using AutoMapper;
using backend.Services;
using Moq;
using backend.Dtos.Recipes.Recipe;
using backend.Enums;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Ingredient;
using backend.Dtos.Recipes.PreparationStep;
using backend.Dtos.Recipes.RecipeIngredient;
using Moq.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BackendTests.ServiceTests
{
    [TestFixture]
    public class RecipeTest
    {
        private Mock<ElProyecteGrandeContext> _mockContext;
        private RecipeService _service;
        private List<Recipe> _recipes;
        private List<RecipePublic> _recipesPublic;
        private Mock<IMapper> _mapper;


        [SetUp]
        public void SetUp()
        {
            _recipes = new List<Recipe>();
            _recipesPublic = new List<RecipePublic>();

            var penne = new Ingredient { Id = 1, Name = "Penne Pasta", UnitOfMeasure = "g", Calorie = 352 };
            var vegetarian = new Diet { Id = 1, Name = "Vegetarian" };
            var pasta = new DishType { Id = 1, Name = "Pasta" };
            var breakfast = new MealTime { Id = 1, Name = "Breakfast" };
            var hungarian = new Cuisine { Id = 1, Name = "Hungarian" };

            var penneRecipe = new Recipe
            {
                Id = 1,
                Name = "Penne with Tomato and Cheese Sauce",
                Description = "A simple and delicious pasta dish with a creamy tomato and cheese sauce",
                Difficulty = PreparationDifficulty.Easy,
                RecipeIngredients = new List<RecipeIngredient> { new RecipeIngredient { Id = 1, Amount = 250, Ingredient = penne } },

                Cuisine = hungarian,
                MealTimes = new List<MealTime> { breakfast },
                Diets = new List<Diet> { vegetarian },
                DishType = pasta,
                PreparationSteps = new List<PreparationStep>
                    { new PreparationStep {Id=1, Description = "Bring a large pot of salted water to a boil. Add the penne and cook until al dente, about 10 minutes. Drain and set aside.", Step = 1 } }
            };

            var chicken = new Ingredient { Id = 2, Name = "Chicken Breast", UnitOfMeasure = "g", Calorie = 165 };
            var lowCarb = new Diet { Id = 2, Name = "Low-carb" };
            var meat = new DishType { Id = 2, Name = "Meat" };
            var dinner = new MealTime { Id = 2, Name = "Dinner" };
            var italian = new Cuisine { Id = 1, Name = "Italian" };

            var chickenAlfredo = new Recipe
            {
                Id = 2,
                Name = "Chicken Alfredo",
                Description = "A classic Italian dish made with chicken and creamy Alfredo sauce",
                Difficulty = PreparationDifficulty.Medium,
                RecipeIngredients = new List<RecipeIngredient> { new RecipeIngredient { Id = 2, Amount = 500, Ingredient = chicken } },

                Cuisine = italian,
                MealTimes = new List<MealTime> { dinner },
                Diets = new List<Diet> { lowCarb },
                DishType = meat,
                PreparationSteps = new List<PreparationStep>
                {
                    new PreparationStep { Id = 2, Description = "Season the chicken breasts with salt and pepper. Heat a skillet over medium-high heat and cook the chicken for 6-8 minutes on each side, until fully cooked. Set aside and let rest for a few minutes before slicing into strips.", Step = 2 },
                    new PreparationStep { Id = 3, Description = "Cook the fettuccine pasta in a large pot of boiling salted water until al dente. Drain and set aside.", Step = 3 }
                }
            };

            var chocolate = new Ingredient { Id = 3, Name = "Chocolate", UnitOfMeasure = "g", Calorie = 546 };
            var sugar = new Ingredient { Id = 4, Name = "Sugar", UnitOfMeasure = "g", Calorie = 387 };
            var flour = new Ingredient { Id = 5, Name = "Flour", UnitOfMeasure = "g", Calorie = 364 };
            var dessert = new DishType { Id = 3, Name = "Dessert" };
            var snack = new MealTime { Id = 3, Name = "Snack" };
            var american = new Cuisine { Id = 3, Name = "American" };
            var eggFree = new Diet { Id = 3, Name = "Egg-free" };

            var chocolateCakeRecipe = new Recipe
            {
                Id = 3,
                Name = "Chocolate Cake",
                Description = "A delicious chocolate cake with a rich, moist texture and intense chocolate flavor.",
                Difficulty = PreparationDifficulty.Medium,
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Id = 3, Amount = 200, Ingredient = chocolate },
                    new RecipeIngredient { Id = 4, Amount = 200, Ingredient = sugar },
                    new RecipeIngredient { Id = 5, Amount = 200, Ingredient = flour },

                },
                Cuisine = american,
                MealTimes = new List<MealTime> { snack },
                Diets = new List<Diet>{eggFree},
                DishType = dessert,
                PreparationSteps = new List<PreparationStep>
                {
                    new PreparationStep
                    {
                        Id = 4, Description = "Preheat the oven to 350°F (180°C) and grease a 9-inch (23-cm) cake pan.",
                        Step = 1
                    },
                    new PreparationStep
                    {
                        Id = 5, Description = "In a medium bowl, sift together the flour and cocoa powder.", Step = 2
                    },
                    new PreparationStep
                    {
                        Id = 6,
                        Description =
                            "In a large bowl, cream together the butter and sugar until light and fluffy. Add the eggs one at a time, beating well after each addition. Stir in the vanilla.",
                        Step = 3
                    }
                }
            };

            var pennePublic = new IngredientPublic { Id = 1, Name = "Penne Pasta", UnitOfMeasure = "g", Calorie = 352 };
            var vegetarianPublic = new DietPublic { Id = 1, Name = "Vegetarian" };
            var pastaPublic = new DishTypePublic { Id = 1, Name = "Pasta" };
            var breakfastPublic = new MealTimePublic { Id = 1, Name = "Breakfast" };
            var hungarianPublic = new CuisinePublic { Id = 1, Name = "Hungarian" };
            var penneRecipePublic = new RecipePublic
            {
                Id = 1,
                Name = "Penne with Tomato and Cheese Sauce",
                Description = "A simple and delicious pasta dish with a creamy tomato and cheese sauce",
                Difficulty = PreparationDifficulty.Easy,
                RecipeIngredients = new List<RecipeIngredientPublic> { new RecipeIngredientPublic { Id = 1, Amount = 250, Ingredient = pennePublic } },
                Cuisine = hungarianPublic,
                MealTimes = new List<MealTimePublic> { breakfastPublic },
                Diets = new List<DietPublic> { vegetarianPublic },
                DishType = pastaPublic,
                PreparationSteps = new List<PreparationStepPublic>
                    { new PreparationStepPublic {Id = 1,  Description = "Bring a large pot of salted water to a boil. Add the penne and cook until al dente, about 10 minutes. Drain and set aside.", Step = 1 } }
            };

            var chickenPublic = new IngredientPublic { Id = 2, Name = "Chicken Breast", UnitOfMeasure = "g", Calorie = 165 };
            var lowCarbPublic = new DietPublic { Id = 2, Name = "Low-carb" };
            var meatPublic = new DishTypePublic { Id = 2, Name = "Meat" };
            var dinnerPublic = new MealTimePublic { Id = 2, Name = "Dinner" };
            var italianPublic = new CuisinePublic { Id = 1, Name = "Italian" };
            var chickenAlfredoPublic = new RecipePublic
            {
                Id = 2,
                Name = "Chicken Alfredo",
                Description = "A classic Italian dish made with chicken and creamy Alfredo sauce",
                Difficulty = PreparationDifficulty.Medium,
                RecipeIngredients = new List<RecipeIngredientPublic> { new RecipeIngredientPublic { Id = 2, Amount = 500, Ingredient = chickenPublic } },

                Cuisine = italianPublic,
                MealTimes = new List<MealTimePublic> { dinnerPublic },
                Diets = new List<DietPublic> { lowCarbPublic },
                DishType = meatPublic,
                PreparationSteps = new List<PreparationStepPublic>
                {
                    new PreparationStepPublic { Id = 2, Description = "Season the chicken breasts with salt and pepper. Heat a skillet over medium-high heat and cook the chicken for 6-8 minutes on each side, until fully cooked. Set aside and let rest for a few minutes before slicing into strips.", Step = 2 },
                    new PreparationStepPublic { Id = 3, Description = "Cook the fettuccine pasta in a large pot of boiling salted water until al dente. Drain and set aside.", Step = 3 }
                }
            };

            var chocolatePublic = new IngredientPublic { Id = 3, Name = "Chocolate", UnitOfMeasure = "g", Calorie = 546 };
            var sugarPublic = new IngredientPublic { Id = 4, Name = "Sugar", UnitOfMeasure = "g", Calorie = 387 };
            var flourPublic = new IngredientPublic { Id = 5, Name = "Flour", UnitOfMeasure = "g", Calorie = 364 };
            var dessertPublic = new DishTypePublic { Id = 3, Name = "Dessert" };
            var snackPublic = new MealTimePublic { Id = 3, Name = "Snack" };
            var americanPublic = new CuisinePublic { Id = 3, Name = "American" };
            var eggFreePublic = new DietPublic { Id = 3, Name = "Egg-free" };

            var chocolateCakeRecipePublic = new RecipePublic
            {
                Id = 3,
                Name = "Chocolate Cake",
                Description = "A delicious chocolate cake with a rich, moist texture and intense chocolate flavor.",
                Difficulty = PreparationDifficulty.Medium,
                RecipeIngredients = new List<RecipeIngredientPublic>
                {
                    new RecipeIngredientPublic { Id = 3, Amount = 200, Ingredient = chocolatePublic },
                    new RecipeIngredientPublic { Id = 4, Amount = 200, Ingredient = sugarPublic },
                    new RecipeIngredientPublic { Id = 5, Amount = 200, Ingredient = flourPublic },

                },
                Cuisine = americanPublic,
                MealTimes = new List<MealTimePublic> { snackPublic },
                Diets = new List<DietPublic> { eggFreePublic },
                DishType = dessertPublic,
                PreparationSteps = new List<PreparationStepPublic>
                {
                    new PreparationStepPublic
                    {
                        Id = 4, Description = "Preheat the oven to 350°F (180°C) and grease a 9-inch (23-cm) cake pan.",
                        Step = 1
                    },
                    new PreparationStepPublic
                    {
                        Id = 5, Description = "In a medium bowl, sift together the flour and cocoa powder.", Step = 2
                    },
                    new PreparationStepPublic
                    {
                        Id = 6,
                        Description =
                            "In a large bowl, cream together the butter and sugar until light and fluffy. Add the eggs one at a time, beating well after each addition. Stir in the vanilla.",
                        Step = 3
                    }
                }
            };


            _recipes = new List<Recipe> { penneRecipe, chickenAlfredo, chocolateCakeRecipe };
            _recipesPublic = new List<RecipePublic> { penneRecipePublic, chickenAlfredoPublic, chocolateCakeRecipePublic };

            _mockContext = new(new DbContextOptions<ElProyecteGrandeContext>());
            _mockContext.Setup(x => x.Recipes).ReturnsDbSet(_recipes);

            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<List<Recipe>, List<RecipePublic>>(It.IsAny<List<Recipe>>())).Returns(_recipesPublic);

            _service = new RecipeService(_mockContext.Object, _mapper.Object);

        }

        [Test]
        public async Task Find_ReturnsNull_WhenRecipeNotFound()
        {
            int id = 123;
            var result = await _service.Find(id);
            Assert.IsNull(result);
        }



        /*[Test]
        public async Task Find_ReturnsRecipePublic_WhenRecipeFound()
        {
            int id = 1;
            var expected = _recipesPublic.First(r => r.Id == id);

            var result = await _service.Find(id);

            Util.AreEqualByJson(result, expected);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RecipePublic>());
        }*/

        [Test]
        public async Task GetAll_RecipesExist_ShouldReturnRecipes()
        {

            var filter = new RecipeFilter
            {
                Name = null,
                CuisineIds = null,
                DishTypeIds = null,
                DietIds = null,
                MealTimeIds = null,
                IngredientIds = null,
                MaxNumberOfNotOwnedIngredients = null,
                MaxDifficulty = null,
                RecipesPerPage = 5
            };
            var currentPage = 1;
            var result = await _service.GetFiltered(filter, currentPage);
            var expectedJson = JsonConvert.SerializeObject(new RecipesPublicWithNextPage()
            {
                NextPage = null,
                Recipes = _recipesPublic
            });
            var actualJson = JsonConvert.SerializeObject(result);
            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }


    }

}
