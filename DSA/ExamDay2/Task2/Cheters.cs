using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Cheters
    {
        private static Dictionary<string, List<Tuple<string, string>>> dependencies =
            new Dictionary<string, List<Tuple<string, string>>>();

        private static int n = 0;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                var subject = new StringBuilder(line[2]);
                if (line.Length > 3)
                {
                    for (int j = 3; j < line.Length; j++)
                    {
                        subject.Append(" ").Append(line[j]);
                    }
                }
                if (!dependencies.ContainsKey(subject.ToString()))
                {
                    dependencies.Add(subject.ToString(), new List<Tuple<string, string>>());
                }

                dependencies[subject.ToString()].Add(new Tuple<string, string>(line[0], line[1]));
            }

            Dictionary<string, List<string>> ordered = new Dictionary<string, List<string>>();

            foreach (var dep in dependencies)
            {
                ordered.Add(dep.Key, TopologicalSort(dep.Key));
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                var result = new List<string>();
                var subject = new StringBuilder(line[1]);
                if (line.Length > 2)
                {
                    for (int j = 2; j < line.Length; j++)
                    {
                        subject.Append(" ").Append(line[j]);
                    }
                }
                for (int j = ordered[subject.ToString()].Count - 1; j >= 0; j--)
                {
                    if (ordered[subject.ToString()][j] == line[0])
                    {
                        result.Add(ordered[subject.ToString()][j]);
                        break;
                    }
                    else
                    {
                        result.Add(ordered[subject.ToString()][j]);
                    }
                }

                Console.WriteLine(string.Join(", ", result));

            }
        }
        static Dictionary<string, TopoNode> ReadDirectedGraph(string dep)
        {
            var vertices = new Dictionary<string, TopoNode>();

            for (var i = 0; i < dependencies[dep].Count; i++)
            {
                var edge = dependencies[dep][i];

                var x = edge.Item1;
                var y = edge.Item2;

                if (vertices.ContainsKey(x) == false)
                {
                    vertices[x] = new TopoNode
                    {
                        ParentsCount = 0,
                        Children = new SortedSet<string>(),
                    };
                }

                if (vertices.ContainsKey(y) == false)
                {
                    vertices[y] = new TopoNode
                    {
                        ParentsCount = 0,
                        Children = new SortedSet<string>(),
                    };
                }
                vertices[x].Children.Add(y);
                vertices[y].ParentsCount++;
            }

            return vertices;
        }
        private static List<string> TopologicalSort(string dep)
        {
            var graph = ReadDirectedGraph(dep);
            var sources = ExtractSources(graph);

            var result = new List<string>();

            while (sources.Count > 0)
            {
                var source = sources.First();
                sources.Remove(source);
                result.Add(source);
                var newSources = graph[source].Children;
                
                graph.Remove(source);
                UpdateSources(graph, newSources, sources);
            }

            return result;
        }


        private static SortedSet<string> ExtractSources(Dictionary<string, TopoNode> graph)
        {
            var queue = new SortedSet<string>();
            foreach (var vertex in graph)
            {
                if (vertex.Value != null && vertex.Value.ParentsCount == 0)
                {
                    queue.Add(vertex.Key);
                }
            }

            return queue;
        }

        private static void UpdateSources(Dictionary<string, TopoNode> graph, SortedSet<string> newSources, SortedSet<string> sources)
        {
            foreach (var newSource in newSources)
            {
                --graph[newSource].ParentsCount;
                if (graph[newSource].ParentsCount == 0)
                {
                    sources.Add(newSource);
                }
            }
        }
    }

    class TopoNode
    {
        public SortedSet<string> Children { get; set; }
        public int ParentsCount { get; set; }
    }
}
