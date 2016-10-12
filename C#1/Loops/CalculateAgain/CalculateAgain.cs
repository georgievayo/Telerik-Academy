using System;
using System.Numerics;

class CalculateAgain
{
    static BigInteger CalculateFact(int n)
    {
        BigInteger fact = 1;
        for (int i = 2; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine(CalculateFact(n) / CalculateFact(k));
    }
}

