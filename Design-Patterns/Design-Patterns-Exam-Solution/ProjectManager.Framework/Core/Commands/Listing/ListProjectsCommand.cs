using System;
using System.Collections.Generic;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public class ListProjectsCommand : ICommand
    {
        private const int ParameterCountConstant = 0;
        private readonly IDatabase database;

        public ListProjectsCommand(IDatabase database)
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
            var projects = this.database.Projects;

            if(projects.Count == 0)
            {
                return "No projects in the database!";
            }

            return string.Join(Environment.NewLine, projects);
        }
    }
}
