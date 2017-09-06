using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool[,] edges = new bool[n, n];
            bool hasDependencies = false;
            for (int i = 0; i < n; i++)
            { 
                int[] dependsOn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (dependsOn[0] != 0)
                {
                    foreach (var dep in dependsOn)
                    {
                        hasDependencies = true;
                        edges[dep - 1, i] = true;
                    }
                }
            }
            int minTime = 0;
            if (!hasDependencies)
            {
                Console.WriteLine(times.Max());
            }
            else
            {
                var independent = new List<int>();
                var removed = new bool[n];
                do
                {
                    independent = GetIndependentNodes(edges, removed);
                    int max = 0;
                    for (int i = 0; i < independent.Count; i++)
                    {
                        if (times[independent[i]] > max)
                        {
                            max = times[independent[i]];
                        }
                    }
                    minTime += max;
                    RemoveIndependent(independent, edges);
                } while (independent.Count != 0);
                if (minTime == 0)
                {
                    minTime = -1;
                }
                Console.WriteLine(minTime);
            }
        }

        static List<int> GetIndependentNodes(bool[,] neighbours, bool[] removed)
        {
            List<int> nodes = new List<int>();
            for (int i = 0; i < neighbours.GetLength(1); i++)
            {
                bool isIndependent = true;
                for (int j = 0; j < neighbours.GetLength(0); j++)
                {
                    if (neighbours[j, i])
                    {
                        isIndependent = false;
                    }
                }
                if (isIndependent && !removed[i])
                {
                    nodes.Add(i);
                    removed[i] = true;
                }
            }
            return nodes;
        }

        static void RemoveIndependent(List<int> independentNodes, bool[,] neighbours)
        {
            foreach (var node in independentNodes)
            {
                for (int i = 0; i < neighbours.GetLength(1); i++)
                {
                    neighbours[node, i] = false;
                }
            }
        }
    }
}
