using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            var edges = ReadGraphAsListOfEdges(size[0], size[1]);
            int weight = int.Parse(Console.ReadLine());
            var mst = FindMinimumSpanningTreeKruskal(edges, size[0]);

            var counter = 0;
            foreach (var edge in mst)
            {
                if (edge.Weight < weight)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        private static PriorityQueue<Edge> ReadGraphAsListOfEdges(int n, int m)
        {
            var edges = new PriorityQueue<Edge>();

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var edge1 = new Edge(edge[0], edge[1], edge[2]);
                var edge2 = new Edge(edge[1], edge[0], edge[2]);
                edges.Enqueue(edge1);
                edges.Enqueue(edge2);
            }

            return edges;
        }

        static int Find(List<int> trees, int vertex)
        {
            if (trees[vertex] == -1)
            {
                return vertex;
            }

            trees[vertex] = Find(trees, trees[vertex]);
            return trees[vertex];
        }

        private static List<Edge> FindMinimumSpanningTreeKruskal(PriorityQueue<Edge> edges, int n)
        {
            var trees = Enumerable.Range(1, n + 1)
                .Select(_ => -1)
                .ToList();

            var result = new List<Edge>();

            while (edges.IsEmpty == false)
            {
                var edge = edges.Dequeue();

                if (Find(trees, edge.X) == Find(trees, edge.Y))
                {
                    continue;
                }

                result.Add(edge);

                trees[Find(trees, edge.X)] = Find(trees, edge.Y);
            }
            return result;
        }

        class Edge : IComparable<Edge>
        {
            public Edge(int x, int y, int weight)
            {
                X = x;
                Y = y;
                Weight = weight;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Weight { get; set; }

            public int CompareTo(Edge other)
            {
                var weightCompared = this.Weight.CompareTo(other.Weight);
                return weightCompared;
            }
        }
        public class PriorityQueue<T>
            where T : IComparable<T>
        {
            private List<T> heap;
            private Func<T, T, bool> compare;

            public PriorityQueue()
            {
                this.heap = new List<T>
                {
                    default(T)
                };

                this.compare = (x, y) => x.CompareTo(y) > 0;
            }

            public T Top
            {
                get
                {
                    return heap[1];
                }
            }

            public int Count
            {
                get { return heap.Count - 1; }
            }

            public bool IsEmpty
            {
                get { return Count == 0; }
            }
            public void Enqueue(T value)
            {
                var index = heap.Count; // index where inserted
                heap.Add(value);

                while (index > 1 && compare(value, heap[index / 2]))
                {
                    heap[index] = heap[index / 2];
                    index /= 2;
                }

                heap[index] = value;
            }

            public T Dequeue()
            {
                var toReturn = heap[1];
                var value = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                if (!this.IsEmpty)
                {
                    this.HeapifyDown(1, value);
                }

                return toReturn;
            }

            private void HeapifyDown(int index, T value)
            {
                while (index * 2 + 1 < heap.Count)
                {
                    var smallerKidIndex = compare(heap[index * 2], heap[index * 2 + 1])
                        ? index * 2
                        : index * 2 + 1;
                    if (compare(heap[smallerKidIndex], value))
                    {
                        heap[index] = heap[smallerKidIndex];
                        index = smallerKidIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                if (index * 2 < heap.Count)
                {
                    var smallerKidIndex = index * 2;
                    if (compare(heap[smallerKidIndex], value))
                    {
                        heap[index] = heap[smallerKidIndex];
                        index = smallerKidIndex;
                    }
                }

                heap[index] = value;
            }
        }
    }
}