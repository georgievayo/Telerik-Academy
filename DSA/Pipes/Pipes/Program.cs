using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int m = int.Parse(Console.ReadLine());
            int[] pipes = new int[n];

            int average = 0;
            for (int i = 0; i < n; i++)
            {
                pipes[i] = int.Parse(Console.ReadLine());
                average += pipes[i];
            }
            average /= m;

            var result = BinarySearch(length => CountPipes(pipes, length) >= m, 1, average + 1);
        }

        static int CountPipes(int[] pipes, int length)
        {
            int count = 0;
            foreach (var pipe in pipes)
            {
                count += pipe / length;
            }
            return count;
        }

        static int BinarySearch(Func<int, bool> f, int left, int right)
        {
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (f(middle))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left - 1;
        }
    }
}
