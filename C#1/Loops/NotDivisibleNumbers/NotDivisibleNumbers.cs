﻿using System;

class NotDivisibleNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i <= number; i++)
        {
            if (!(i % 3 == 0 || i % 7 == 0))
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
