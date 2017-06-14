using System;
using System.Collections.Generic;
using SchoolSystem.Data;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly IDatabase database;

        public StudentListMarksCommand(IDatabase database)
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
            var student = this.database.Students[studentId];
            return student.ListMarks();
        }
    }
}
