using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long firstNumber = 0;
        long secondNumber = 1;
        long nextNumber = 0;
        if (n == 1)
        {
            Console.WriteLine(firstNumber);
        }
        if (n == 2)
        {
            Console.WriteLine("{0}, {1}", firstNumber, secondNumber);
        }
        if (n > 2)
        {
            Console.Write("{0}, {1}, ", firstNumber, secondNumber);
            for (int i = 3; i <= n; i++)
            {
                nextNumber = firstNumber + secondNumber;
                Console.Write(i==n ? "{0}" : "{0}, ", nextNumber);
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
        }

    }
}