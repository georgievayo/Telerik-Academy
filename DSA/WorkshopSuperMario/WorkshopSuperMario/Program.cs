using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = firstLine[0];
            int K = firstLine[1];
            int[] secondLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int previous = secondLine[0];
            int A = secondLine[1];
            int B = secondLine[2];
            int M = secondLine[3];
            long bestCost = 0;
            Queue<int>lastK = new Queue<int>();
            lastK.Enqueue(previous);
            TreeNode tree = new TreeNode(new KeyValuePair<int, int>(1, previous));
            for (int i = 2; i < N + 1; i++)
            {
                var current = (previous * A + B) % M;
                lastK.Enqueue(current);

                if (i % K == 1)
                {
                    tree = new TreeNode(new KeyValuePair<int, int>(i, current));
                }
                else
                {
                    tree.Add(new KeyValuePair<int, int>(i, current));
                }
                
                previous = current;

                if (lastK.Count % K == 0 || i == N)
                {
                    KeyValuePair<int, int> min = FindMin(tree);
                    bestCost += min.Value;
                    int index = 0;
                    while (index < min.Key)
                    {
                        lastK.Dequeue();
                        index++;
                    }
                }
            }

            Console.WriteLine(bestCost);
        }

        public static KeyValuePair<int, int> FindMin(TreeNode node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }

            return FindMin(node.Left);
        }
    }

    class TreeNode
    {
        public KeyValuePair<int, int> Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(KeyValuePair<int, int> value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public void Add(KeyValuePair<int, int> newNode)
        {
            if (newNode.Value < this.Value.Value)
            {
                this.Left = new TreeNode(newNode);
            }
            else
            {
                this.Right = new TreeNode(newNode);
            }
        }
    }

}
