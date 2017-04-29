using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem.Commands
{
    public class ListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentID = int.Parse(parameters[0]);
            var marks = Engine.Students[studentID].ListMarks();
            return marks;
        }
    }
}
