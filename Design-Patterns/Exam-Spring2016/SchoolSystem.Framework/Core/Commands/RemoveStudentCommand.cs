using System;
using System.Collections.Generic;
using SchoolSystem.Data;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Factory;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly IDatabase database;

        public RemoveStudentCommand(IDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null.");
            }

            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            this.database.Students.Remove(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
