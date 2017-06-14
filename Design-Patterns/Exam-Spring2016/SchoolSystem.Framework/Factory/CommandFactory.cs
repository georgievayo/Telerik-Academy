using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Factory
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceLocator serviceLocator;

        public CommandFactory(IServiceLocator serviceLocator)
        {
            if (serviceLocator == null)
            {
                throw new ArgumentNullException("Service locator cannot be null.");
            }

            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommand(string command)
        {
            var commandName = command.Split(' ')[0];
            var parsedCommand = this.serviceLocator.GetCommand(commandName);

            return parsedCommand;
        }
    }
}
