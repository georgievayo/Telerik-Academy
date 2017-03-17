using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
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
    class TestPackageRepositoryGetAll_Should
    {
        [Test]
        public void PackageRepositoryGetAll_ShouldReturnEmptyCollection_WhenThereIsNotAnyPassedCollections()
        {
            var loggerMock = new Mock<ILogger>();
            FakePackageRepository repo = new FakePackageRepository(loggerMock.Object);
            Assert.AreEqual(0, repo.Count);
        }

        [Test]

        public void PackageRepositoryGetAll_ShouldReturnnotEmptyCollection_WhenThereIsPassedCollections()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            List<IPackage> list = new List<IPackage>();
            list.Add(packageMock.Object);
            FakePackageRepository repo = new FakePackageRepository(loggerMock.Object, list);
            Assert.AreEqual(1, repo.Count);
        }
    }
}
