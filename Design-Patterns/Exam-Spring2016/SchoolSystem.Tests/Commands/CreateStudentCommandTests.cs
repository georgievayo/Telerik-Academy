using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Factory;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void Execute_ShouldCallFactoryMethodCreateStudent()
        {
            var mockedGenerator = new Mock<IGenerator>();
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(db => db.Students).Returns(new Dictionary<int, IStudent>());
            mockedDatabase.Setup(db => db.Teachers).Returns(new Dictionary<int, ITeacher>());

            var listOfParameters = new List<string>();
            listOfParameters.Add("Penko");
            listOfParameters.Add("Penkov");
            listOfParameters.Add("1");

            var command = new CreateStudentCommand(mockedFactory.Object, mockedDatabase.Object, mockedGenerator.Object);

            command.Execute(listOfParameters);
            mockedFactory.Verify(f => f.CreateStudent("Penko", "Penkov", (Grade) 1), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallGeneratorMethodGetNext()
        {
            var mockedGenerator = new Mock<IGenerator>();
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(db => db.Students).Returns(new Dictionary<int, IStudent>());
            mockedDatabase.Setup(db => db.Teachers).Returns(new Dictionary<int, ITeacher>());

            var listOfParameters = new List<string>();
            listOfParameters.Add("Penko");
            listOfParameters.Add("Penkov");
            listOfParameters.Add("1");

            var command = new CreateStudentCommand(mockedFactory.Object, mockedDatabase.Object, mockedGenerator.Object);

            command.Execute(listOfParameters);
            mockedGenerator.Verify(g => g.GetNext(), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallDatabasePropertyStudents()
        {
            var mockedGenerator = new Mock<IGenerator>();
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(db => db.Students).Returns(new Dictionary<int, IStudent>());
            mockedDatabase.Setup(db => db.Teachers).Returns(new Dictionary<int, ITeacher>());

            var listOfParameters = new List<string>();
            listOfParameters.Add("Penko");
            listOfParameters.Add("Penkov");
            listOfParameters.Add("1");

            var command = new CreateStudentCommand(mockedFactory.Object, mockedDatabase.Object, mockedGenerator.Object);

            command.Execute(listOfParameters);
            mockedDatabase.Verify(db => db.Students, Times.Once);
        }

        [Test]
        public void Execute_ShouldAddNewStudentCorrectly()
        {
            var mockedGenerator = new Mock<IGenerator>();
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();
            var newStudent = new Student("Penko", "Penkov", Grade.Fifth);
            mockedDatabase.Setup(db => db.Students).Returns(new Dictionary<int, IStudent>());
            mockedDatabase.Setup(db => db.Teachers).Returns(new Dictionary<int, ITeacher>());
            mockedFactory.Setup(f => f.CreateStudent("Penko", "Penkov", Grade.Fifth)).Returns(newStudent);
            var listOfParameters = new List<string>();
            listOfParameters.Add("Penko");
            listOfParameters.Add("Penkov");
            listOfParameters.Add("5");

            var command = new CreateStudentCommand(mockedFactory.Object, mockedDatabase.Object, mockedGenerator.Object);

            command.Execute(listOfParameters);

            Assert.AreEqual(1, mockedDatabase.Object.Students.Count);
            CollectionAssert.Contains(mockedDatabase.Object.Students.Select(s => s.Value), newStudent);
        }

        [Test]
        public void Execute_ShouldReturnCorrectMessage()
        {
            var mockedGenerator = new Mock<IGenerator>();
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();
            mockedDatabase.Setup(db => db.Students).Returns(new Dictionary<int, IStudent>());
            mockedDatabase.Setup(db => db.Teachers).Returns(new Dictionary<int, ITeacher>());

            var listOfParameters = new List<string>();
            listOfParameters.Add("Penko");
            listOfParameters.Add("Penkov");
            listOfParameters.Add("1");

            var command = new CreateStudentCommand(mockedFactory.Object, mockedDatabase.Object, mockedGenerator.Object);

            var result = command.Execute(listOfParameters);
            StringAssert.Contains("Penko", result);
        }
    }
}
