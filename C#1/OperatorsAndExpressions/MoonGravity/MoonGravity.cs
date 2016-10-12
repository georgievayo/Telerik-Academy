using System;

class MoonGravity
{
    static void Main()
    {
        decimal weightOnTheEarth = decimal.Parse(Console.ReadLine());
        decimal weightOnTheMoon = 17 * weightOnTheEarth / 100;
        Console.WriteLine("{0:F3}", weightOnTheMoon);
    }
}

