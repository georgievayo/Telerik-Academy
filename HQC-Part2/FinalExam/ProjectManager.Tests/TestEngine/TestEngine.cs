using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core;
using ProjectManager.Tests.Extensions;

namespace ProjectManager.Tests.TestEngine
{
    [TestFixture]
    public class TestEngine
    {
        // Test 1
        [Test]
        public void TestStartMethod_WhenSomethingIsPassed_ShouldWriteMessage()
        {
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var engine = new Engine(loggerMock.Object, commandProcessorMock.Object, writerMock.Object, readerMock.Object);

            readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            engine.Start();

            readerMock.Verify(r => r.ReadLine(), Times.Once());
        }
        // Test 2
        [Test]
        public void TestStartMethod_WhenExitIsPassed_ShouldWriteMessage()
        {
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var engine = new Engine(loggerMock.Object, commandProcessorMock.Object, writerMock.Object, readerMock.Object);

            readerMock.Setup(r => r.ReadLine()).Returns("Exit");
            engine.Start();

            writerMock.Verify(l => l.WriteLine(It.Is<string>(s => s.Contains("Program terminated."))), Times.Once);
        }

        // Test 3
        [TestCase("CreateProject DeathStar 2016-1-1 2018-05-04 Active")]
        public void TestStartMethod_WhenCommandsArePassed_ShouldWriteExecutionResult(string command)
        {
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(c => c.Process(command)).Returns("Something");

            var terminationCommand = "Exit";

            var readerMock = new Mock<IReader>();
            readerMock.SetupMany(r => r.ReadLine(), command, terminationCommand);

            var writerMock = new Mock<IWriter>();
            var engine = new Engine(loggerMock.Object, commandProcessorMock.Object, writerMock.Object, readerMock.Object);

            engine.Start();

            writerMock.Verify(l => l.WriteLine(It.Is<string>(s => s.Contains("Something"))), Times.Once());
        }

        // Test 4
        [TestCase(" ")]
        public void TestStartMethod_WhenIncorrectCommandIsPassed_ShouldWriteMessage(string command)
        {
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(c => c.Process(" ")).Throws(new UserValidationException("No command has been provided!"));
            var readerMock = new Mock<IReader>();
            var terminationCommand = "Exit";
            readerMock.SetupMany(r => r.ReadLine(), command, terminationCommand);

            var writerMock = new Mock<IWriter>();
            var engine = new Engine(loggerMock.Object, commandProcessorMock.Object, writerMock.Object, readerMock.Object);

            engine.Start();

            writerMock.Verify(l => l.WriteLine(It.Is<string>(s => s.Contains("No command has been provided!"))),
                Times.Once());
        }

        // Test 5
        [TestCase(" ")]
        public void TestStartMethod_WhenThrowsGenericException_ShouldLogMessage(string command)
        {
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(c => c.Process(" ")).Throws(new Exception("Stupid error!"));
            var readerMock = new Mock<IReader>();
            var terminationCommand = "Exit";
            readerMock.SetupMany(r => r.ReadLine(), command, terminationCommand);

            var writerMock = new Mock<IWriter>();
            var engine = new Engine(loggerMock.Object, commandProcessorMock.Object, writerMock.Object, readerMock.Object);

            engine.Start();

            loggerMock.Verify(l => l.Error("Stupid error!"), Times.Once());
        }

        // Test 6
        [TestCase(" ")]
        public void TestStartMethod_WhenThrowsGenericException_ShouldWriteMessage(string command)
        {
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(c => c.Process(" ")).Throws(new Exception("Stupid error!"));
            var readerMock = new Mock<IReader>();
            var terminationCommand = "Exit";
            readerMock.SetupMany(r => r.ReadLine(), command, terminationCommand);

            var writerMock = new Mock<IWriter>();
            var engine = new Engine(loggerMock.Object, commandProcessorMock.Object, writerMock.Object, readerMock.Object);

            engine.Start();

            var text = "";
            writerMock.Verify(l => l.WriteLine(It.Is<string>(s => s.Contains("something happened"))));
        }
    }
}
