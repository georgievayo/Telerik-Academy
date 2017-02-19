using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public abstract class Animal : ISound
    {
        public int age { get; protected set; }

        public string name { get; protected set; }

        public Sex sex { get; protected set; }

        public Animal(int age, string name, Sex sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        public Animal(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Make some sound...");
        }
    }
}
