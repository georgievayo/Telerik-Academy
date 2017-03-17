using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Repositories
{
    public class FakePackageRepository : PackageRepository
    {
        public FakePackageRepository(ILogger logger, ICollection<IPackage> packages = null) : base(logger, packages)
        {
        }

        public int Count
        {
            get
            {
                return this.Packages.Count;
            }
        }
        public ILogger FakeLogger
        {
            get
            {
                return this.Logger;
            }

        }
    }
}
