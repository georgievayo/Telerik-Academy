using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("a=" + a + " b=" + b);
        b = b - a;
        a = a + b;
        b = a - b;
        Console.WriteLine("a=" + a + " b=" + b);
    }
}
