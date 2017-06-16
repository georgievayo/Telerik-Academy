using Ninject;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IKernel kernel;

        public CommandsFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            var command = this.kernel.Get<ICommand>(commandName);

            if (commandName == "ListProjects")
            {
                command = new CacheableCommand(command, this.kernel.Get<ICachingService>());
            }

            return new ValidatableCommand(command);
        }
    }
}
