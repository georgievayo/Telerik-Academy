using System;

class BiggestOf3
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine(Math.Max(Math.Max(a, b), c));
    }
}
