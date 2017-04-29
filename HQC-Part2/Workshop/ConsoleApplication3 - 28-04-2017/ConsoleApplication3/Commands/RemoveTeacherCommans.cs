using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class RemoveTeacherCommans : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherID = int.Parse(parameters[0]);
            Engine.Teachers.Remove(teacherID);
            return $"Student with ID {teacherID} was sucessfully removed.";
        }
    }
}
