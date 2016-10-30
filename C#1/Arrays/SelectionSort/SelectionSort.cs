using System;

namespace SelectionSort
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                }
                if (i != indexOfMin)
                {
                    arr[i] = arr[i] ^ arr[indexOfMin];
                    arr[indexOfMin] = arr[i] ^ arr[indexOfMin];
                    arr[i] = arr[i] ^ arr[indexOfMin];
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }

        }
    }
}
