using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>(){ new Student("Ivan", "Petrov", 5),
                new Student("Mihaela", "Petkova", 8),
            new Student("Plamen", "Tishov", 6),
            new Student("Tereza", "Mitova", 6),
            new Student("Jeni", "Apostolova", 10),
            new Student("Tina", "Georgieva", 2),
            new Student("Ivo", "Mladenov", 4),
            new Student("Pesho", "Dimitrov", 12),
            new Student("Ivana", "Simeonova", 1),
            new Student("Plamena", "Mihailova", 11)
            };

            List<Worker> workers = new List<Worker>(){ new Worker("Mitko", "Petrov", 100M, 8),
                new Worker("Mihaela", "Todorova", 200.50M, 7),
            new Worker("Todor", "Tishov", 150.68M, 6),
            new Worker("Liza", "Mitova", 140M, 5),
            new Worker("Petq", "Apostolova", 150.21M, 8),
            new Worker("Kiril", "Georgiev", 210M, 9),
            new Worker("Toni", "Mladenov", 300.58M, 12),
            new Worker("Simeon", "Dimitrov", 78.25M, 5),
            new Worker("Katq", "Simeonova", 36M, 2),
            new Worker("Penka", "Mihailova", 110.36M, 6)
            };

            var orderedStudents = students.OrderBy(student => student.Grade);
            Console.WriteLine("Ordered students:");
            PrintCollection(orderedStudents);

            var orderedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour());
            Console.WriteLine("Ordered workers:");
            PrintCollection(orderedWorkers);

            List<Human> people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);

            var orderedPeople = people.OrderBy(person => person.FirstName).ThenBy(person => person.LastName);
            Console.WriteLine("Ordered people:");
            PrintCollection(orderedPeople);
        }

        private static void PrintCollection(IEnumerable<Human> collection)
        {
            foreach (var person in collection)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
            Console.WriteLine();
        }
    }
}
