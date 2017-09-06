using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    class Program
    {
        private static int k = 0;
        private static int n = 3;
        static bool[] used = new bool[n];
        static int[] arr = new int[k];
        private static char[] operators = new char[3]{'+', '-', '*'};
        private static int counter = 0;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            k = input.Length - 1;
            int result = int.Parse(Console.ReadLine());
            GenerateVariationsNoRepetitions(0, input, result);
            Console.WriteLine(counter);
        }

        static void GenerateVariationsNoRepetitions(int index, string numbers, int result)
        {
            if (index >= k)
            {
                CheckIfIsEqual(arr, operators, numbers,result);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1, numbers,result);
                        used[i] = false;
                    }
                }
            }
        }

        static void CheckIfIsEqual(int[] arr, char[] operators, string numbers, int result)
        {
            int current = numbers[0] - '0';
            for (int i = 0; i < arr.Length; i++)
            {
                switch (operators[arr[i]])
                {
                    case '+': current += (numbers[i + 1] - '0'); break;
                    case '-': current -= (numbers[i + 1] - '0'); break;
                    case '*': current *= (numbers[i + 1] - '0');
                        break;
                }  
            }

            if (current == result)
            {
                counter++;
            }

        }
    }
}
