using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class BFS_DFS
    {
        static void Main(string[] args)
        {
        }

        static void Bfs<T>(Tree<T> root)
        {
            var q = new Queue<Tree<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var x = q.Dequeue();
                Console.WriteLine(x.Value);
                if (x.Left != null)
                {
                    q.Enqueue(x.Left);
                }
                if (x.Right != null)
                {
                    q.Enqueue(x.Right);
                }
            }
        }

        static void DfsWithStack<T>(Tree<T> root)
        {
            var q = new Stack<Tree<T>>();
            q.Push(root);

            while (q.Count > 0)
            {
                var x = q.Pop();
                Console.WriteLine(x.Value);
                if (x.Left != null)
                {
                    q.Push(x.Left);
                }
                if (x.Right != null)
                {
                    q.Push(x.Right);
                }
            }
        }
    }
}
