using System;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int x = int.Parse(Console.ReadLine());
            int min = 0;
            int max = n - 1;
            do
            {
                int mid = (min + max) / 2;
                if (x > arr[mid])
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
                if (arr[mid] == x)
                {
                    Console.WriteLine(mid);
                }
                if (min > max && arr[mid] != x)
                {
                    Console.WriteLine("-1");
                }
                
            } while (min <= max);
            
            
        }
    }
}
