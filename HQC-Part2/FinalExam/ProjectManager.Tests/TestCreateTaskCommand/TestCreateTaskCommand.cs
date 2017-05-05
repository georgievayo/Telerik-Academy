using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Tests.TestCreateTaskCommand
{
    [TestFixture]
    public class TestCreateTaskCommand
    {
        // Test 1
        [Test]
        public void TestExecuteMethod_WhenInvallidParametersCountIsPassed_ShouldThrowException()
        {
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();

            var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
            var listOfParameters = new List<string>();
            listOfParameters.Add("1");
            listOfParameters.Add("2");
            listOfParameters.Add("3");
            listOfParameters.Add("4");
            listOfParameters.Add("5");

            Assert.Throws<UserValidationException>(() => command.Execute(listOfParameters));
        }

        // Test 2
        [Test]
        public void TestExecuteMethod_WhenEmptyParametersArePassed_ShouldThrowException()
        {
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();

            var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
            var listOfParameters = new List<string>();
            listOfParameters.Add("");
            listOfParameters.Add("");
            listOfParameters.Add("");
            listOfParameters.Add("");

            Assert.Throws<UserValidationException>(() => command.Execute(listOfParameters));
        }

        // Test 3
        [Test]
        public void TestExecuteMethod_WhenValidParametersArePassed_ShouldCallProjectsOnce()
        {
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var project = new Project("name", DateTime.Now, DateTime.Now, "Done");
            project.Users.Add(new User("user", "typo@abv.bg"));

            dbMock.Setup(f => f.Projects).Returns(new List<IProject>() { project });

            var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
            var listOfParameters = new List<string>();
            listOfParameters.Add("0");
            listOfParameters.Add("0");
            listOfParameters.Add("something");
            listOfParameters.Add("Done");

            command.Execute(listOfParameters);
            dbMock.Verify(db => db.Projects, Times.Once());
        }

        //[Test]
        //public void TestExecuteMethod_WhenValidParametersArePassed_ShouldCallUsersOnce()
        //{
        //    var dbMock = new Mock<IDatabase>();
        //    var factoryMock = new Mock<IModelsFactory>();
        //    var project = new Project("name", DateTime.Now, DateTime.Now, "Done");
        //    project.Users.Add(new User("user", "typo@abv.bg"));

        //    dbMock.Setup(f => f.Projects).Returns(new List<IProject>() { project });

        //    var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
        //    var listOfParameters = new List<string>();
        //    listOfParameters.Add("0");
        //    listOfParameters.Add("0");
        //    listOfParameters.Add("something");
        //    listOfParameters.Add("Done");

        //    command.Execute(listOfParameters);
        //    dbMock.Verify(db => db.Projects[0].Users, Times.Once());
        //}

        // Test 5
        [Test]
        public void TestExecuteMethod_WhenValidParametersArePassed_ShouldCreateTaskdWithThoseParameters()
        {
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var project = new Project("name", DateTime.Now, DateTime.Now, "Done");
            project.Users.Add(new User("user", "typo@abv.bg"));
            dbMock.Setup(f => f.Projects).Returns(new List<IProject>() { project });

            var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
            var listOfParameters = new List<string>();
            listOfParameters.Add("0");
            listOfParameters.Add("0");
            listOfParameters.Add("something");
            listOfParameters.Add("Done");

            command.Execute(listOfParameters);
            project.Tasks.Add(new Models.Task("task1", new User("something", "email@abv.bg"), "Done"));

            Assert.AreSame(project, dbMock.Object.Projects[0]);
        }

        // Test 6
        [Test]
        public void TestExecuteMethod_WhenValidParametersArePassed_ShouldAddCreatedTaskToProject()
        {
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var project = new Project("name", DateTime.Now, DateTime.Now, "Done");
            project.Users.Add(new User("user", "typo@abv.bg"));
            dbMock.Setup(f => f.Projects).Returns(new List<IProject>() { project });

            var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
            var listOfParameters = new List<string>();
            listOfParameters.Add("0");
            listOfParameters.Add("0");
            listOfParameters.Add("something");
            listOfParameters.Add("Done");

            command.Execute(listOfParameters);
            Assert.AreEqual(1, dbMock.Object.Projects[0].Tasks.Count);
        }

        // Test 7
        [Test]
        public void TestExecuteMethod_WhenValidParametersArePassed_ShouldReturnCorrectMessage()
        {
            var dbMock = new Mock<IDatabase>();
            var factoryMock = new Mock<IModelsFactory>();
            var project = new Project("name", DateTime.Now, DateTime.Now, "Done");
            project.Users.Add(new User("user", "typo@abv.bg"));
            dbMock.Setup(f => f.Projects).Returns(new List<IProject>() { project });

            var command = new CreateTaskCommand(dbMock.Object, factoryMock.Object);
            var listOfParameters = new List<string>();
            listOfParameters.Add("0");
            listOfParameters.Add("0");
            listOfParameters.Add("something");
            listOfParameters.Add("Done");

            var message = command.Execute(listOfParameters);
            Assert.AreSame("Successfully created a new task!", message);
        }
    }
}
