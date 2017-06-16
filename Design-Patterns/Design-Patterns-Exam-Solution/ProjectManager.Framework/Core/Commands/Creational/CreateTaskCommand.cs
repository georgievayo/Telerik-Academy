using System;
using System.Collections.Generic;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateTaskCommand : ICommand
    {
        private const int ParameterCountConstant = 4;
        private readonly IDatabase database;
        private readonly IModelsFactory factory;

        public CreateTaskCommand(IDatabase database, IModelsFactory factory)
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

            var ownerId = int.Parse(parameters[1]);
            var owner = project.Users[ownerId];

            var task = this.factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
