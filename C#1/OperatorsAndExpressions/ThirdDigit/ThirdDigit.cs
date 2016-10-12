using System;

class ThirdDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int thirdDigit = (number / 100) % 10;
        if (thirdDigit == 7)
        {
            Console.WriteLine("true");
        }
        else Console.WriteLine("false " + thirdDigit);
    }
}
