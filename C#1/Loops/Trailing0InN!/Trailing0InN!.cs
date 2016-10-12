using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = 5; number / i >= 1; i *= 5)
        {
            counter += number / i;
        }
        Console.WriteLine(counter);
    }
}

