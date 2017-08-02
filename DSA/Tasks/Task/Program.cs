using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            OrderedDictionary<uint, string> tasks = new OrderedDictionary<uint, string>();

            for (int i = 0; i < n; i++)
            {
                var newTask = Console.ReadLine().Split(' ').ToArray();
                if (newTask[0] == "New")
                {
                    tasks.Add(new Task(uint.Parse(newTask[1]), newTask[2]));
                }
                else
                {
                    
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Rest");
                        continue;
                    }

                    var taskToRemove = tasks[0];
                    Console.WriteLine(taskToRemove);
                    tasks.RemoveFirst();
                }
            }
        }
    }

    class Task : IComparable<Task>
    {
        public uint Complexity { get; private set; }

        public string Name { get; private set; }

        public Task(uint c, string name)
        {
            this.Complexity = c;
            this.Name = name;
        }

        public int CompareTo(Task obj)
        {
            if (this.Complexity < obj.Complexity)
            {
                return -1;
            }
            else if (this.Complexity > obj.Complexity)
            {
                return 1;
            }
            else
            {
                if (string.Compare(this.Name, obj.Name) < 0)
                {
                    return -1;
                }
                else if (string.Compare(this.Name, obj.Name) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
