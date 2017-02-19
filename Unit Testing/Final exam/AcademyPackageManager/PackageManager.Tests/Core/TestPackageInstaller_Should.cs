using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core
{
    [TestFixture]
    class TestPackageInstaller_Should
    {
        //[Test]
        //public void PackageInstallerConstructor_ShouldRestorePackages_WhenAnObjectIsConstructed()
        //{
        //    var downloaderMock = new Mock<IDownloader>();
            
        //    var projectMock = new Mock<IProject>();
        //    var packageMock = new Mock<IPackage>();
        //    packageMock.Setup(x => x.Dependencies).Returns()
        //    projectMock.Setup(x => x.PackageRepository.Add(packageMock.Object));

        //    PackageInstaller installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);
        //}
    }
}
