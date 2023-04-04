using AutoMapper;
using backend.Dtos.Users.User;
using backend.Models.Users;
using backend.Services.Users;
using backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Dtos.Recipes.Recipe;
using backend.Enums;
using backend.Models;
using backend.Models.Categories;
using backend.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Ingredient;
using backend.Dtos.Recipes.PreparationStep;
using backend.Dtos.Recipes.RecipeIngredient;
using backend.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using Moq.EntityFrameworkCore;
using backend.Services.Categories;
using BackendTests.Utils;
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

            var penne = new Ingredient {Id=1, Name = "Penne Pasta", UnitOfMeasure = "g", Calorie = 352 };
            var vegetarian = new Diet {Id=1, Name = "Vegetarian" };
            var pasta = new DishType {Id = 1, Name = "Pasta" };
            var breakfast = new MealTime {Id=1, Name = "Breakfast" };
            var hungarian = new Cuisine {Id=1, Name = "Hungarian" };

            var penneRecipe = new Recipe
            {
                Id=1,
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


            var pennePublic = new IngredientPublic { Id=1, Name = "Penne Pasta", UnitOfMeasure = "g", Calorie = 352 };
            var vegetarianPublic = new DietPublic { Id=1, Name = "Vegetarian" };
            var pastaPublic = new DishTypePublic { Id = 1, Name = "Pasta" };
            var breakfastPublic = new MealTimePublic { Id=1, Name = "Breakfast" };
            var hungarianPublic = new CuisinePublic { Id = 1, Name = "Hungarian" };
            var penneRecipePublic = new RecipePublic
            {
                Id=1,
                Name = "Penne with Tomato and Cheese Sauce",
                Description = "A simple and delicious pasta dish with a creamy tomato and cheese sauce",
                Difficulty = PreparationDifficulty.Easy,
                RecipeIngredients = new List<RecipeIngredientPublic> { new RecipeIngredientPublic { Id=1, Amount = 250, Ingredient = pennePublic } },
                Cuisine = hungarianPublic,
                MealTimes = new List<MealTimePublic> { breakfastPublic },
                Diets = new List<DietPublic> { vegetarianPublic },
                DishType = pastaPublic,
                PreparationSteps = new List<PreparationStepPublic>
                    { new PreparationStepPublic {Id = 1,  Description = "Bring a large pot of salted water to a boil. Add the penne and cook until al dente, about 10 minutes. Drain and set aside.", Step = 1 } }
            };
            _recipes = new List<Recipe> { penneRecipe };
            _recipesPublic = new List<RecipePublic> { penneRecipePublic };

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
            var expected = _recipesPublic.First();

            // Act
            var result = await _service.Find(1);

            // Assert
            Assert.AreEqual(expected, result);

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
