using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Commands.Adding;
using Academy.Models;
using Academy.Core.Contracts;
using Moq;
using Academy.Models.Contracts;
using Academy.Tests.Mock;

namespace Academy.Tests
{
    [TestFixture]
    class TestAdding
    {
        // Test constructor
        [Test]
        public void TestAddStudentToSeasonCommand_WhenPassedFactoryIsNull_ShouldThrowArgumentNullException()
        {
            var engineMock = new Mock<IEngine>();
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineMock.Object));
        }

        [Test]
        public void TestAddStudentToSeasonCommand_WhenPassedEngineIsNull_ShouldThrowArgumentNullException()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryMock.Object, null));
        }

        [Test]
        public void TestAddStudentToSeasonCommand_WhenPassedArgumentsAreCorrect_ShouldAssignFactory()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var command = new AddCommandMock(factoryMock.Object, engineMock.Object);
            Assert.AreSame(factoryMock.Object, command.Factory);
        }

        [Test]
        public void TestAddStudentToSeasonCommand_WhenPassedArgumentsAreCorrect_ShouldAssignEngine()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var command = new AddCommandMock(factoryMock.Object, engineMock.Object);
            Assert.AreSame(engineMock.Object, command.Engine);
        }

        // Test Execute method
        [TestCase ("kjfslkdl","0")]
        public void TestExecute_WhenPassedStudentIsAlreadyPartOfSeason_ShouldThrowArgumentException(string username, string id)
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var studentMock = new Mock<IStudent>();

            studentMock.Setup(x => x.Username).Returns(username);
            var students = new List<IStudent>();
            students.Add(studentMock.Object);

            engineMock.Setup(x => x.Students).Returns(students);
            List<string> list = new List<string>{ username, id };

            var seasonMock = new Mock<ISeason>();
            seasonMock.Setup(x => x.Students).Returns(students);
            var seasons = new List<ISeason> { seasonMock.Object};
            engineMock.Setup(x => x.Seasons).Returns(seasons);

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);
            Assert.Throws<ArgumentException>(() => command.Execute(list));
        }

        [Test]
        public void TestExecute_WhenPassedStudentIsntAlreadyPartOfSeason_ShouldAddStudentToSeason()
        {
            var username = "username";

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns(username);
            var students = new List<IStudent> { student.Object};

            var seasonMock = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>();
            seasonMock.Setup(x => x.Students).Returns(seasonStudents);

            var engineMock = new Mock<IEngine>();
            engineMock.Setup(x => x.Students).Returns(students);
            var engineSeasons = new List<ISeason> { seasonMock.Object};
            engineMock.Setup(x => x.Seasons).Returns(engineSeasons);

            var factoryMock = new Mock<IAcademyFactory>();
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);
            command.Execute(new List<string> { username, "0" });
            Assert.IsTrue(seasonStudents.Contains(student.Object));
        }

        [Test]
        public void TestExecute_WhenPassedStudentIsntAlreadyPartOfSeason_ShouldReturnMessage()
        {
            var username = "username";

            var student = new Mock<IStudent>();
            student.Setup(x => x.Username).Returns(username);
            var students = new List<IStudent> { student.Object };

            var seasonMock = new Mock<ISeason>();
            var seasonStudents = new List<IStudent>();
            seasonMock.Setup(x => x.Students).Returns(seasonStudents);

            var engineMock = new Mock<IEngine>();
            engineMock.Setup(x => x.Students).Returns(students);
            var engineSeasons = new List<ISeason> { seasonMock.Object };
            engineMock.Setup(x => x.Seasons).Returns(engineSeasons);

            var factoryMock = new Mock<IAcademyFactory>();
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);
            var message = command.Execute(new List<string> { username, "0" });
            Assert.AreEqual("Student username was added to Season 0.", message);
        }
    }
}
