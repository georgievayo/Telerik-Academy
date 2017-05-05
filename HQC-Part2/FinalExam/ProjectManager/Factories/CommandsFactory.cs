using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Models;
using System;
using System.Text;
using ProjectManager.Commands;
using ProjectManager.Core;
using ProjectManager.Core.Contracts;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private IDatabase db;
        private IModelsFactory factory;

        public CommandsFactory(IDatabase db, IModelsFactory factory)
        {
            this.db = db;
            this.factory = factory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var builtCommand = this.BuildCommand(commandName);

            switch (builtCommand)
            {
                case "createproject":
                    return new CreateProjectCommand(this.db, this.factory);
                case "createtask":
                    return new CreateTaskCommand(this.db, this.factory);
                case "listprojects":
                    return new ListProjectsCommand(this.db);
                case "createuser":
                    return new CreateUserCommand(this.db, this.factory);
                default:
                    throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string command)
        {
            string commandToLower = command.ToLower();
            return commandToLower;
        }
    }
}