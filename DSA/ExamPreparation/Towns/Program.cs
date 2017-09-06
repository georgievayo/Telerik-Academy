using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                numbers[i] = int.Parse(line[0]);
            }

            int[] bestIncreasing = new int[n];
            bestIncreasing[0] = 1;
            int maxSequence = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[i] > numbers[j] && bestIncreasing[j] > maxSequence)
                    {
                        maxSequence = bestIncreasing[j];
                    }
                }
                bestIncreasing[i] = maxSequence + 1;
                maxSequence = 0;
            }

            int[] bestDecreasing = new int[n];
            maxSequence = 0;
            bestDecreasing[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[i] > numbers[j] && bestDecreasing[j] > maxSequence)
                    {
                        maxSequence = bestDecreasing[j];
                    }
                }
                bestDecreasing[i] = maxSequence + 1;
                maxSequence = 0;
            }
            maxSequence = 0;
            for (int i = 0; i < n; i++)
            {
                var sum = bestIncreasing[i] + bestDecreasing[i];
                if (sum > maxSequence)
                {
                    maxSequence = sum;
                }
            }
            Console.WriteLine(maxSequence - 1);
        }
    }
}
