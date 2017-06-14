using System;
using System.Collections.Generic;
using SchoolSystem.Data;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Factory;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IModelsFactory factory;
        private readonly IDatabase database;
        private readonly IGenerator generator;

        public CreateStudentCommand(IModelsFactory factory, IDatabase database, IGenerator generator)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");
            }

            if (database == null)
            {
                throw new ArgumentNullException($"Database cannot be null.");
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
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.factory.CreateStudent(firstName, lastName, grade);
            var id = this.generator.GetNext();
            this.database.Students.Add(id, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }
    }
}
