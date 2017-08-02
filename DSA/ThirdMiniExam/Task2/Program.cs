using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        class Edge : IComparable<Edge>
        {
            public int First;
            public int Last;
            public int Cost;

            public Edge(int first, int last, int cost)
            {
                this.First = first;
                this.Last = last;
                this.Cost = cost;
            }

            public int CompareTo(Edge other)
            {
                return this.Cost - other.Cost;
            }
        }

        static int GetValue(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return c - 'A';
            return c - 'a' + 26;
        }

        static int GetCost(List<string> path, List<string> build, List<string> destroy)
        {
            int N = path.Count, massiveCost = 0, mstCost = 0;
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < N; ++i)
            for (int j = i + 1; j < N; ++j)
            {
                if (path[i][j] == '0')
                    edges.Add(new Edge(i, j, GetValue(build[i][j])));
                else
                {
                    int val = GetValue(destroy[i][j]);
                    edges.Add(new Edge(i, j, -val));
                    massiveCost += val;
                }
            }
            edges.Sort();

            int[] color = new int[N];
            for (int i = 0; i < N; ++i)
                color[i] = i;

            for (int i = 0; i < edges.Count; ++i)
            {
                Edge e = edges[i];
                if (color[e.First] != color[e.Last])
                {
                    mstCost += e.Cost;
                    // recolor the component
                    int oldColor = color[e.Last];
                    for (int j = 0; j < N; ++j)
                        if (color[j] == oldColor)
                            color[j] = color[e.First];
                }
            }
            return massiveCost + mstCost;
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            List<string> paths = new List<string>();
            List<string> builds = new List<string>();
            List<string> destroy = new List<string>();

            for (int i = 0; i < N; i++)
            {
                paths.Add(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                builds.Add(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                destroy.Add(Console.ReadLine());
            }

            Console.WriteLine(GetCost(paths, builds, destroy));
        }
    }
}
