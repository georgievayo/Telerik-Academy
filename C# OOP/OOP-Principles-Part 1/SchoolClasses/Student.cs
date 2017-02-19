using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    public class Student : Person, ICommentable
    {

        public string FN { get; private set; }

        public string Comment { get; set; }

        public Student(string name, string fn) : base(name)
        {
            this.FN = fn;
        }
    }
}
