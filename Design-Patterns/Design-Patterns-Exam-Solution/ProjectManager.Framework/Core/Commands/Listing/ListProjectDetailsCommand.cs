using System;
using System.Collections.Generic;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public sealed class ListProjectDetailsCommand : ICommand
    {
        private const int ParameterCountConstant = 1;
        private readonly IDatabase database;

        public ListProjectDetailsCommand(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null.");
            }

            this.database = database;
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
            if (this.database.Projects.Count <= projectId || projectId < 0)
            {
                throw new UserValidationException("The project is not present in the database");
            }

            var project = this.database.Projects[projectId];

            return project.ToString();
        }
    }
}
