using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
