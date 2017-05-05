using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Core.Contracts;
using ProjectManager.Factories;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Commands
{
    public class CreateTaskCommand : ICommand
    {
        private IDatabase db;
        private IModelsFactory factory;

        public CreateTaskCommand(IDatabase db, IModelsFactory factory)
        {
            this.db = db;
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

            var projectID = int.Parse(parameters[0]);
            var userID = int.Parse(parameters[1]);
            var project = this.db.Projects[projectID];
            var owner = project.Users[userID];
            var name = parameters[2];
            var state = parameters[3];

            var task = this.factory.CreateTask(name, owner, state);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
