﻿using System;

namespace MaximalKSum
{
    class MaximalKSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            int sum = 0;
            for (int i = n - 1; i >= n - k; i--)
            {
                sum += arr[i];
            }
            Console.WriteLine(sum);
        }
    }
}
