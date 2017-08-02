using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] c = Console.ReadLine().Split(' ');
            int n = int.Parse(c[0]);
            uint x = uint.Parse(c[1]);

            var numbers = Console.ReadLine()
                .Split(' ').Select(uint.Parse).ToList();
            numbers.Sort((a, b) =>
            {
                var amod = a % x;
                var bmod = b % x;
                if (amod == bmod)
                {
                    return a.CompareTo(b);
                }
                return amod.CompareTo(bmod);
            });

            Console.WriteLine(string.Join(" ", numbers));
            //var ordered = numbers.OrderBy(num => num % x).ThenBy(num => num);

            //StringBuilder result = new StringBuilder();
            //foreach (var element in ordered)
            //{
            //    result.AppendFormat("{0} ", element);
            //}
            //result.Remove(result.Length - 1, 1);
            //Console.WriteLine(result);
        }
    }
}
