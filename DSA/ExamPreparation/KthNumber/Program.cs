using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace KthNumber
{
    class Program
    {
        private static Dictionary<int, int> numbersFreq = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ');
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "ADD": Add(int.Parse(command[1]));
                        break;
                    case "REMOVE":
                        Remove(int.Parse(command[1]));
                        break;
                    case "GET":
                        Find(int.Parse(command[1]));
                        break;
                }
                command = Console.ReadLine().Split(' ');
            }
            
        }

        static void Add(int number)
        {
            if (!numbersFreq.ContainsKey(number))
            {
                numbersFreq.Add(number, 1);
            }
            else
            {
                numbersFreq[number]++;
            }

            Console.WriteLine("Ok: {0} added", number);
        }

        static void Find(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("Error: {0} is invalid K", count);
                return;
            }
            
            if (numbersFreq.Count < count)
            {
                Console.WriteLine("Error: {0} is invalid K", count);
            }
            else
            {
                var mostFrequentlyUsed = numbersFreq.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToArray();
                Console.WriteLine("Ok: Found {0}", mostFrequentlyUsed[count - 1].Key);
            }
        }

        static void Remove(int number)
        {
            if (!numbersFreq.ContainsKey(number))
            {
                Console.WriteLine("Error: Number {0} not found", number);
            }
            else
            {
                numbersFreq[number]--;
                if (numbersFreq[number] == 0)
                {
                    numbersFreq.Remove(number);
                }
                Console.WriteLine("Ok: Number {0} removed", number);
            }
        }
    }
}
