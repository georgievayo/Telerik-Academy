using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    public class Teacher : Person, ICommentable
    {
        public List<Discipline> disciplines { get; private set; }

        public string Comment { get; set; }

        public Teacher(string name, List<Discipline> disciplines) : base(name)
        {
            this.disciplines = disciplines;
        }
    }
}
