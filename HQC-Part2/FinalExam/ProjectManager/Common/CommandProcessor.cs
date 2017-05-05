using Bytes2you.Validation;
using ProjectManager.Core;
using System;
using System.Linq;
using ProjectManager.Common.Contracts;
using ProjectManager.Factories;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Common
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandsFactory factory;

        public CommandProcessor(ICommandsFactory factory)
        {
            this.factory = factory;
        }

        public string Process(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var splittedCommand = commandName.Split(' ')[0];
            var parameters = commandName.Split(' ').Skip(1).ToList();
            var command = this.factory.CreateCommandFromString(splittedCommand);

            return command.Execute(parameters);
        }
    }
}
