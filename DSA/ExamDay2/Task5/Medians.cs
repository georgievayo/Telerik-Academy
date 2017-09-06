using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task5
{
    class Medians
    {
        static List<int> numbers = new List<int>();
        static OrderedBag<int> sorted = new OrderedBag<int>();
        private static int average = 0;
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ');
            while (command[0] != "EXIT")
            {
                switch (command[0])
                {
                    case "ADD": Add(int.Parse(command[1])); break;
                    case "FIND": Console.WriteLine(Find()); break;                        
                }

                command = Console.ReadLine().Split(' ');
            }

        }

        static void Add(int number)
        {
            numbers.Add(number);
            sorted.Add(number);
        }

        static double Find()
        {
            int length = numbers.Count;
            if (length % 2 == 0)
            {
                int middle = length / 2;
                return (double)(sorted[middle] + sorted[middle - 1]) / 2;
            }
            else
            {
                int middle = sorted.Count / 2;
                return sorted[middle];
            }
        }
    }
}
