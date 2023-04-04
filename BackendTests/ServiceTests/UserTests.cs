using AutoMapper;
using backend.Dtos.Users.User;
using backend.Models.Users;
using backend.Services;
using backend.Services.Users;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BackendTests.ServiceTests
{
    [TestFixture]
    public class Tests
    {
        private Mock<ElProyecteGrandeContext> _mockContext;
        private UserService _service;
        private List<User> _users;
        private List<UserPublic> _usersPublic;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _users = new List<User>()
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

            _usersPublic = new List<UserPublic>()
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
            _mockContext = new(new DbContextOptions<ElProyecteGrandeContext>());
            _mockContext.Setup(x => x.Users).ReturnsDbSet(_users);

            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<List<User>, List<UserPublic>>(It.IsAny<List<User>>())).Returns(_usersPublic);

            _service = new UserService(_mockContext.Object, _mapper.Object);
        }

        [Test]
        public async Task GetAll_WhenCalled_ReturnsUserList()
        {
            CollectionAssert.AreEqual(_usersPublic, await _service.GetAll());
        }
    }
}