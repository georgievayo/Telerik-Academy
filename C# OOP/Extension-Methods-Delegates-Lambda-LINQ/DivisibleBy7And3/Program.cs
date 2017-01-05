using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleBy7And3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 5, 7, 21, 31, 42, 96, 84 };
            Console.WriteLine("Numbers:");
            Print(numbers);

            Console.WriteLine("\nDivisible by 3 and 7 (lambda expression):");
            var divisible = numbers.Where(number => number % 21 == 0);
            Print(divisible);

            Console.WriteLine("\nDivisible by 3 and 7 (LINQ):");
            var divisibleLINQ = from number in numbers
                                where number % 21 == 0
                                select number;
            Print(divisibleLINQ);
        }

        static void Print(IEnumerable<int> sequence)
        {
            foreach (var number in sequence)
            {
                Console.Write("{0} ", number);
            }
        }
    }
}
