using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Frog : Animal
    {
        public Frog(int age, string name, Sex sex) : base(age, name, sex)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Kwak-kwak");
        }
    }
}
