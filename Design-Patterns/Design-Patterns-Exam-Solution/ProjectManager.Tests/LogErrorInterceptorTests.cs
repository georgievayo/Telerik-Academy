using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class LogErrorInterceptorTests
    {
        [Test]
        public void Constructor_ShouldThrowException_WhenPassedWriterIsNull()
        {
            var mockedLogger = new Mock<ILogger>();
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(mockedLogger.Object, null));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenPassedLoggerIsNull()
        {
            var mockedWriter = new Mock<IWriter>();
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(null, mockedWriter.Object));
        }

        [Test]
        public void Constructor_ShouldNotThrowException_WhenPassedParametersAreCorrect()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedWriter = new Mock<IWriter>();

            Assert.DoesNotThrow(() => new LogErrorInterceptor(mockedLogger.Object, mockedWriter.Object));
        }

        [Test]
        public void Intercept_ShouldCallProceedMethod_WhenPassedParametersAreCorrect()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedWriter = new Mock<IWriter>();
            var mockedInvocation = new Mock<IInvocation>();

            var interceptor = new LogErrorInterceptor(mockedLogger.Object, mockedWriter.Object);
            interceptor.Intercept(mockedInvocation.Object);
            mockedInvocation.Verify(i => i.Proceed(), Times.Once);
        }

        [Test]
        public void Intercept_ShouldCallWriteLineMethod_WhenPassedParametersAreCorrect()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedWriter = new Mock<IWriter>();
            var mockedInvocation = new Mock<IInvocation>();

            var interceptor = new LogErrorInterceptor(mockedLogger.Object, mockedWriter.Object);
            interceptor.Intercept(mockedInvocation.Object);
            mockedWriter.Verify(i => i.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Intercept_ShouldCallErrorMethod_WhenProceedHasThrownException()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedWriter = new Mock<IWriter>();
            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Proceed()).Throws<Exception>();

            var interceptor = new LogErrorInterceptor(mockedLogger.Object, mockedWriter.Object);
            interceptor.Intercept(mockedInvocation.Object);
            mockedLogger.Verify(i => i.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
