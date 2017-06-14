using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Execute_ShouldCallDatabasePropertyStudents()
        {
            var mockedDatabase = new Mock<IDatabase>();
            var parameters = new List<string>();
            parameters.Add("1");
            var students = new Dictionary<int, IStudent>();
            var student = new Student("Penko", "Penkov", Framework.Models.Enums.Grade.Eleventh);
            students.Add(1, student);
            mockedDatabase.Setup(db => db.Students).Returns(students);
            var command = new RemoveStudentCommand(mockedDatabase.Object);
            command.Execute(parameters);

            mockedDatabase.Verify(db => db.Students, Times.Once);
        }

        [Test]
        public void Execute_ShouldRemoveStudent()
        {
            var mockedDatabase = new Mock<IDatabase>();
            var parameters = new List<string>();
            parameters.Add("1");
            var students = new Dictionary<int, IStudent>();
            var student = new Student("Penko", "Penkov", Framework.Models.Enums.Grade.Eleventh);
            students.Add(1, student);
            mockedDatabase.Setup(db => db.Students).Returns(students);
            var command = new RemoveStudentCommand(mockedDatabase.Object);
            command.Execute(parameters);

            CollectionAssert.DoesNotContain(mockedDatabase.Object.Students.Select(s => s.Key), 1);
        }

        [Test]
        public void Execute_ShouldReturnCorrectMessage()
        {
            var mockedDatabase = new Mock<IDatabase>();
            var parameters = new List<string>();
            parameters.Add("1");
            var students = new Dictionary<int, IStudent>();
            var student = new Student("Penko", "Penkov", Framework.Models.Enums.Grade.Eleventh);
            students.Add(1, student);
            mockedDatabase.Setup(db => db.Students).Returns(students);
            var command = new RemoveStudentCommand(mockedDatabase.Object);
            var result = command.Execute(parameters);

            StringAssert.Contains("ID 1", result);
        }
    }
}
