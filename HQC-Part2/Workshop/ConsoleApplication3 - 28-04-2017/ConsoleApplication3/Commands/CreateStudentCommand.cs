using System;
using System.Collections.Generic;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var student = new Student(firstName, lastName, grade);

            Engine.Students.Add(id, student);
            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id++} was created.";
        }
    }
}
