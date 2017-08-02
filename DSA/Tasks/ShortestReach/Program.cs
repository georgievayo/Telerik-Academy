using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestReach
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine());
            for (int i = 0; i < q; i++)
            {
                string[] size = Console.ReadLine().Split(' ');
                int n = int.Parse(size[0]) + 1;
                int m = int.Parse(size[1]);
                int[,] mapMatrix = new int[n, n];
                long[] distance = new long[n];
                int[] visitedNodes = new int[n];
                for (int j = 0; j < m; j++)
                {
                    string[] edges = Console.ReadLine().Split(' ');
                    int first = int.Parse(edges[0]);
                    int second = int.Parse(edges[1]);
                    mapMatrix[first, second] = 6;
                    mapMatrix[second, first] = 6;
                    
                }

                int startingNode = int.Parse(Console.ReadLine());
                DijikstraAlgorithm(mapMatrix, ref distance, visitedNodes, startingNode);
                StringBuilder result = new StringBuilder();

                for (int j = 1; j < distance.Length; j++)
                {
                    if (distance[j] == int.MaxValue)
                    {
                        distance[j] = -1;
                    }

                    if (j == startingNode)
                    {
                        continue;
                    }

                    if (j == distance.Length - 1)
                    {
                        result.Append($"{distance[j]}");
                    }
                    else
                    {
                        result.Append($"{distance[j]} ");
                    }
                    
                }
                Console.WriteLine(result);
            }
        }

        static void DijikstraAlgorithm(int[,] mapMatrix, ref long[] distance, int[] visitedNodes, int start)
        {
            for (int i = 1; i < distance.Length; i++)
            {
                if (mapMatrix[start, i] == 0)
                {
                    distance[i] = int.MaxValue;
                }
                else
                {
                    distance[i] = mapMatrix[start, i];
                }
                visitedNodes[i] = i;
            }
            visitedNodes[0] = -1;

            for (int j = 1; j < distance.Length / 2; j++)
            {
                long currentShortestWay = int.MaxValue;
                int nextNodeOnShortestWay = 0;
                for (int i = 0; i < distance.Length; i++)
                {
                    if ((distance[i] < currentShortestWay) && (visitedNodes[i] != -1))
                    {
                        currentShortestWay = distance[i];
                        nextNodeOnShortestWay = i;
                    }
                }

                for (int i = 1; i < distance.Length; i++)
                {
                    if (visitedNodes[i] != -1)
                    {
                        if (mapMatrix[nextNodeOnShortestWay, i] != 0)
                        {
                            if (distance[i] > distance[nextNodeOnShortestWay] +
                                 mapMatrix[nextNodeOnShortestWay, i])
                            {
                                long newDistance = distance[nextNodeOnShortestWay] +
                                                   mapMatrix[nextNodeOnShortestWay, i];

                                distance[i] = newDistance;
                            }
                        }
                    }
                }
                visitedNodes[nextNodeOnShortestWay] = -1;
            }
        }

    }
}
