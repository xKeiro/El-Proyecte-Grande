using AutoMapper;
using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Categories.Diet;
using backend.Dtos.Categories.DishType;
using backend.Dtos.Categories.MealTime;
using backend.Dtos.Recipes.PreparationStep;
using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Recipes.RecipeIngredient;
using backend.Dtos.Users.User;
using backend.Enums;
using backend.Maps;
using backend.Models.Users;
using backend.Services;
using backend.Services.Users;
using BackendTests.Utils;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BackendTests.ServiceTests
{
    [TestFixture]
    public class UserTests
    {
        private Mock<ElProyecteGrandeContext> mockContext;
        private IMapper mapper;
        private UserService service;
        private List<User> users;
        private List<UserPublic> usersPublic;

        [SetUp]
        public void Setup()
        {
            users = new List<User>()
            {
                new ()
                {
                    Id = 1,
                    Username = "longdon",
                    EmailAddress = "ding@dong.com",
                    FirstName = null,
                    LastName = null,
                    IsAdmin = false,
                    Password = "12345"
                },
                new ()
                {
                    Id = 2,
                    Username = "whiskers",
                    EmailAddress = "why@you.net",
                    FirstName = "John",
                    LastName = "Faruga",
                    IsAdmin = false,
                    Password = "12345"
                },
                new ()
                {
                    Id = 3,
                    Username = "omegalol",
                    EmailAddress = "super@nice.com",
                    FirstName = null,
                    LastName = null,
                    IsAdmin = true,
                    Password = "98765"
                }
            };

            usersPublic = new List<UserPublic>()
            {
                new ()
                {
                    Id = 1,
                    Username = "longdon",
                    EmailAddress = "ding@dong.com",
                    FirstName = null,
                    LastName = null,
                    IsAdmin = false,
                },
                new ()
                {
                    Id = 2,
                    Username = "whiskers",
                    EmailAddress = "why@you.net",
                    FirstName = "John",
                    LastName = "Faruga",
                    IsAdmin = false,
                },
                new ()
                {
                    Id = 3,
                    Username = "omegalol",
                    EmailAddress = "super@nice.com",
                    FirstName = null,
                    LastName = null,
                    IsAdmin = true,
                }
            };
            mockContext = new(new DbContextOptions<ElProyecteGrandeContext>());
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(typeof(MappingProfile)));
            mapper = mappingConfig.CreateMapper();

            service = new UserService(mockContext.Object, mapper);
        }

        [Test]
        public async Task GetAll_WhenCalled_ReturnsUserList()
        {
            Util.AreEqualByJson(usersPublic, await service.GetAll());
        }

        [Test]
        public async Task Find_ExistingId_ReturnsUser()
        {
            UserPublic expectedUser = new()
            {
                Id = 1,
                Username = "longdon",
                EmailAddress = "ding@dong.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
            };

            Util.AreEqualByJson(expectedUser, await service.Find(1));
        }

        [Test]
        public async Task Find_NotExistingId_ReturnsNull()
        {
            Assert.Null(await service.Find(4));
        }

        [Test]
        public async Task IsUnique_ExistingUsernameAndEmail_ReturnsFalse()
        {
            UserWithoutId existingUser = new()
            {
                Username = "omegalol",
                EmailAddress = "super@nice.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
                Password = "12345"
            };

            Assert.False(await service.IsUnique(existingUser));
        }

        [Test]
        public async Task IsUnique_ExistingUsername_ReturnsFalse()
        {
            UserWithoutId existingUserWithSameUsername = new()
            {
                Username = "omegalol",
                EmailAddress = "supernicity@nice888.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
                Password = "12345"
            };

            Assert.False(await service.IsUnique(existingUserWithSameUsername));
        }

        [Test]
        public async Task IsUnique_ExistingEmail_ReturnsFalse()
        {
            UserWithoutId existingUserWithSameEmail = new()
            {
                Username = "omegaloller523",
                EmailAddress = "super@nice.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
                Password = "12345"
            };

            Assert.False(await service.IsUnique(existingUserWithSameEmail));
        }

        [Test]
        public async Task IsUnique_NotExistingUsernameAndEmail_ReturnsTrue()
        {
            UserWithoutId newUser = new()
            {
                Username = "sigmauser",
                EmailAddress = "cool@this.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
                Password = "12345"
            };

            Assert.True(await service.IsUnique(newUser));
        }

        [Test]
        public async Task FindByUsername_ExistingUsername_ReturnsUser()
        {
            User expectedUser = new()
            {
                Id = 3,
                Username = "omegalol",
                EmailAddress = "super@nice.com",
                FirstName = null,
                LastName = null,
                IsAdmin = true,
                Password = "98765"
            };

            Util.AreEqualByJson(expectedUser, await service.FindByUsername("omegalol"));
        }

        [Test]
        public async Task FindByUsername_NotExistingUsername_ReturnsNull()
        {
            Assert.Null(await service.FindByUsername("notExistingUser"));
        }

        [Test]
        public async Task IsUniqueUsername_NotExistingUsername_ReturnsTrue()
        {
            UserWithoutId newUser = new()
            {
                Username = "sigmauser",
                EmailAddress = "cool@this.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
                Password = "12345"
            };

            Assert.True(await service.IsUniqueUsername(newUser));
        }

        [Test]
        public async Task IsUniqueUsername_ExistingUsername_ReturnsFalse()
        {
            UserWithoutId newUser = new()
            {
                Username = "omegalol",
                EmailAddress = "super@nice.com",
                FirstName = null,
                LastName = null,
                IsAdmin = true,
                Password = "98765"
            };

            Assert.False(await service.IsUniqueUsername(newUser));
        }

        [Test]
        public async Task IsUniqueEmail_NotExistingEmail_ReturnsTrue()
        {
            UserWithoutId newUser = new()
            {
                Username = "sigmauser",
                EmailAddress = "cool@this.com",
                FirstName = null,
                LastName = null,
                IsAdmin = false,
                Password = "12345"
            };

            Assert.True(await service.IsUniqueEmail(newUser));
        }

        [Test]
        public async Task IsUniqueEmail_ExistingEmail_ReturnsFalse()
        {
            UserWithoutId newUser = new()
            {
                Username = "omegalol",
                EmailAddress = "super@nice.com",
                FirstName = null,
                LastName = null,
                IsAdmin = true,
                Password = "98765"
            };

            Assert.False(await service.IsUniqueEmail(newUser));
        }

        [Test]
        public async Task LikedRecipes_ExistingUserId_ReturnsListOfLikedRecipes()
        {
            List<RecipePublic> expectedList = new List<RecipePublic>()
            {
                new()
                {
                    Id = 2,
                    Name = "Peanut Mandel Salad",
                    Description = "A crunchy and refreshing salad with cabbage, carrot, scallion, cilantro, peanuts and mandel, tossed in a tangy and sweet dressing",
                    Difficulty = PreparationDifficulty.Easy,
                    RecipeIngredients = new List<RecipeIngredientPublic>(),
                    Cuisine = new CuisinePublic() { Name = "Thai" },
                    MealTimes = new List<MealTimePublic>(),
                    Diets = new List<DietPublic>(),
                    DishType = new DishTypePublic() { Name = "Salad" },
                    PreparationSteps = new List<PreparationStepPublic>()
                }
            };

            mockContext.Setup(x => x.Recipes).ReturnsDbSet(Util.Recipes);
            mockContext.Setup(x => x.UserRecipes).ReturnsDbSet(Util.UserRecipes);

            Util.AreEqualByJson(expectedList, await service.LikedRecipes(1));
        }

        [Test]
        public async Task LikedRecipes_NotExistingUserId_ReturnsEmptyList()
        {
            List<RecipePublic> expectedList = new List<RecipePublic>();
            
            mockContext.Setup(x => x.Recipes).ReturnsDbSet(Util.Recipes);
            mockContext.Setup(x => x.UserRecipes).ReturnsDbSet(Util.UserRecipes);

            Util.AreEqualByJson(expectedList, await service.LikedRecipes(3));
        }

        [Test]
        public async Task SavedRecipes_ExistingUserId_ReturnsListOfSavedRecipes()
        {
            List<RecipePublic> expectedList = new List<RecipePublic>()
            {
                new()
                {
                    Id = 3,
                    Name = "Spinach Omelette Variation",
                    Description = "A simple and nutritious breakfast with eggs, cheese, spinach, tomato and basil",
                    Difficulty = PreparationDifficulty.Easy,
                    RecipeIngredients = new List<RecipeIngredientPublic>(),
                    Cuisine = new CuisinePublic() { Name = "Italian" },
                    MealTimes = new List<MealTimePublic>(),
                    Diets = new List<DietPublic>(),
                    DishType = new DishTypePublic() { Name = "Omelette" },
                    PreparationSteps = new List<PreparationStepPublic>()
                },
                new()
                {
                    Id = 1,
                    Name = "Chicken Curry",
                    Description = "A flavorful and low-fat Indian dish with chicken, yogurt, and spices",
                    Difficulty = PreparationDifficulty.Medium,
                    RecipeIngredients = new List<RecipeIngredientPublic>(),
                    Cuisine = new CuisinePublic() { Name = "Indian"},
                    MealTimes = new List<MealTimePublic>(),
                    Diets = new List<DietPublic>(),
                    DishType = new DishTypePublic() { Name = "Curry"},
                    PreparationSteps = new List<PreparationStepPublic>()
                }
            };

            mockContext.Setup(x => x.Recipes).ReturnsDbSet(Util.Recipes);
            mockContext.Setup(x => x.UserRecipes).ReturnsDbSet(Util.UserRecipes);

            Util.AreEqualByJson(expectedList, await service.SavedRecipes(1));
        }

        [Test]
        public async Task SavedRecipes_NotExistingUserId_ReturnsEmptyList()
        {
            List<RecipePublic> expectedList = new List<RecipePublic>();

            mockContext.Setup(x => x.Recipes).ReturnsDbSet(Util.Recipes);
            mockContext.Setup(x => x.UserRecipes).ReturnsDbSet(Util.UserRecipes);

            Util.AreEqualByJson(expectedList, await service.SavedRecipes(25));
        }

        [Test]
        public async Task DislikedRecipes_ExistingUserId_ReturnsListOfDislikedRecipes()
        {
            List<RecipePublic> expectedList = new List<RecipePublic>()
            {
                new()
                {
                    Id = 3,
                    Name = "Spinach Omelette Variation",
                    Description = "A simple and nutritious breakfast with eggs, cheese, spinach, tomato and basil",
                    Difficulty = PreparationDifficulty.Easy,
                    RecipeIngredients = new List<RecipeIngredientPublic>(),
                    Cuisine = new CuisinePublic() { Name = "Italian" },
                    MealTimes = new List<MealTimePublic>(),
                    Diets = new List<DietPublic>(),
                    DishType = new DishTypePublic() { Name = "Omelette" },
                    PreparationSteps = new List<PreparationStepPublic>()
                }
            };

            mockContext.Setup(x => x.Recipes).ReturnsDbSet(Util.Recipes);
            mockContext.Setup(x => x.UserRecipes).ReturnsDbSet(Util.UserRecipes);

            Util.AreEqualByJson(expectedList, await service.DislikedRecipes(2));
        }

        [Test]
        public async Task DislikedRecipes_NotExistingUserId_ReturnsEmptyList()
        {
            List<RecipePublic> expectedList = new List<RecipePublic>();

            mockContext.Setup(x => x.Recipes).ReturnsDbSet(Util.Recipes);
            mockContext.Setup(x => x.UserRecipes).ReturnsDbSet(Util.UserRecipes);

            Util.AreEqualByJson(expectedList, await service.DislikedRecipes(325));
        }

        [Test]
        public async Task Add_NewUser_AddAsyncAndSaveChangesAsyncMethodsCalledOnDb()
        {
            UserWithoutId newUserWithoutId = new()
            {
                Username = "Ayakababygirl",
                EmailAddress = "ayaya@best.com",
                FirstName = "Ayaka",
                LastName = "Kamisato",
                IsAdmin = false,
                Password = "cryoqueen"
            };

            await service.Add(newUserWithoutId);

            mockContext.Verify(x => x.Users.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()));
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task Add_NewUser_ReturnsCreatedUser()
        {
            UserPublic expectedUser = new()
            {
                Id = 0,
                Username = "Ayakababygirl",
                EmailAddress = "ayaya@best.com",
                FirstName = "Ayaka",
                LastName = "Kamisato",
                IsAdmin = false,
            };

            UserWithoutId newUserWithoutId = new()
            {
                Username = "Ayakababygirl",
                EmailAddress = "ayaya@best.com",
                FirstName = "Ayaka",
                LastName = "Kamisato",
                IsAdmin = false,
                Password = "cryoqueen"
            };

            UserPublic newUser = await service.Add(newUserWithoutId);

            Util.AreEqualByJson(expectedUser, newUser);
        }

        [Test]
        public async Task Add_NewUser_AddsNewUserToDb()
        {
            UserWithoutId newUserWithoutId = new()
            {
                Username = "Ayakababygirl",
                EmailAddress = "ayaya@best.com",
                FirstName = "Ayaka",
                LastName = "Kamisato",
                IsAdmin = false,
                Password = "cryoqueen"
            };

            mockContext.Setup(x => x.Users.AddAsync(It.IsAny<User>(), default))
                .Callback<User, CancellationToken>((u, _) => { users.Add(u); });

            await service.Add(newUserWithoutId);

            Assert.That(users.Count, Is.EqualTo(4));
        }

        [Test]
        public async Task Update_ExistingUser_UpdateAndSaveChangesAsyncMethodsCalledOnDb()
        {
            UserWithoutId updateUserWithoutId = new()
            {
                Username = "longjohnson",
                EmailAddress = "ding@dong.com",
                FirstName = "Long",
                LastName = "Johnson",
                IsAdmin = false,
                Password = "12345"
            };

            await service.Update(1, updateUserWithoutId);

            mockContext.Verify(x => x.Update(It.IsAny<User>()));
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task Update_ExistingUser_ReturnsUpdatedUser()
        {
            UserPublic expectedUser = new()
            {
                Id = 1,
                Username = "longjohnson",
                EmailAddress = "ding@dong.com",
                FirstName = "Long",
                LastName = "Johnson",
                IsAdmin = false,
            };

            UserWithoutId updateUserWithoutId = new()
            {
                Username = "longjohnson",
                EmailAddress = "ding@dong.com",
                FirstName = "Long",
                LastName = "Johnson",
                IsAdmin = false,
                Password = "12345"
            };

            UserPublic updatedUser = await service.Update(1, updateUserWithoutId);

            Util.AreEqualByJson(expectedUser, updatedUser);
        }

        [Test]
        public async Task Update_ExistingUser_UpdatesUserInDb()
        {
            User expectedUser = new()
            {
                Id = 1,
                Username = "longjohnson",
                EmailAddress = "ding@dong.com",
                FirstName = "Long",
                LastName = "Johnson",
                IsAdmin = false,
                Password = "12345"
            };

            UserWithoutId updateUserWithoutId = new()
            {
                Username = "longjohnson",
                EmailAddress = "ding@dong.com",
                FirstName = "Long",
                LastName = "Johnson",
                IsAdmin = false,
                Password = "12345"
            };

            mockContext.Setup(x => x.Update(It.IsAny<User>()))
                .Callback<User>(u =>
                {
                    users.Remove(users.First(ur => ur.Id == 1));
                    users.Add(u);
                });

            await service.Update(1, updateUserWithoutId);

            Util.AreEqualByJson(expectedUser, users.First(u => u.Id == 1));
        }
    }
}