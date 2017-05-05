using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : ICommand
    {
        private IDatabase db;

        private IModelsFactory factory;

        public CreateUserCommand(IDatabase db, IModelsFactory factory)
        {
            this.db = db;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            var projectID = int.Parse(parameters[0]);
            var username = parameters[1];
            var email = parameters[2];

            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.db.Projects[projectID].Users.Any() &&
                this.db.Projects[projectID].Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = factory.CreateUser(username, email);
            this.db.Projects[projectID].Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
