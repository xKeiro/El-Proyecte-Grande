using AutoMapper;
using backend.Dtos.Users.User;
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
    }
}