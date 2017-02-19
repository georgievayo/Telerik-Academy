using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests
{
    [TestFixture]
    class TestAcademyCourse
    {
        [TestCase ("an")]
        [TestCase(";'pleokfwijugtifjeowdpws[]sepfoijgtufijdkospla[]dpfogitjfdkospl[fplgokijfkodps[pfkogitdpos[[fpgoihftdp[fpgotieop")]
        [TestCase(null)]
        [TestCase(" ")]
        public void TestCourseName_WhenPassIncorrectName_ShouldThrowAnException(string name)
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.Throws<ArgumentException>(() => course.Name = name);
        }

        [Test]
        public void TestCourseName_WhenPassCorrectName_ShouldntThrowException()
        {
            Assert.DoesNotThrow(() => new Course("fjsdklds", 5, DateTime.Now, DateTime.Now));
        }

        [Test]
        public void TestCourseName_WhenPassCorrectName_ShouldAssignName()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.AreEqual("fjsdklds", course.Name);
        }

        [TestCase (0)]
        [TestCase(8)]
        public void TestCourseLecturesPerWeek_WhenPassIncorrectNumberOfLectures_ShouldThrowAnArgumentException(int lectures)
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.Throws<ArgumentException>(() => course.LecturesPerWeek = lectures);
        }

        [Test]
        public void TestCourseLecturesPerWeek_WhenPassCorrectNumberOfLectures_ShouldntThrowAnArgumentException()
        {
            Assert.DoesNotThrow(() => new Course("fjsdklds", 5, DateTime.Now, DateTime.Now));
        }

        [Test]
        public void TestCourseLecturesPerWeek_WhenPassCorrectNumberOfLectures_ShouldAssignNumberOfLEctures()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.AreEqual(5, course.LecturesPerWeek);
        }

        [Test]
        public void TestCourseStartingDate_WhenPassCorrectDate_ShouldntThrowAnArgumentException()
        {
            Assert.DoesNotThrow(() => new Course("fjsdklds", 5, DateTime.Now, DateTime.Now));
        }

        [Test]
        public void TestCourseStartingDate_WhenPassCorrectDate_ShouldAssignStartingDate()
        {
            var starting = DateTime.Now;
            var course = new Course("fjsdklds", 5, starting, DateTime.Now);
            Assert.AreEqual(starting, course.StartingDate);
        }

        [Test]
        public void TestCourseEndingDate_WhenPassCorrectDate_ShouldntThrowAnArgumentException()
        {
            Assert.DoesNotThrow(() => new Course("fjsdklds", 5, DateTime.Now, DateTime.Now));
        }

        [Test]
        public void TestCourseEndingDate_WhenPassCorrectDate_ShouldAssignStartingDate()
        {
            var ending = DateTime.Now;
            var course = new Course("fjsdklds", 5, DateTime.Now, ending);
            Assert.AreEqual(ending, course.EndingDate);
        }

        [Test]
        public void TestOnlineStudents_WhenInitializeCourse_ShouldCreateEmptyList()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.AreEqual(0, course.OnlineStudents.Count);
        }

        [Test]
        public void TestOnsiteStudents_WhenInitializeCourse_ShouldCreateEmptyList()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.AreEqual(0, course.OnsiteStudents.Count);
        }

        [Test]
        public void TestLectures_WhenInitializeCourse_ShouldCreateEmptyList()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            Assert.AreEqual(0, course.Lectures.Count);
        }

        [Test]
        public void TestLectures_WhenInvokeToString_ShouldReturnListOfLectures()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString()).Verifiable();
        }

        [Test]
        public void TestLectures_WhenThereIsntAnyCourse_ShouldReturnAMessage()
        {
            var course = new Course("fjsdklds", 5, DateTime.Now, DateTime.Now);
            var result = course.ToString();
            StringAssert.Contains("  * There are no lectures in this course!", result);
        }
    }
}
