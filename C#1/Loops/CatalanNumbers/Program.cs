using System;
using System.Numerics;

class Program
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
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(CalculateFact(2 * n) / (CalculateFact(n + 1) * CalculateFact(n)));
    }
}
