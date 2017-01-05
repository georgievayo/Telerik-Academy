using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib;
using GroupLib;

namespace ProcessStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ana", "Angelova", "612506","028659", "anityyy@gmail.com", 
                new List<int>() { 4,5,2,4,3}, new Group(3,"Biology")));
            students.Add(new Student("Tereza", "Miteva", "615245", "087441559", "teri18@abv.bg",
                new List<int>() { 6, 5, 6, 4, 4 }, new Group(2, "Mathematics")));
            students.Add(new Student("Boqn", "Ivanov", "614806", "087454178", "bobi351@abv.bg",
                new List<int>() { 6, 6, 5, 6, 6 }, new Group(1, "Biology")));
            students.Add(new Student("Ivan", "Mihov", "611583", "082487659", "typcho@gmail.com",
                new List<int>() { 4, 4, 2, 4, 3 }, new Group(2, "Biology")));
            students.Add(new Student("Tisho", "Gergiev", "629806", "029659", "tisho@abv.bg",
                new List<int>() { 5, 5, 5, 4, 4}, new Group(3, "Mathematics")));
            students.Add(new Student("Jeni", "Babeva", "612806", "087424789", "jeny@gmail.com",
                new List<int>() { 4, 4, 2, 6, 2 }, new Group(2, "Mathematics")));

            var fromSecondGroupLINQ = from student in students
                                  where student.MyGroup.GroupNumber == 2
                                  orderby student.FirstName
                                  select student;
            Print(fromSecondGroupLINQ, "Students in second group with LINQ:");

            var fromSecondGroupLambda = students.OrderBy(student => student.FirstName)
                                                .Where(student => student.MyGroup.GroupNumber == 2);
            Print(fromSecondGroupLambda, "Students in second group with lambda:");

            var withAbvEmail = from student in students
                               where student.Email.EndsWith("abv.bg")
                               select student;
            Print(withAbvEmail, "Students with email in abv:");

            var withNumberFromSofia = from student in students
                                      where student.Tel.StartsWith("02")
                                      select student;
            Print(withNumberFromSofia, "Students from Sofia:");

            var withExcellentMark = from student in students
                                    where student.Marks.Contains(6)
                                    select new { FullName = string.Format("{0} {1}", student.FirstName, student.LastName), Marks = string.Join(" ", student.Marks.ToArray()) };
            Print(withExcellentMark, "Students with excellent marks:");


            var withBadMarks = from student in students
                               where Extensions.Contains(student.Marks, 2)
                               select student;
            Print(withBadMarks, "Students with at least 2 bad marks:");

            var enrolledIn06 = from student in students
                               where student.FN.Substring(4, 2) == "06"
                               select student;
            Console.WriteLine("\nMark's of students enrolled in 2006:");
            foreach (var student in enrolledIn06)
            {
                Console.WriteLine(Extensions.ToString(student.Marks));
            }

            var groupedByGroupNumber = students.GroupBy(student => student.MyGroup.GroupNumber);
            foreach (var group in groupedByGroupNumber)
            {
                Print(group, "Group:");
            }

            var studentsInMathematics = from student in students
                                        where student.MyGroup.DepartmentName == "Mathematics"
                                        select student;
            Print(studentsInMathematics, "Students in Mathematics department:");
                              
        }

        static void Print<T>(IEnumerable<T> sequence, string message)
        {
            Console.WriteLine("\n{0}", message);
            foreach (var student in sequence)
            {
                Console.WriteLine(student);
            }
        }
    }
}
