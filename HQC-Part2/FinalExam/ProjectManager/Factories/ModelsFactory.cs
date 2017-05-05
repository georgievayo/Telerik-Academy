using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using System;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly Validator validator = new Validator();

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;
            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);
            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var project = new Project(name, starting, end, state);
            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(string name, IUser owner,  string state)
        {
            var task = new Task(name, owner, state);
            this.validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email);
            this.validator.Validate(user);

            return user;
        }       
    }
}
