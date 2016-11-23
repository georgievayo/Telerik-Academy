using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace IntegerCalculations
{
    class Program
    {
        static int maximum(params int[] listOfNumbers)
        {
            int max = listOfNumbers[0];
            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                if (listOfNumbers[i] > max)
                {
                    max = listOfNumbers[i];
                }
            }
            return max;
        }
        static int minimum(params int[] listOfNumbers)
        {
            int min = listOfNumbers[0];
            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                if (listOfNumbers[i] < min)
                {
                    min = listOfNumbers[i];
                }
            }
            return min;
        }

        static int sum(params int[] listOfNumbers)
        {
            int sum = 0;
            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                sum += listOfNumbers[i];
            }
            return sum;
        }

        static BigInteger product(params int[] listOfNumbers)
        {
            BigInteger pr = 1;
            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                pr *= listOfNumbers[i];
            }
            return pr;
        }

        static double average(params int[] listOfNumbers)
        {
            return (double)sum(listOfNumbers) / listOfNumbers.Length;
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = Convert.ToInt32(input[i]);
            }
            Console.WriteLine(minimum(numbers));
            Console.WriteLine(maximum(numbers));
            Console.WriteLine("{0:F2}", average(numbers));
            Console.WriteLine(sum(numbers));
            Console.WriteLine(product(numbers));
        }
    }
}
