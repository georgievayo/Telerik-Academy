using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class TestPackageVersion_Should
    {
        [Test]
        public void PackageVersionConstructor_ShouldSetPassedValues_WhenTheyAreCorrect()
        {
            PackageVersion packageVersion = new PackageVersion(15, 10, 36, Enums.VersionType.alpha);
            Assert.IsInstanceOf(typeof(PackageVersion), packageVersion);
        }

        [Test]
        public void PackageVersionSetMajor_ShouldSetPassedValue_WhenItIsCorrect()
        {
            PackageVersion packageVersion = new PackageVersion(15, 10, 36, Enums.VersionType.alpha);
            Assert.AreEqual(15, packageVersion.Major);
        }

        [Test]
        public void PackageVersionSetMinor_ShouldSetPassedValue_WhenItIsCorrect()
        {
            PackageVersion packageVersion = new PackageVersion(15, 10, 36, Enums.VersionType.alpha);
            Assert.AreEqual(10, packageVersion.Minor);
        }

        [Test]
        public void PackageVersionSetPatch_ShouldSetPassedValue_WhenItIsCorrect()
        {
            PackageVersion packageVersion = new PackageVersion(15, 10, 36, Enums.VersionType.alpha);
            Assert.AreEqual(36, packageVersion.Patch);
        }

        [Test]
        public void PackageVersionSetVersionType_ShouldSetPassedValue_WhenItIsCorrect()
        {
            PackageVersion packageVersion = new PackageVersion(15, 10, 36, Enums.VersionType.alpha);
            Assert.AreEqual(Enums.VersionType.alpha, packageVersion.VersionType);
        }

        [Test]
        public void PackageVersionSetMajor_ShouldThrowArgumentException_WhenPassedValueIsNotCorrect()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(-1, 10, 36, Enums.VersionType.alpha));
        }

        [Test]
        public void PackageVersionSetMinor_ShouldThrowArgumentException_WhenPassedValueIsNotCorrect()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(15, -2, 36, Enums.VersionType.alpha));
        }

        [Test]
        public void PackageVersionSetPatch_ShouldThrowArgumentException_WhenPassedValueIsNotCorrect()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(1, 10, -36, Enums.VersionType.alpha));
        }

        [Test]
        public void PackageVersionSetVersionType_ShouldThrowArgumentException_WhenPassedValueIsNotCorrect()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(1, 10, 36, (Enums.VersionType)15));
        }


    }
}
