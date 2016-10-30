using System;

namespace RemoveElementsFromArray
{
    class RemoveElementsFromArray
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int counter = 0;

            for (int i = 1; i < n; i++)
            {
                if (array[i - 1] > array[i])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
