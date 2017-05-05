using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Commands
{
    public class ListProjectsCommand : ICommand
    {
        private IDatabase db;

        public ListProjectsCommand(IDatabase db)
        {
            // guard clause
            Guard.WhenArgument(db, "ListProjectsCommand Database")
                .IsNull()
                .Throw();
            this.db = db;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.db.Projects);
        }
    }
}
