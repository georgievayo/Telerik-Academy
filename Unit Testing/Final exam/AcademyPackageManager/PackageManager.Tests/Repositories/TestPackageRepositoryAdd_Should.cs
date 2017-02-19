using NUnit.Framework;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Info.Contracts;
using Moq;
using PackageManager.Models.Contracts;
using PackageManager.Models;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    class TestPackageRepositoryAdd_Should
    {
        [Test]
        public void PackageRepositoryAdd_ShouldThrowArgumentNullException_WhenPassedValueIsNull()
        {
            var loggerMock = new Mock<ILogger>();
            var packagesMock = new Mock<ICollection<IPackage>>();
            PackageRepository repo = new PackageRepository(loggerMock.Object, packagesMock.Object);
            Assert.Throws<ArgumentNullException>(() => repo.Add(null));
        }

        [Test]
        public void PackageRepositoryAdd_ShouldNotThrowArgumentNullException_WhenPassedValueIsCorrect()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            List<IPackage> list = new List<IPackage>();
            list.Add(packageMock.Object);

            PackageRepository repo = new PackageRepository(loggerMock.Object, list);

            Assert.DoesNotThrow(() => repo.Add(packageMock.Object));
        }

        [Test]
        public void PackageRepositoryAdd_ShouldAddPackage_WhenPassedPackageDoesNotExist()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("first");
            List<IPackage> list = new List<IPackage>();
            list.Add(packageMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.Setup(x => x.Name).Returns("second");
            FakePackageRepository repo = new FakePackageRepository(loggerMock.Object, list);
            repo.Add(otherPackageMock.Object);
            Assert.AreEqual(2, repo.Count);
        }

        [Test]
        public void PackageRepositoryAdd_ShouldLog_WhenPassedPackageAlreadyExist()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("first");
            List<IPackage> list = new List<IPackage>();
            list.Add(packageMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.Setup(x => x.Name).Returns("first");
            FakePackageRepository repo = new FakePackageRepository(loggerMock.Object, list);
            repo.Add(otherPackageMock.Object);
            loggerMock.Verify(l => l.Log("first: Package with the same version is already installed!"), Times.Once);
        }

        //[Test]
        //public void PackageRepositoryAdd_ShouldUpdate_WhenPassedPackageAlreadyExistButWithLowerVersion()
        //{
        //    var loggerMock = new Mock<ILogger>();

        //    var versionMock = new Mock<IVersion>();
        //    versionMock.Setup(x => x.Major).Returns(10);
        //    versionMock.Setup(x => x.Minor).Returns(10);
        //    versionMock.Setup(x => x.Patch).Returns(10);
        //    versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

        //    var package = new Package("first", versionMock.Object);

        //    List<IPackage> list = new List<IPackage>();
        //    list.Add(package);

        //    var otherVersionMock = new Mock<IVersion>();
        //    otherVersionMock.Setup(x => x.Major).Returns(50);
        //    otherVersionMock.Setup(x => x.Minor).Returns(50);
        //    otherVersionMock.Setup(x => x.Patch).Returns(50);
        //    otherVersionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

        //    var otherPackage = new Package("first", otherVersionMock.Object);
        //    FakePackageRepository repo = new FakePackageRepository(loggerMock.Object, list);
        //    repo.Add(otherPackage);
        //    Assert.IsTrue(repo.Update(otherPackage));
        //    //loggerMock.Verify(l => l.Log("first: There is a package with newer version!"), Times.Once);
        //}

        [Test]
        public void PackageRepositoryAdd_ShouldLog_WhenPassedPackageAlreadyExistButWithNewerVersion()
        {
            var loggerMock = new Mock<ILogger>();

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(70);
            versionMock.Setup(x => x.Minor).Returns(70);
            versionMock.Setup(x => x.Patch).Returns(70);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var package = new Package("first", versionMock.Object);

            List<IPackage> list = new List<IPackage>();
            list.Add(package);

            var otherVersionMock = new Mock<IVersion>();
            otherVersionMock.Setup(x => x.Major).Returns(50);
            otherVersionMock.Setup(x => x.Minor).Returns(50);
            otherVersionMock.Setup(x => x.Patch).Returns(50);
            otherVersionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var otherPackage = new Package("first", otherVersionMock.Object);
            FakePackageRepository repo = new FakePackageRepository(loggerMock.Object, list);
            repo.Add(otherPackage);
            loggerMock.Verify(l => l.Log("first: There is a package with newer version!"), Times.Once);
        }

        [Test]
        public void PackageRepositoryAdd_ShouldLog_WhenPassedPackageAlreadyExistWithSameVersion()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("first");
            packageMock.Setup(x => x.Version.Major).Returns(90);
            packageMock.Setup(x => x.Version.Minor).Returns(90);
            packageMock.Setup(x => x.Version.Patch).Returns(90);
            packageMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.rc);

            List<IPackage> list = new List<IPackage>();
            list.Add(packageMock.Object);

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.Setup(x => x.Name).Returns("first");
            otherPackageMock.Setup(x => x.Version.Major).Returns(90);
            otherPackageMock.Setup(x => x.Version.Minor).Returns(90);
            otherPackageMock.Setup(x => x.Version.Patch).Returns(90);
            otherPackageMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.rc);
            FakePackageRepository repo = new FakePackageRepository(loggerMock.Object, list);
            repo.Add(otherPackageMock.Object);
            loggerMock.Verify(l => l.Log("first: Package with the same version is already installed!"), Times.Once);
        }

    }
}
