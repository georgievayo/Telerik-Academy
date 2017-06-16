using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateUserCommand : ICommand
    {
        private const int ParameterCountConstant = 3;
        private readonly IDatabase database;
        private readonly IModelsFactory factory;

        public CreateUserCommand(IDatabase database, IModelsFactory factory)            
        {
            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null.");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");

            }

            this.database = database;
            this.factory = factory;
        }

        public int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public string Execute(IList<string> parameters)
        {
            var projectId = int.Parse(parameters[0]);
            var project = this.database.Projects[projectId];

            if (project.Users.Any() && project.Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.factory.CreateUser(parameters[1], parameters[2]);
            project.Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
