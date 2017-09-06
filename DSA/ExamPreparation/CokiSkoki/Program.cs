using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokiSkoki
{
    class Program
    {
        private static int n = 0;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            int[] heights = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bestIncreasing = new int[n];
            bestIncreasing[n - 1] = 0;
            int maxMiddle = 0;
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (heights[i] < heights[j] && 
                        bestIncreasing[j] + 1 >= bestIncreasing[i] && 
                        heights[j] >= maxMiddle)
                    {
                        bestIncreasing[i] = bestIncreasing[j] + 1;
                        maxMiddle = heights[j];
                    }
                }
                maxMiddle = 0;
            }

            Console.WriteLine(bestIncreasing.Max());
            Console.WriteLine(string.Join(" ", bestIncreasing));
        }

    }
}
