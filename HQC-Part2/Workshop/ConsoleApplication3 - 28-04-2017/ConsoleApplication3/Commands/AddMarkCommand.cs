using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class AddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherID = int.Parse(parameters[0]);
            var studentID = int.Parse(parameters[1]);
            var markValue = float.Parse(parameters[2]);
            var student = Engine.Students[studentID];
            var teacher = Engine.Teachers[teacherID];
            var mark = new Mark(teacher.Subject, markValue);

            teacher.WriteMarkTo(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
