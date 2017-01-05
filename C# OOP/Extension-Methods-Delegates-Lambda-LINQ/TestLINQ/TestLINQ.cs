using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib;


namespace TestLINQ
{
    class TestLINQ
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ana", "Angelova", 28));
            students.Add(new Student("Tereza", "Miteva",14));
            students.Add(new Student("Boqn", "Ivanov",3));
            students.Add(new Student("Ivan", "Mihov",17));
            students.Add(new Student("Tisho", "Gergiev", 36));
            students.Add(new Student("Jeni", "Babeva", 22));
            students.Add(new Student("Stamat", "Lichev", 58));
            students.Add(new Student("Petq", "Koceva", 16));
            students.Add(new Student("Ivan", "Ivanov", 21));
            students.Add(new Student("Luiza", "Tihomirova", 20));

            var firstLastName = CompareNames(students);
            Console.WriteLine("Problem 3:");
            foreach (var student in firstLastName)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            Console.WriteLine("Problem 4:");
            var between18And24 = CompareAges(students);
            foreach (var student in between18And24)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            Console.WriteLine("Problem 5:");
            var sortedList = students.OrderByDescending(student => student.FirstName)
                                     .ThenByDescending(student => student.LastName);

            foreach (var student in sortedList)
            {
                Console.WriteLine(student);
            }

        }

        static IEnumerable<Student> CompareNames(List<Student> students)
        {
            var sequence = from student in students
                           where string.Compare(student.FirstName, student.LastName) == -1
                           select student;
            return sequence;        
        }

        static IEnumerable<Student> CompareAges(List<Student> students)
        {
            var sequence = from student in students
                           where student.Age >= 18 && student.Age <= 24
                           select student;
            return sequence; 
        }


    }
}
