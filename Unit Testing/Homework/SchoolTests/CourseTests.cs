using System;
using System.Text;
using System.Collections.Generic;
using NUnit;
using NUnit.Framework;
using StudentsAndCourses;
using Moq;

namespace SchoolTests
{
    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void TestJoinCourse_WhenCourseIsNotFull_ShouldAddStudent()
        {
            Course course = new Course();
            var student = new Mock<IStudent>();
            course.JoinCourse(student.Object);

            Assert.AreEqual(1, course.ListOfStudents.Count);
        }

        [Test]
        public void TestJointCourse_WhenCourseIsFull_ShouldThrowAnException()
        {
            Course course = new Course();
            var student = new Mock<IStudent>();
            for (int i = 0; i < 30; i++)
            {
                course.JoinCourse(student.Object);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => course.JoinCourse(student.Object));
        }

        [Test]
        public void TestLeaveCourse_WhenStudentLeaveCourse_ShouldReduceNumberOfStudents()
        {
            Course course = new Course();
            var student = new Mock<IStudent>();
            for (int i = 0; i < 30; i++)
            {
                course.JoinCourse(student.Object);
            }
            course.LeaveCourse(student.Object);
            Assert.AreEqual(2, course.ListOfStudents.Count);
        }
    }
}
