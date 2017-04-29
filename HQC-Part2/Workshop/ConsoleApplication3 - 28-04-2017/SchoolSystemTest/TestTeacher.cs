using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystem;
using SchoolSystem.Models;

namespace SchoolSystemTest
{
    [TestFixture]
    class TestTeacher
    {
        [Test]
        public void TestTeacherContructor_WhenPassedArgumentsAreCorrect_ShouldCreateNewInstance()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var subject = Subject.Programming;

            var teacher = new Teacher(firstName, lastName, subject);
            Assert.IsInstanceOf<Teacher>(teacher);
        }

        [Test]
        public void TestTeacherFirstNameProperty_WhenPassedArgumentsAreCorrect_ShouldSetFirstName()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var subject = Subject.Programming;

            var teacher = new Teacher(firstName, lastName, subject);
            Assert.AreEqual(teacher.FirstName, firstName);
        }

        [Test]
        public void TestTeacherFirstNameProperty_WhenPassedArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var lastName = "Georgieva";
            var subject = Subject.Programming;

            Assert.Throws<ArgumentNullException>(() => new Teacher(null, lastName, subject));
        }

        [Test]
        public void TestTeacherFirstNameProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var firstName = "Y";
            var lastName = "Georgieva";
            var subject = Subject.Programming;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [Test]
        public void TestTeacherLastNameProperty_WhenPassedArgumentsAreCorrect_ShouldSetLastName()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var subject = Subject.Programming;

            var teacher = new Teacher(firstName, lastName, subject);
            Assert.AreEqual(teacher.LastName, lastName);
        }

        [Test]
        public void TestTeacherLastNameProperty_WhenPassedArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var firstName = "Yoana";
            var subject = Subject.Programming;

            Assert.Throws<ArgumentNullException>(() => new Teacher(firstName, null, subject));
        }

        [Test]
        public void TestTeacherLastNameProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var firstName = "Yoana";
            var lastName = "G";
            var subject = Subject.Programming;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [Test]
        public void TestTeacherSubjectProperty_WhenPassedArgumentsAreCorrect_ShouldSetSubject()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var subject = Subject.Programming;
            var teacher = new Teacher(firstName, lastName, subject);

            Assert.AreEqual(teacher.Subject, subject);
        }

        [Test]
        public void TestTeacherSubjectProperty_WhenPassedArgumentsAreNotCorrect_ShouldSThrowArgumentException()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var subject = (Subject)8;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [Test]
        public void TestTeacherWriteMarkToMethod_WhenStudentHasLessThan20Mark_ShouldAddMark()
        {
            var markMock = new Mock<IMark>();
            markMock.SetupGet(m => m.Subject).Returns(Subject.Math);
            markMock.SetupGet(m => m.Value).Returns(3);

            var studentMock = new Mock<IStudent>();
            var studentMarks = new List<IMark>();
            studentMock.SetupGet(s => s.Marks).Returns(studentMarks);

            var teacher = new Teacher("Yoana", "Georgieva", Subject.Math);
            teacher.WriteMarkTo(studentMock.Object, markMock.Object);
            var countOfMarks = studentMock.Object.Marks.Count;
            Assert.AreEqual(countOfMarks, 1);
        }

        [Test]
        public void TestTeacherWriteMarkToMethod_WhenStudentHas20Marks_ShouldThrowArgumentException()
        {
            var markMock = new Mock<IMark>();
            markMock.SetupGet(m => m.Subject).Returns(Subject.Math);
            markMock.SetupGet(m => m.Value).Returns(3);

            var studentMock = new Mock<IStudent>();
            var studentMarks = new List<IMark>();
            studentMock.SetupGet(s => s.Marks.Count).Returns(20);

            var teacher = new Teacher("Yoana", "Georgieva", Subject.Math);
            Assert.Throws<ArgumentException>(() => teacher.WriteMarkTo(studentMock.Object, markMock.Object));
        }
    }
}
