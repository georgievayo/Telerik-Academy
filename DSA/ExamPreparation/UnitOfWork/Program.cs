using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Unit> orderedByName = new Dictionary<string, Unit>();
            Dictionary<string, SortedSet<Unit>> orderedByType = new Dictionary<string, SortedSet<Unit>>();
            SortedSet<Unit> orderedByPower = new SortedSet<Unit>();
            string[] command = Console.ReadLine().Split(' ');
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        {
                            var unit = new Unit(command[1], command[2], int.Parse(command[3]));
                            Add(orderedByName, orderedByType, orderedByPower, unit);
                            break;
                        }
                    case "remove":
                        {
                            Remove(orderedByName, orderedByType, orderedByPower, command[1]);
                            break;
                        }
                    case "find":
                        {
                            Find(orderedByType, command[1]);
                            break;
                        }
                    case "power":
                        {
                            Power(orderedByPower, int.Parse(command[1]));
                            break;
                        }
                }
                command = Console.ReadLine().Split(' ');
            }
        }

        static void Add(Dictionary<string, Unit> orderedByName,
            Dictionary<string, SortedSet<Unit>> orderedByType,
            SortedSet<Unit> orderedByPower, Unit unit)
        {
            if (orderedByName.ContainsKey(unit.Name))
            {
                Console.WriteLine("FAIL: {0} already exists!", unit.Name);
            }
            else
            {
                orderedByName.Add(unit.Name, unit);
                if (orderedByType.ContainsKey(unit.Type))
                {
                    orderedByType[unit.Type].Add(unit);
                }
                else
                {
                    orderedByType.Add(unit.Type, new SortedSet<Unit>() {unit});
                }
                
                orderedByPower.Add(unit);
                Console.WriteLine("SUCCESS: {0} added!", unit.Name);
            }
        }

        static void Remove(Dictionary<string, Unit> orderedByName, Dictionary<string, SortedSet<Unit>> orderedByType, SortedSet<Unit> orderedByPower, string name)
        {
            if (!orderedByName.ContainsKey(name))
            {
                Console.WriteLine("FAIL: {0} could not be found!", name);
            }
            else
            {
                var unit = orderedByName[name];
                orderedByName.Remove(name);
                orderedByType[unit.Type].Remove(unit);
                orderedByPower.Remove(unit);
                Console.WriteLine("SUCCESS: {0} removed!", name);
            }
        }

        static void Find(Dictionary<string, SortedSet<Unit>> orderedByType, string type)
        {
            if (!orderedByType.ContainsKey(type))
            {
                Console.WriteLine("RESULT: ");
            }
            else
            {
                Console.WriteLine("RESULT: " + string.Join(", ", orderedByType[type].Take(10)));
            }
        }

        static void Power(SortedSet<Unit> orderedByPower, int n)
        {
            Console.WriteLine("RESULT: " + string.Join(", ", orderedByPower.Take(n)));
        }
    }

    class Unit : IComparable<Unit>
    {
        public string Name;
        public string Type;
        public int Attack;

        public Unit(string name, string type, int attack)
        {
            Name = name;
            Type = type;
            Attack = attack;
        }

        public int CompareTo(Unit other)
        {
            if (this.Attack > other.Attack)
            {
                return -1;
            }
            else if (this.Attack < other.Attack)
            {
                return 1;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }
}
