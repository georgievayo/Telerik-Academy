using System;

class PrimeCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool isPrime = true;
        if(n <= 1)
        {
            isPrime = false;
        }
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
            }
        }
        Console.WriteLine(isPrime ? "true" : "false");
    }
}
