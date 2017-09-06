using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem1
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static 
    }

    class Node
    {
        private string Name;
        private List<Node> Children;

        public Node(string name)
        {
            Name = name;
            Children = new List<Node>();
        }

        public void Add(Node node)
        {
            this.Children.Add(node);
        }
    }
}
