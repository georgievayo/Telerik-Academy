using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Cat : Animal
    {
        public Cat(int age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public Cat(int age, string name) : base(age, name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Myau-myau");
        }
    }
}
