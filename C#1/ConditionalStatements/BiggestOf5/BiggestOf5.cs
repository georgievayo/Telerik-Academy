using System;
class BiggestOf5
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double max1 = a;
        double max2 = c;
        if (b > a)
        {
            max1 = b;
        }
        if (d > c)
        {
            max2 = d;
        }
        if (max2 > max1)
        {
            max1 = max2;
        }
        if (e > max1)
        {
            max1 = e;
        }
        Console.WriteLine(max1);
    }
}
