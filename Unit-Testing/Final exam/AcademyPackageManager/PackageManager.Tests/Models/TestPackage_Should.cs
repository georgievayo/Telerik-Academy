using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    class TestPackage_Should
    {
        [Test]

        public void PackageConstrucor_ShouldSetDependenciesCorrectly_WhenParametersAreOptional()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            Assert.IsInstanceOf(typeof(HashSet<IPackage>), pack.Dependencies);
        }

        [Test]
        public void PackageConstrucor_ShouldSetDependenciesCorrectly_WhenParametersArePassed()
        {
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();
            Package pack = new Package("package", versionMock.Object, dependenciesMock.Object);
            Assert.AreSame(dependenciesMock.Object, pack.Dependencies);
        }

        [Test]
        public void PackageSetName_ShouldSetName_WhenParameterIsCorrect()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            Assert.AreEqual("package", pack.Name);
        }

        [Test]
        public void PackageSetVersion_ShouldSetVersion_WhenParameterIsCorrect()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            Assert.AreSame(versionMock.Object, pack.Version);
        }

        [Test]
        public void PackageSetUrl_ShouldSetUrl_WhenParameterIsCorrect()
        {
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(15);
            versionMock.Setup(x => x.Minor).Returns(9);
            versionMock.Setup(x => x.Patch).Returns(14);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.beta);
            Package pack = new Package("package", versionMock.Object);
            StringAssert.Contains(pack.Url, "15.9.14-beta");
        }

        [Test]
        public void PackageCompareTo_ShouldThrowArgumentNullException_WhenPassedParameterIsNull()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            Assert.Throws<ArgumentNullException>(() => pack.CompareTo(null));
        }

        [Test]
        public void PackageCompareTo_ShouldNotThrowArgumentNullException_WhenPassedParameterIsNotNull()
        {
            var versionMock = new Mock<IVersion>();

            var otherPackageMock = new Mock<IPackage>();
            otherPackageMock.Setup(x => x.Name).Returns("package");
            otherPackageMock.Setup(x => x.Version.Major).Returns(20);
            otherPackageMock.Setup(x => x.Version.Minor).Returns(20);
            otherPackageMock.Setup(x => x.Version.Patch).Returns(20);
            otherPackageMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.beta);

            Package pack = new Package("package", versionMock.Object);
            Assert.DoesNotThrow(() => pack.CompareTo(otherPackageMock.Object));
        }

        [Test]
        public void PackageCompareTo_ShouldThrowArgumentException_WhenPassedPackageHasDifferetName()
        {
            var versionMock = new Mock<IVersion>();
            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Name).Returns("otherPackage");
            Package pack = new Package("package", versionMock.Object);
            Assert.Throws<ArgumentException>(() => pack.CompareTo(otherMock.Object));
        }

        [Test]
        public void PackageCompareTo_ShouldReturnOne_WhenPassedPackageIsHigherVersion()
        {
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1500000);
            versionMock.Setup(x => x.Minor).Returns(1500000);
            versionMock.Setup(x => x.Patch).Returns(1500000);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.rc);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Version.Major).Returns(35000000);
            otherMock.Setup(x => x.Version.Minor).Returns(35000000);
            otherMock.Setup(x => x.Version.Patch).Returns(35000000);
            otherMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);
            otherMock.Setup(x => x.Name).Returns("package");
            Package pack = new Package("package", versionMock.Object);
            var result = pack.CompareTo(otherMock.Object);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void PackageCompareTo_ShouldReturnMinusOne_WhenPassedPackageIsLowerVersion()
        {
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(3500000);
            versionMock.Setup(x => x.Minor).Returns(3500000);
            versionMock.Setup(x => x.Patch).Returns(3500000);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.rc);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Version.Major).Returns(1500000);
            otherMock.Setup(x => x.Version.Minor).Returns(1500000);
            otherMock.Setup(x => x.Version.Patch).Returns(1500000);
            otherMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);
            otherMock.Setup(x => x.Name).Returns("package");
            Package pack = new Package("package", versionMock.Object);
            var result = pack.CompareTo(otherMock.Object);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void PackageCompareTo_ShouldReturnZero_WhenPassedPackageIsSameVersion()
        {
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(3500000);
            versionMock.Setup(x => x.Minor).Returns(3500000);
            versionMock.Setup(x => x.Patch).Returns(3500000);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.rc);

            var otherMock = new Mock<IPackage>();
            otherMock.Setup(x => x.Version.Major).Returns(3500000);
            otherMock.Setup(x => x.Version.Minor).Returns(3500000);
            otherMock.Setup(x => x.Version.Patch).Returns(3500000);
            otherMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.rc);
            otherMock.Setup(x => x.Name).Returns("package");
            Package pack = new Package("package", versionMock.Object);
            var result = pack.CompareTo(otherMock.Object);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void PackageEquals_ShouldThrowArgumentNullException_WhenPassedObjectIsNull()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            Assert.Throws<ArgumentNullException>(() => pack.Equals(null));
        }

        [Test]
        public void PackageEquals_ShouldThrowArgumentException_WhenPassedObjectIsNotPackage()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            
            Assert.Throws<ArgumentException>(() => pack.Equals("ifosjdkfsdo"));
        }

        [Test]
        public void PackageEquals_ShouldNotThrowException_WhenPassedObjectIsPackage()
        {
            var versionMock = new Mock<IVersion>();
            Package pack = new Package("package", versionMock.Object);
            var otherPackMock = new Mock<IPackage>();
            Assert.DoesNotThrow(() => pack.Equals(otherPackMock.Object));
        }

        [Test]
        public void PackageEquals_ShouldReturnTrue_WhenPassedObjectIsEqualToOther()
        {
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(3500000);
            versionMock.Setup(x => x.Minor).Returns(3500000);
            versionMock.Setup(x => x.Patch).Returns(3500000);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.rc);
            Package pack = new Package("package", versionMock.Object);

            var otherPackMock = new Mock<IPackage>();
            otherPackMock.Setup(x => x.Name).Returns("package");
            otherPackMock.Setup(x => x.Version.Major).Returns(3500000);
            otherPackMock.Setup(x => x.Version.Minor).Returns(3500000);
            otherPackMock.Setup(x => x.Version.Patch).Returns(3500000);
            otherPackMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.rc);

            Assert.IsTrue(pack.Equals(otherPackMock.Object));
        }

        [Test]
        public void PackageEquals_ShouldReturnFalse_WhenPassedObjectIsNotEqualToOther()
        {
            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(3500000);
            versionMock.Setup(x => x.Minor).Returns(3500000);
            versionMock.Setup(x => x.Patch).Returns(3500000);
            versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.rc);
            Package pack = new Package("package", versionMock.Object);

            var otherPackMock = new Mock<IPackage>();
            otherPackMock.Setup(x => x.Name).Returns("package");
            otherPackMock.Setup(x => x.Version.Major).Returns(3500000);
            otherPackMock.Setup(x => x.Version.Minor).Returns(280);
            otherPackMock.Setup(x => x.Version.Patch).Returns(3500000);
            otherPackMock.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.rc);

            Assert.IsFalse(pack.Equals(otherPackMock.Object));
        }
    }
}
