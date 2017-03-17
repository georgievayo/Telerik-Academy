using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Dog : Animal
    {
        public Dog(int age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau-bau");
        }
    }
}
