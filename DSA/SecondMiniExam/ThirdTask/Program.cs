using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var tree = new TreeNode(1, p);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers[i] / 2; j++)
                {
                    if (tree.Search(tree, j) && tree.Search(tree, numbers[i] - j))
                    {
                        Console.WriteLine(numbers[i]);
                        break;
                    }
                }
            }

        }
    }

    class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value, int p)
        {
            this.Value = value;
            this.Left = new TreeNode(value * p, p);
            this.Right = new TreeNode(value * p + 1, p);
        }

        public bool Search(TreeNode node, int s)
        {
            if (node == null)
                return false;

            if (node.Value == s)
            {
                return true;
            }
            else if (node.Value < s)
            {
                return Search(node.Right, s);
            }
            else if (node.Value > s)
            {
                return Search(node.Left, s);
            }

            return false;
        }

    }
}
