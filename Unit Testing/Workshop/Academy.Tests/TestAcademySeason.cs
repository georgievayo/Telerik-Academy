using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
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
    class TestAcademySeason
    {
        [Test]
        public void TestListUsers_WhenInvoked_ShouldIterateOverTrainers()
        {
            var season = new Season(2016, 2017, Initiative.SchoolAcademy);
            var trainerMock = new Mock<ITrainer>();
            season.Trainers.Add(trainerMock.Object);
            trainerMock.Setup(x => x.ToString()).Verifiable();
        }

        [Test]
        public void TestListUsers_WhenInvoked_ShouldIterateOverStudents()
        {
            var season = new Season(2016, 2017, Initiative.SchoolAcademy);
            var studentMock = new Mock<IStudent>();
            season.Students.Add(studentMock.Object);
            studentMock.Setup(x => x.ToString()).Verifiable();
        }

        [Test]
        public void TestListUsers_WhenThereIsntAnyUser_ShouldReturnMessage()
        {
            var season = new Season(2016, 2017, Initiative.SchoolAcademy);
            var result = season.ListUsers();
            Assert.AreEqual("There are no users in this season!", result);
        }

        [Test]
        public void TestListCourses_WhenInvoked_ShouldIterateOverCourses()
        {
            var season = new Season(2016, 2017, Initiative.SchoolAcademy);
            var courseMock = new Mock<ICourse>();
            season.Courses.Add(courseMock.Object);
            courseMock.Setup(x => x.ToString()).Verifiable();
        }

        [Test]
        public void TestListCourses_WhenThereIsntAnyCourse_ShouldReturnMessage()
        {
            var season = new Season(2016, 2017, Initiative.SchoolAcademy);
            var result = season.ListCourses();
            Assert.AreEqual("There are no courses in this season!", result);
        }
    }
}
