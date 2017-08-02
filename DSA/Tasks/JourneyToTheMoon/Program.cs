using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheMoon
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            int n = firstLine.Split(' ').Select(int.Parse).ToArray()[0];
            int m = firstLine.Split(' ').Select(int.Parse).ToArray()[1];
            List<int>[] neighbours = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                neighbours[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                string connection = Console.ReadLine();
                int first = connection.Split(' ').Select(int.Parse).ToArray()[0];
                int second = connection.Split(' ').Select(int.Parse).ToArray()[1];
                neighbours[first].Add(second);
                neighbours[second].Add(first);
            }

            List<SortedSet<int>> components = new List<SortedSet<int>>();
            int index = 0;
            bool[] visited = new bool[neighbours.Length];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    components.Add(new SortedSet<int>() {i});
                    DFS(i, neighbours, ref visited, ref components, index);
                    index++;
                }

            }

            var combinations = 0;

            for (int i = 0; i < components.Count; i++)
            {
                for (int j = 0; j < components.Count; j++)
                {
                    if (i != j)
                    {
                        combinations += components[i].Count * components[j].Count;
                    }
                }
            }

            Console.WriteLine(combinations / 2);
        }

        static void DFS(int node, List<int>[] neighbours, ref bool[] visited, ref List<SortedSet<int>> components, int index)
        {
            foreach (var vertex in neighbours[node])
            {
                if (!visited[vertex])
                {
                    visited[vertex] = true;
                    components[index].Add(vertex);
                    DFS(vertex, neighbours, ref visited, ref components, index);
                }
            }
        }
    }
}
