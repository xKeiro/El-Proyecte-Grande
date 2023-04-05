using AutoMapper;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using backend.Models.Users;
using backend.Models.Categories;
using backend.Dtos.Users.User;
using backend.Services.Users;
using BackendTests.Utils;

namespace BackendTests.ServiceTests
{
    [TestFixture]
    public class StatusMessageServiceTests
    {
        private StatusMessageService<User> _statusMessageService;

        [SetUp]
        public void Setup()
        {
            var statusMessageService = new StatusMessageService<User>();
            _statusMessageService = statusMessageService;
        }

        [Test]
        public void NotFoundTest()
        {
            var actual = _statusMessageService.NotFound(3);
            var expected = new { Message = "User with id:'3' doesn't exist!" };
            Util.AreEqualByJson(expected, actual);
        }

        [Test]
        public void DeletedTest()
        {
            var actual = _statusMessageService.Deleted(3);
            var expected = new { Message = "User with id:'3' was deleted and everything related to it!" };
            Util.AreEqualByJson(expected, actual);
        }

        [Test]
        public void NoneFoundTest()
        {
            var actual = _statusMessageService.NoneFound();
            var expected = new { Message = "No Users found!" };
            Util.AreEqualByJson(expected, actual);
        }

        [Test]
        public void AlreadyExistsTest()
        {
            var actual = _statusMessageService.AlreadyExists();
            var expected = new { Message = "User already exists!" };
            Util.AreEqualByJson(expected, actual);
        }

        [Test]
        public void NotUniqueTest()
        {
            var actual = _statusMessageService.NotUnique();
            var expected = new { Message = "User has a property that is not unique, but should be!" };
            Util.AreEqualByJson(expected, actual);
        }
    }
}