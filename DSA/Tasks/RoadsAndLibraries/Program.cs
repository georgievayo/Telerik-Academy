using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RoadsAndLibraries
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                long m = Convert.ToInt32(tokens_n[1]);
                long nodeWeitht = Convert.ToInt64(tokens_n[2]);
                long edgeWeight = Convert.ToInt64(tokens_n[3]);
                List<int>[] neighbours = new List<int>[n + 1];
                for (int i = 0; i < n + 1; i++)
                {
                    neighbours[i] = new List<int>();
                }
                for (long a1 = 0; a1 < m; a1++)
                {
                    string[] tokens_city_1 = Console.ReadLine().Split(' ');
                    int city_1 = Convert.ToInt32(tokens_city_1[0]);
                    int city_2 = Convert.ToInt32(tokens_city_1[1]);
                    neighbours[city_1].Add(city_2);
                    neighbours[city_2].Add(city_1);
                }

                BigInteger otherCost = n * nodeWeitht;


                if (edgeWeight >= nodeWeitht)
                {
                    Console.WriteLine(otherCost);
                }
                else
                {
                    long treesCount = 0;
                    bool[] visited = new bool[neighbours.Length];
                    for (int i = 1; i < n + 1; i++)
                    {
                        if (!visited[i])
                        {
                            //visited[i] = true;
                            treesCount++;
                            DFS(i, neighbours, visited);
                        }
                    }
                    BigInteger cost = (n - treesCount) * edgeWeight + treesCount * nodeWeitht;
                    if (cost < otherCost)
                    {
                        Console.WriteLine(cost);
                    }
                    else
                    {
                        Console.WriteLine(otherCost);
                    }
                }
            }
        }

        static void DFS(int node, List<int>[] neighbours, bool[] visited)
        {
            visited[node] = true;
            foreach (var vertex in neighbours[node])
            {
                if (!visited[vertex])
                {
                    //visited[vertex] = true;
                    DFS(vertex, neighbours, visited);
                }
            }
        }
    }
}
