using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Factory;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void Execute_ShouldCallFactoryMethodCreateMark()
        {
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();

            var students = new Dictionary<int, IStudent>();
            var student = new Student("Penko", "Penkov", Framework.Models.Enums.Grade.Eleventh);
            students.Add(1, student);

            var teachers = new Dictionary<int, ITeacher>();
            var teacher = new Teacher("Ginka", "Penkova", Framework.Models.Enums.Subject.Math);
            teachers.Add(2, teacher);
            mockedDatabase.Setup(db => db.Students).Returns(students);
            mockedDatabase.Setup(db => db.Teachers).Returns(teachers);
            var parameters = new List<string>();
            parameters.Add("2");
            parameters.Add("1");
            parameters.Add("3.5");

            var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedDatabase.Object);
            command.Execute(parameters);

            mockedFactory.Verify(f => f.CreateMark(Framework.Models.Enums.Subject.Math, 3.5f));
        }

        [Test]
        public void Execute_ShouldAddMarkToStudentCorrectly()
        {
            var mockedFactory = new Mock<IModelsFactory>();
            var mockedDatabase = new Mock<IDatabase>();

            var students = new Dictionary<int, IStudent>();
            var student = new Student("Penko", "Penkov", Framework.Models.Enums.Grade.Eleventh);
            students.Add(1, student);

            var teachers = new Dictionary<int, ITeacher>();
            var teacher = new Teacher("Ginka", "Penkova", Framework.Models.Enums.Subject.Math);
            teachers.Add(2, teacher);
            mockedDatabase.Setup(db => db.Students).Returns(students);
            mockedDatabase.Setup(db => db.Teachers).Returns(teachers);
            var parameters = new List<string>();
            parameters.Add("2");
            parameters.Add("1");
            parameters.Add("3.5");

            var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedDatabase.Object);
            command.Execute(parameters);

            CollectionAssert.Contains(mockedDatabase.Object.Students.Select(s => s.Value.Marks), new Mark(Framework.Models.Enums.Subject.Math, 3.5f));
        }
    }
}
