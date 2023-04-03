using Microsoft.VisualStudio.TestTools.UnitTesting;
using backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using backend.Interfaces.Services;

namespace backend.Services.Tests
{
    [TestClass()]
    public class StatusMessageServiceTests<T> where T : class
    {
        private StatusMessageService<T>? _statusMessageService;

        [SetUp]
        public void Setup()
        {
            var statusMessageService = new StatusMessageService<T>();
            _statusMessageService = statusMessageService;
        }

        [Test]
        public void NoneFoundTest()
        {
            NUnit.Framework.Assert.Fail();
        }

        [Test]
        public void AlreadyExistsTest()
        {
            NUnit.Framework.Assert.Fail();
        }
        [Test]
        public void NotFoundTest()
        {
            NUnit.Framework.Assert.Fail();
        }

        [Test]
        public void DeletedTest()
        {
            NUnit.Framework.Assert.Fail();
        }

        [Test]
        public void NotUniqueTest()
        {
            NUnit.Framework.Assert.Fail();
        }
    }
}