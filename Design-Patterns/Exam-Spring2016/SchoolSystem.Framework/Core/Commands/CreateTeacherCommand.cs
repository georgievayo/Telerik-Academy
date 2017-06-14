using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Factory;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Data;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly IModelsFactory factory;
        private readonly IDatabase database;
        private readonly IGenerator generator;

        public CreateTeacherCommand(IModelsFactory factory, IDatabase database, IGenerator generator)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");
            }

            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null.");
            }

            if (generator == null)
            {
                throw new ArgumentNullException($"Generator cannot be null.");
            }

            this.factory = factory;
            this.database = database;
            this.generator = generator;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.factory.CreateTeacher(firstName, lastName, subject);
            var id = this.generator.GetNext();
            this.database.Teachers.Add(id, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
        }
    }
}
