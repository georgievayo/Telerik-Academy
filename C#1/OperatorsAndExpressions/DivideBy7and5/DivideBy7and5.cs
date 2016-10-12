using System;

class DivideBy7and5
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if (number % 35 == 0)
        {
            Console.WriteLine("true " + number);
        }
        else  Console.WriteLine("false " + number);
    }
}