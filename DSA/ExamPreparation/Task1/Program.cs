using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private static double mj;
        private static double mh;
        static int count = 0;

        static void Main(string[] args)
        {
            double[] firstLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int n = (int)firstLine[0];
            Tuple<double, double>[] trees = new Tuple<double, double>[n + 1];
            Tuple<double, double> min = trees.Min();
            var edges = new List<Tuple<Tuple<double, double>, Tuple<double, double>>>();
            mj = firstLine[1];
            mh = firstLine[2];
            for (int i = 0; i < n; i++)
            {
                double[] line = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                trees[i] = Tuple.Create(line[0], line[1]);
                for (int j = i - 1; j >= 0; j--)
                {
                    double dx = Math.Abs(trees[i].Item1 - trees[j].Item1);
                    double dh = Math.Abs(trees[i].Item2 - trees[j].Item2);

                    if (dx <= mj && dh <= mh)
                    {
                        edges.Add(Tuple.Create(trees[i], trees[j]));
                    }
                }
            }



            var graph = new Graph(trees, edges);

            
            Console.WriteLine(ShortestPathFunction(graph, min));
        }

        static public Func<Tuple<double, double>, IEnumerable<Tuple<double, double>>> ShortestPathFunction(Graph graph, Tuple<double, double> start)
        {
            var previous = new Dictionary<Tuple<double, double>, Tuple<double, double>>();

            var queue = new Queue<Tuple<double, double>>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (previous.ContainsKey(neighbor))
                        continue;

                    previous[neighbor] = vertex;
                    queue.Enqueue(neighbor);
                }
            }

            Func<Tuple<double, double>, IEnumerable<Tuple<double, double>>> shortestPath = v => {
                var path = new List<Tuple<double, double>> { };

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    current = previous[current];
                };

                path.Add(start);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }
    }

    public class Graph
    {
        public Graph() { }
        public Graph(Tuple<double, double>[] vertices, List<Tuple<Tuple<double, double>, Tuple<double, double>>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<Tuple<double, double>, HashSet<Tuple<double, double>>> AdjacencyList { get; } = new Dictionary<Tuple<double, double>, HashSet<Tuple<double, double>>>();

        public void AddVertex(Tuple<double, double> vertex)
        {
            AdjacencyList[vertex] = new HashSet<Tuple<double, double>>();
        }

        public void AddEdge(Tuple<Tuple<double, double>, Tuple<double, double>> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }
}
