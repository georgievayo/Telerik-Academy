using PackageManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands
{
    internal class FakeInstallCommand : InstallCommand
    {
        public FakeInstallCommand(IInstaller<IPackage> installer, IPackage package) : base(installer, package)
        {
        }
        public IPackage Pack
        {
            get
            {
                return this.Package;

            }
            set
            {
                this.Package = value;
            }
        }

        public IInstaller<IPackage> Install
        {
            get
            {
                return this.Installer;
            }
            set
            {
                this.Installer = value;
            }
        }
    }
}
