using System;
using NUnit.Framework;
using StudentsAndCourses;

namespace SchoolTests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void TestNameOfStudent_WhenIsCorrect_ShouldSetName()
        {
            Student student = new Student();
            student.Name = "Gosho";
            Assert.AreEqual("Gosho", student.Name);
        }

        [Test]
        public void TestNameOfStudent_WhenIsNotCorrect_ShouldThrowException()
        {
            Student student = new Student();
            Assert.Throws<ArgumentOutOfRangeException>(() => student.Name = "");
        }

        [Test]
        public void TestStudentId_WhenIsInRange_ShouldSetId()
        {
            Student student = new Student();
            student.ID = 12000;
            Assert.AreEqual(12000, student.ID);
        }

        [Test]
        public void TestStudentId_WhenIsNotInRange_ShouldThrowAnException()
        {
            Student student = new Student();
            Assert.Throws<ArgumentOutOfRangeException>(() => student.ID = 5000);
        }
    }
}
