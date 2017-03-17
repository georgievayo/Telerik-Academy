using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    class TestProject_Should
    {
        [Test]
        public void ProjectConstructor_ShouldSetPackageRepositoryCorrectly_WhenParameterPackagesIsOptional()
        {
            Project project = new Project("UnitTesting", "TelerikAcademy");
            Assert.IsInstanceOf(typeof(PackageRepository),project.PackageRepository);
        }

        [Test]
        public void ProjectConstructor_ShouldSetPackageRepositoryCorrectly_WhenParameterPackagesIsPassed()
        {
            var repos = new Mock<IRepository<IPackage>>();
            Project project = new Project("UnitTesting", "TelerikAcademy", repos.Object);
            Assert.AreSame(repos.Object, project.PackageRepository);
        }

        [Test]
        public void ProjectSetName_ShouldSetNameCorrectly_WhenPassedArgumentIsCorrect()
        {
            var repos = new Mock<IRepository<IPackage>>();
            Project project = new Project("UnitTesting", "TelerikAcademy", repos.Object);
            Assert.AreEqual("UnitTesting", project.Name);
        }

        [Test]
        public void ProjectSetLocation_ShouldSetLocationCorrectly_WhenPassedArgumentIsCorrect()
        {
            var repos = new Mock<IRepository<IPackage>>();
            Project project = new Project("UnitTesting", "TelerikAcademy", repos.Object);
            Assert.AreEqual("TelerikAcademy", project.Location);
        }
    }
}
