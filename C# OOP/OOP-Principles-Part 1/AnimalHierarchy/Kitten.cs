using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(int age, string name) : base(age, name)
        {
            base.sex = Sex.Female;
        }

    }
}
