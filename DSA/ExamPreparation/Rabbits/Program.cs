using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> rabbits = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            rabbits.RemoveAt(rabbits.Count - 1);
            int maxAnswer = rabbits.Max();
            Dictionary<int, int> answersCount = new Dictionary<int, int>();
            foreach (var answer in rabbits)
            {
                if (!answersCount.ContainsKey(answer))
                {
                    answersCount.Add(answer, 0);
                }
                answersCount[answer]++;
            }

            long minCount = 0;
            foreach (var count in answersCount)
            {
                var groupSize = count.Key + 1;
                var minGroupsCount = Math.Ceiling((decimal)count.Value / groupSize);
                minCount += (int)minGroupsCount * groupSize;
            }

            Console.WriteLine(minCount);
        }
    }
}
