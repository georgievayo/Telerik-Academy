using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CacheableCommandTests
    {
        [Test]
        public void Constructor_ShouldThrowException_WhenCommandIsNull()
        {
            var mockedService = new Mock<ICachingService>();

            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(null, mockedService.Object));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenServiceIsNull()
        {
            var mockedCommand = new Mock<ICommand>();

            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(mockedCommand.Object, null));
        }

        [Test]
        public void Constructor_ShouldCreateInstance_WhenParametersAreCorrect()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            Assert.IsInstanceOf<CacheableCommand>(cacheableCommand);
        }

        [Test]
        public void ParameterCount_ShouldReturnCorrectValue_WhenParametersAreCorrect()
        {
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(c => c.ParameterCount).Returns(5);
            var mockedService = new Mock<ICachingService>();
            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            Assert.AreEqual(cacheableCommand.ParameterCount, 5);
        }

        [Test]
        public void Execute_ShouldCallIsExpiredPropertyOfService()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            cacheableCommand.Execute(new List<string>());
            mockedService.Verify(s => s.IsExpired, Times.Once);
        }

        [Test]
        public void Execute_ShouldCallExecuteMethodOfCommand_WhenIsExpiredIsTrue()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            mockedService.Setup(s => s.IsExpired).Returns(true);
            var list = new List<string>();
            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            cacheableCommand.Execute(list);
            mockedCommand.Verify(s => s.Execute(list), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallAddCacheMethodOfservice_WhenIsExpiredIsTrue()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            mockedService.Setup(s => s.IsExpired).Returns(true);
            var list = new List<string>();
            mockedCommand.Setup(c => c.Execute(list)).Returns("_");

            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            cacheableCommand.Execute(list);
            mockedService.Verify(s => s.AddCacheValue("ListProjects", "Execute", "_"), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallResetCacheMethodOfservice_WhenIsExpiredIsTrue()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            mockedService.Setup(s => s.IsExpired).Returns(true);
            var list = new List<string>();
            mockedCommand.Setup(c => c.Execute(list)).Returns("_");

            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            cacheableCommand.Execute(list);
            mockedService.Verify(s => s.ResetCache(), Times.Once);
        }

        [Test]
        public void Execute_ShouldReturnCorrectValue_WhenIsExpiredIsTrue()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            mockedService.Setup(s => s.IsExpired).Returns(true);
            var list = new List<string>();
            mockedCommand.Setup(c => c.Execute(list)).Returns("_");

            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            var result = cacheableCommand.Execute(list);
            Assert.AreEqual("_", result);
        }

        [Test]
        public void Execute_ShouldCallGetCacheMethodOfservice_WhenIsExpiredIsFalse()
        {
            var mockedCommand = new Mock<ICommand>();
            var mockedService = new Mock<ICachingService>();
            mockedService.Setup(s => s.IsExpired).Returns(false);
            var list = new List<string>();
            mockedCommand.Setup(c => c.Execute(list)).Returns("_");

            var cacheableCommand = new CacheableCommand(mockedCommand.Object, mockedService.Object);
            cacheableCommand.Execute(list);
            mockedService.Verify(s => s.GetCacheValue("ListProjects", "Execute"), Times.Once);
        }
    }
}
