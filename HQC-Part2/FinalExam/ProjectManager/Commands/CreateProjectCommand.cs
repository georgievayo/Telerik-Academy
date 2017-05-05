using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private IDatabase db;
        private IModelsFactory factory;

        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database")
                .IsNull()
                .Throw();
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.db = database;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.db.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var projectName = parameters[0];
            var startingDate = parameters[1];
            var endingDate = parameters[2];
            var state = parameters[3];

            var project = this.factory.CreateProject(projectName, startingDate, endingDate, state);
            this.db.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
