using System;

class Circle
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * r;
        double area = Math.PI * r * r;
        Console.WriteLine("{0:F2} {1:F2}", perimeter, area);
    }
}
