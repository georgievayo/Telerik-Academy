using System;

namespace FrequentNumber
{
    class FrequentNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            int counter = 1, maxCount = 0, firstElement = arr[0], repeatingNumber = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == firstElement)
                {
                    counter++;
                    if (counter > maxCount)
                    {
                        maxCount = counter;
                        repeatingNumber = arr[i];
                    }
                }
                else
                {
                    firstElement = arr[i];
                    counter = 1;
                }
            }
            Console.WriteLine("{0} ({1} times)", repeatingNumber, maxCount);
        }
    }
}
