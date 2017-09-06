using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage
{
    class Program
    { 
        private static SortedDictionary<char, Node> graph = new SortedDictionary<char, Node>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var noIncommingNodes = new SortedSet<char>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Node previous = GetNode(line[0]);
                for (int j = 1; j < line.Length; j++)
                {
                    previous = GetNode(line[j - 1]);
                    Node current = GetNode(line[j]);
                    previous.Successors.Add(current);
                    current.Parents.Add(previous);
                }

            }
            var result = new List<char>();

            foreach (var node in graph.Values)
            {
                if (node.Parents.Count == 0)
                {
                    noIncommingNodes.Add(node.Value);
                }
            }

            while (noIncommingNodes.Count > 0)
            {
                var current = noIncommingNodes.Min;
                noIncommingNodes.Remove(current);

                result.Add(current);
                var currentNode = graph[current];
                var children = graph[current].Successors.ToList();
                foreach (var child in children)
                {
                    child.Parents.Remove(currentNode);
                    currentNode.Successors.Remove(child);
                    if (child.Parents.Count == 0)
                    {
                        noIncommingNodes.Add(child.Value);
                    }
                }
            }
            Console.WriteLine(string.Join("", result));
        }

        static Node GetNode(char symbol)
        {
            if (!graph.ContainsKey(symbol))
            {
                var newNode = new Node() { Value = symbol };
                graph.Add(symbol, newNode);
            }

            return graph[symbol];
        }
        
    }

    class Node : IComparable<Node>
    {
        public Node()
        {
            this.Successors = new SortedSet<Node>();
            this.Parents = new SortedSet<Node>();
        }
        public char Value;
        public ICollection<Node> Successors;
        public ICollection<Node> Parents;


        public int CompareTo(Node other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
