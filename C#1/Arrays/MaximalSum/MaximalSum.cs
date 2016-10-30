using System;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int maxSoFar = 0, maxEndingHere = 0;
            for (int i = 0; i < n; i++)
            {
                maxEndingHere = maxEndingHere + array[i];
                if (maxEndingHere < 0)
                {
                    maxEndingHere = 0;
                }
                if (maxSoFar < maxEndingHere)
                {
                    maxSoFar = maxEndingHere;
                }
            }
            Console.WriteLine(maxSoFar);
        }
    }
}
