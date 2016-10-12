using System;
using System.Numerics;

class SumOfEvenDivisors
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        BigInteger sum = 0;
        for (int i = a; i <= b; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0 && j % 2 == 0)
                {
                    sum += j;
                }
            }
        }
        Console.WriteLine(sum);
    }
}
