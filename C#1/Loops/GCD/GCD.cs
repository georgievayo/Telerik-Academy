using System;

class GCD
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int a = int.Parse(numbers[0]);
        int b = int.Parse(numbers[1]);
        while (a != b)
        {
            if (a > b)
            {
                a = a - b;
            }
            else b = b - a;
        }
        Console.WriteLine(a);
    }
}
