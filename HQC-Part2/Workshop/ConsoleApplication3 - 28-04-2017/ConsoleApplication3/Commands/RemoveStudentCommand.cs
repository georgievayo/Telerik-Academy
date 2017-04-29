using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentID = int.Parse(parameters[0]);
            Engine.Students.Remove(studentID);
            return $"Student with ID {studentID} was sucessfully removed.";
        }
    }
}
