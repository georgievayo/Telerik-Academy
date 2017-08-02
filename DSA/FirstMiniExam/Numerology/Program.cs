using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology
{
    class Program
    {
        private static int[] counts = new int[10];
        int exp = 0;

        static void Main()
        {
            var number = new List<int>() { 1, 8, 7, 9, 0, 3, 1, 4 };

            Generate(number, 7);
        }


        static int Calculate(int a, int b)
        {
            return (a + b) * (a ^ b) % 10;
        }

        static void Generate(List<int> number, int max)
        {
            if (max == 0)
            {
                Console.WriteLine(string.Join(" ", number));
                return;
            }

            for (int i = 0; i < max; i++)
            {
                if (number.Count - 1 < i + 1)
                {
                    continue;
                }
                
                var res = Calculate(number[i], number[i + 1]);
                Console.WriteLine("res= " + res);
                var newNum = number;
                newNum.RemoveAt(i);
                newNum.Insert(i, res);
                newNum.RemoveAt(i + 1);

                Generate(newNum, max - 1);
            }
        }
    }
}
