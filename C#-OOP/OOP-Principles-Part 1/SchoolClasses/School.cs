using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    public class School
    {
        public List<Class> Classes { get; private set; }

        public School(List<Class> classes)
        {
            this.Classes = classes;
        }
    }
}
