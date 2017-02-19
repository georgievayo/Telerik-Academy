using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Dog(15,"Rex", Sex.Male),
                new Dog(3, "Lucky", Sex.Male),
                new Kitten(10,"Pisi"),
                new Frog(3, "Buddy", Sex.Male),
                new Tomcat(4, "Tom"),
                new Dog(6, "Daisy", Sex.Female),
                new Dog(4, "Lucy", Sex.Female),
                new Kitten(8, "Petq"),
                new Tomcat(4, "Vasko"),
                new Frog(8, "Krasi", Sex.Male)
            };

            CalculateAverageAge(animals);
        }
        private static void CalculateAverageAge(IEnumerable<Animal> collection)
        {
            var dogsAges = from animal in collection
                                where animal is Dog
                                select animal.age;
            Console.WriteLine("Dogs: {0}\n", dogsAges.Average());

            var catsAges = from animal in collection
                           where animal is Cat
                           select animal.age;
            Console.WriteLine("Cats: {0}\n", catsAges.Average());

            var kittensAges = from animal in collection
                           where animal is Kitten
                           select animal.age;
            Console.WriteLine("Kittens: {0}\n", kittensAges.Average());

            var tomcatsAges = from animal in collection
                           where animal is Tomcat
                           select animal.age;
            Console.WriteLine("Tomcats: {0}\n", tomcatsAges.Average());

            var frogsAges = from animal in collection
                           where animal is Frog
                           select animal.age;
            Console.WriteLine("Frogs: {0}\n", frogsAges.Average());

        }
    }
}
