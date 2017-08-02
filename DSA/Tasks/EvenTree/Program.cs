using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);
            List<int>[] neighbours = new List<int>[n + 1];
            bool[] visited = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                neighbours[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int first = int.Parse(edge[0]);
                int second = int.Parse(edge[1]);

                neighbours[first].Add(second);
                neighbours[second].Add(first);
            }
            int count = 0;
            int subtreeCount = 0;

            DFS(1, neighbours, visited, ref count);
            Console.WriteLine(count);

        }

        static int DFS(int node, List<int>[] neighbours, bool[] visited, ref int count)
        {
            var subtreeCount = 0;
            visited[node] = true;
            foreach (var vertex in neighbours[node])
            {
                if (!visited[vertex])
                {
                    if (DFS(vertex, neighbours, visited, ref count) == 1)
                    {
                        subtreeCount++;
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            return 1 - subtreeCount % 2;
        }
    }
}
