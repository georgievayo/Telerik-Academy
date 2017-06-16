using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateProjectCommand : ICommand
    {
        private const int ParameterCountConstant = 4;
        private readonly IDatabase database;
        private readonly IModelsFactory factory;

        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
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
            if (this.database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
