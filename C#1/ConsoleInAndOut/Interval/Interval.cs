﻿using System;

class Interval
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int count = 0;
        if (n == m)
        {
            Console.WriteLine(count);
        }
        if (m > n)
        {
            for (int i = n + 1; i < m; i++)
            {
                if (i % 5 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

    }
}