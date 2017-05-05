using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using ProjectManager.Core.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Commands
{
    public class ListProjectDetailsCommand : ICommand
    {
        private IDatabase db;
        private IModelsFactory factory;

        public ListProjectDetailsCommand(IDatabase database, IModelsFactory factory)
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
            var projectID = int.Parse(parameters[0]);           
            return this.db.Projects[projectID].ToString();
        }
    }
}
