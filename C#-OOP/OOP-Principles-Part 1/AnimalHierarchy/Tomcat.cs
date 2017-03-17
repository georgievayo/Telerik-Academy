using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Tomcat : Animal
    {
        public Tomcat(int age, string name) : base(age, name)
        {
            base.sex = Sex.Male;
        }
    }
}
