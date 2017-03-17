using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands
{
    [TestFixture]
    class TestInstallCommand_Should
    {
        [Test]
        public void InstallCommandConstructor_ShouldThrowArgumentNullException_WhenPassedInstallerIsNull()
        {
            var packageMock = new Mock<IPackage>();
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageMock.Object));
        }

        [Test]
        public void InstallCommandConstructor_ShouldThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();

            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerMock.Object, null));
        }

        [Test]
        public void InstallCommandSetInstaller_ShouldSetInstallerCorrectly_WhenCorrectValueIsPassed()
        {
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var fakeCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);
            Assert.AreSame(installerMock.Object, fakeCommand.Install);
        }

        [Test]
        public void InstallCommandSetPackage_ShouldSetPackageCorrectly_WhenCorrectValueIsPassed()
        {
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var fakeCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);
            Assert.AreSame(packageMock.Object, fakeCommand.Pack);
        }

        [Test]
        public void InstallCommandConstructor_ShouldSetOperationCorrectly_WhenCorrectValueIsPassed()
        {
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var fakeCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);
            Assert.AreEqual(InstallerOperation.Install, fakeCommand.Install.Operation);
        }

        [Test]
        public void InstallCommandExecute_ShouldCallThePerformOperation_WhenCallMethod()
        {
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var fakeCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);
            fakeCommand.Execute();
            installerMock.Verify(i => i.PerformOperation(packageMock.Object), Times.Once);
        }


    }
}
