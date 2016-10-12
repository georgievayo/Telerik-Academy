using System;

class ExchangeNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double temp = a;
        if (a > b)
        {
            a = b;
            b = temp;
        }
        Console.WriteLine("{0} {1}", a, b);
    }
}
