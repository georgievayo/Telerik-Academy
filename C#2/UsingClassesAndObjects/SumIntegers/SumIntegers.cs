using System;

namespace SumIntegers
{
    class SumIntegers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];
            long sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = Convert.ToInt32(input[i]);
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }
    }
}
