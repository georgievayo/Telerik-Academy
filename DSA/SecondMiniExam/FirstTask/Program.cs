using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static HashSet<long> set = new HashSet<long>();

        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            string[] numbersStr = Console.ReadLine().Split(' ');
            HashSet<long> numbers = new HashSet<long>();
            for (int k = 0; k < numbersStr.Length; k++)
            {
                numbers.Add(long.Parse(numbersStr[k]));
            }

            long maxNum = numbers.Max();
            set.Add(1);
            FillHash(maxNum, 1, p);

            int[] result = new int[numbers.Count];
            int i = 0;

            foreach (var number in numbers)
            {
                int counter = 0;

                foreach (var numInHashSet in set)
                {
                    if (set.Contains(number - numInHashSet))
                    {
                        counter++;
                    }


                }

                if (counter == 2)
                {
                    result[i] = 1;
                    i++;
                }
                else
                {
                    result[i] = 0;
                    i++;
                }


            }

            Console.WriteLine(string.Join(" ", result));

        }
        static void FillHash(long max, long current, int p)
        {
            if (current >= max)
            {
                return;
            }

            long left = p * current;
            var right = left + 1;

            set.Add(left);
            FillHash(max, left, p);

            set.Add(right);
            FillHash(max, right, p);
        }
    }
}
