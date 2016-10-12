using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int firstNumber = 0;
        int secondNumber = 1;
        int nextNumber;
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