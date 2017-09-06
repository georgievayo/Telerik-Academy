using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int min = int.MaxValue;
            bool isOdd = false;
            BigInteger sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    sum += numbers[i];
                }

                if (numbers[i] % 2 != 0)
                {
                    isOdd = true;
                    if (Math.Abs(numbers[i]) < min)
                    {
                        min = Math.Abs(numbers[i]);
                    }
                }
            }

            if (!isOdd)
            {
                Console.WriteLine(-1);
            }

            if (sum % 2 != 0)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine(sum - min);
            }
        }
    }
}
