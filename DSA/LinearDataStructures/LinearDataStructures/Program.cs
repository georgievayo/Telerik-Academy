using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int>() {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2};
            //var maxElement = list.Max();

            //var occurences = new int[maxElement + 1];

            //for (int i = 0; i < list.Count; i++)
            //{
            //    occurences[list[i]]++;
            //}

            //for (int i = 0; i < occurences.Length; i++)
            //{
            //    if (occurences[i] % 2 != 0)
            //    {
            //        list.RemoveAll(num => num == i);
            //    }
            //}

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);

            //}

            //int[] numbers = new int[9] {2, 2, 3, 3, 2, 3, 4, 3, 3};
            //FindMajorant(numbers);

            Console.WriteLine(SequenceInQueue(5, 17));
            
        }

        static void FindMajorant(int[] array)
        {
            int times = (array.Length / 2) + 1;
            var occurences = new int[1001];

            for (int i = 0; i < array.Length; i++)
            {
                occurences[array[i]]++;
            }

            for (var i = 0; i < occurences.Length; i++)
            {
                if (occurences[i] == times)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        static int SequenceInQueue(int n, int m)
        {
            var queue = new Queue<int>();
            queue.Enqueue(n);
            int count = 0;
            while (queue.Peek() != m)
            {
                int last = queue.Dequeue();
                int a = last + 1;
                int b = last + 2;
                int c = last * 2;
                if (c == m || c == m - 2 || c == m - 1 || c == m / 2)
                {
                    queue.Enqueue(c);
                    count++;
                }
                else if (b == m || b == m - 1 || b == m - 2 || b == m / 2)
                {
                    queue.Enqueue(b);
                    count++;
                }
                else
                {
                    queue.Enqueue(a);
                    count++;
                }
            }
            return count;
        }
    }
}
