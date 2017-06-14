using System;
using System.Collections.Generic;
using SchoolSystem.Data;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Factory;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private readonly IModelsFactory factory;
        private readonly IDatabase database;

        public TeacherAddMarkCommand(IModelsFactory factory, IDatabase database)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");
            }

            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null.");
            }

            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var markValue = float.Parse(parameters[2]);

            var student = this.database.Students[studentId];
            var teacher = this.database.Teachers[teacherId];
            var mark = this.factory.CreateMark(teacher.Subject, markValue);
            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
