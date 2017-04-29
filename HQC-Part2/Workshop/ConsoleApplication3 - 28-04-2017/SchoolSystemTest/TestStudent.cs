using System;
using System.Collections.Generic;
using NUnit.Framework;
using SchoolSystem;
using SchoolSystem.Models;

namespace SchoolSystemTest
{
    [TestFixture]
    public class TestStudent
    {
        [Test]
        public void TestStudentContructor_WhenPassedArgumentsAreCorrect_ShouldCreateNewInstance()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);
            Assert.IsInstanceOf<Student>(student);
        }

        [Test]
        public void TestStudentContructor_WhenPassedArgumentsAreCorrect_ShouldCreateEmptyListOfMarks()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);
            Assert.IsNotNull(student.Marks);
        }

        [Test]
        public void TestStudentFirstNameProperty_WhenPassedArgumentsAreCorrect_ShouldSetFirstName()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);
            Assert.AreEqual(student.FirstName, firstName);
        }

        [Test]
        public void TestStudentFirstNameProperty_WhenPassedArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var lastName = "Georgieva";
            var grade = Grade.Seventh;

            Assert.Throws<ArgumentNullException>(() => new Student(null, lastName, grade));
        }

        [Test]
        public void TestStudentFirstNameProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var firstName = "Y";
            var lastName = "Georgieva";
            var grade = Grade.Seventh;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void TestStudentLastNameProperty_WhenPassedArgumentsAreCorrect_ShouldSetLastName()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = Grade.Seventh;

            var student = new Student(firstName, lastName, grade);
            Assert.AreEqual(student.LastName, lastName);
        }

        [Test]
        public void TestStudentLastNameProperty_WhenPassedArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var firstName = "Yoana";
            var grade = Grade.Seventh;

            Assert.Throws<ArgumentNullException>(() => new Student(firstName, null, grade));
        }

        [Test]
        public void TestStudentLastNameProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var firstName = "Yoana";
            var lastName = "G";
            var grade = Grade.Seventh;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void TestStudentGradeProperty_WhenPassedArgumentsAreCorrect_ShouldSetGrade()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = Grade.Seventh;
            var student = new Student(firstName, lastName, grade);

            Assert.AreEqual(student.StudentGrade, grade);
        }

        [Test]
        public void TestStudentGradeProperty_WhenPassedArgumentIsNotCorrect_ShouldThrowArgumentException()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = (Grade)15;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void TestStudentMarksProperty_WhenPassedArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var firstName = "Yoana";
            var lastName = "Georgieva";
            var grade = Grade.Eighth;
            var student = new Student(firstName, lastName, grade);

            Assert.Throws<ArgumentNullException>(() => student.Marks = null);
        }

        [Test]
        public void TestListMarksMethod_ShouldReturnCorrectString()
        {
            var student = new Student("Yoana", "Georgieva", Grade.Fifth);
            var listOfMarks = new List<IMark>();
            listOfMarks.Add(new Mark(Subject.Math, 5.5f));
            listOfMarks.Add(new Mark(Subject.Bulgarian, 6));
            listOfMarks.Add(new Mark(Subject.Programming, 6));

            student.Marks = listOfMarks;
            var result = student.ListMarks();
            var expectedResult = @"Math => 5.5
Bulgarian => 6
Programming => 6
";
            Assert.AreEqual(result, expectedResult);
        }
    }
}
