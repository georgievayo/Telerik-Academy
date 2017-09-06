using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace SupermarketQueue
{
    class Program
    {
        static BigList<string> people = new BigList<string>();
        static Dictionary<string, int> orderedByName = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(' ');
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Append": Append(command[1]);
                        break;
                    case "Insert": Insert(command[2], int.Parse(command[1]));
                        break;
                    case "Find": Find(command[1]);
                        break;
                    case "Serve": Serve(int.Parse(command[1]));
                        break;
                }
                command = Console.ReadLine().Split(' ');
            }

        }

        static void Serve(int count)
        {
            if (count > people.Count)
            {
                Console.WriteLine("Error");
                return;
            }

            var served = people.Take(count).ToList();
            people.RemoveRange(0, count);

            
            foreach (var person in served)
            {
                orderedByName[person]--;
            }

            Console.WriteLine(string.Join(" ", served));
        }

        static void Append(string name)
        {
            people.Add(name);
            if (orderedByName.ContainsKey(name))
            {
                orderedByName[name]++;
            }
            else
            {
                orderedByName.Add(name, 1);
            }
            Console.WriteLine("OK");
        }

        static void Insert(string name, int position)
        {
            if (position < 0 || position > people.Count)
            {
                Console.WriteLine("Error");
                return;
            }

            if (position == people.Count)
            {
                Append(name);
                return;
            }
            else
            {
                people.Insert(position, name);
                if (orderedByName.ContainsKey(name))
                {
                    orderedByName[name]++;
                }
                else
                {
                    orderedByName.Add(name, 1);
                }
            }
            Console.WriteLine("OK");
        }

        static void Find(string name)
        {
            if (orderedByName.ContainsKey(name))
            {
                Console.WriteLine(orderedByName[name]);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
