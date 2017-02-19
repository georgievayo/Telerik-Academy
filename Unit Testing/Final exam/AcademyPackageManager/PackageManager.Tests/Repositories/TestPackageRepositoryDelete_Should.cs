using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    class TestPackageRepositoryDelete_Should
    {
        [Test]
        public void PackageRepositoryDelete_ShouldThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            var loggerMock = new Mock<ILogger>();
            PackageRepository repo = new PackageRepository(loggerMock.Object);
            Assert.Throws<ArgumentNullException>(() => repo.Delete(null));
        }

        [Test]
        public void PackageRepositoryDelete_ShouldThrowArgumentNullException_WhenPassedPackageIsCorrectButIsNotFound()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("first");
            List<IPackage> list = new List<IPackage>();
            list.Add(packageMock.Object);
            PackageRepository repo = new PackageRepository(loggerMock.Object, list);
            Assert.Throws<ArgumentNullException>(() => repo.Delete(packageMock.Object));
        }

        [Test]
        public void PackageRepositoryDelete_ShouldLog_WhenPassedPackageIsFoundAndHasDependencies()
        {
            var loggerMock = new Mock<ILogger>();
           

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(70);
            versionMock.Setup(x => x.Minor).Returns(70);
            versionMock.Setup(x => x.Patch).Returns(70);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("first", versionMock.Object);
            var otherVersionMock = new Mock<IVersion>();
            otherVersionMock.Setup(x => x.Major).Returns(50);
            otherVersionMock.Setup(x => x.Minor).Returns(50);
            otherVersionMock.Setup(x => x.Patch).Returns(50);
            otherVersionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var otherPackage = new Package("second", otherVersionMock.Object);

            package.Dependencies.Add(otherPackage);
            otherPackage.Dependencies.Add(package);
            


            List<IPackage> list = new List<IPackage>();
            list.Add(package);
            list.Add(otherPackage);

            PackageRepository repo = new PackageRepository(loggerMock.Object, list);

            repo.Delete(otherPackage);
            loggerMock.Verify(l => l.Log("second: The package is a dependency and could not be removed!"), Times.Once);
        }

        //[Test]
        //public void PackageRepositoryDelete_ShouldDelete_WhenPassedPackageIsCorrectAndIsFound()
        //{
        //    var loggerMock = new Mock<ILogger>();
        //    var packageMock = new Mock<IPackage>();
        //    packageMock.Setup(x => x.Name).Returns("first");
        //    List<IPackage> list = new List<IPackage>();
        //    list.Add(packageMock.Object);
        //    PackageRepository repo = new PackageRepository(loggerMock.Object, list);
        //    Assert.Throws<ArgumentNullException>(() => repo.Delete(packageMock.Object));
        //}
    }
}
