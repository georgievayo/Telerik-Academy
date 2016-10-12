using System;

    class QuadraticEquation
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = b * b - 4 * a * c;
            if(d < 0)
            {
                Console.WriteLine("no real roots");
            }
            if(d == 0)
            {
                Console.WriteLine("{0:F2}", -b / (2*a));
            }
            if (d > 0)
            {
                Console.WriteLine("{0:F2}\n{1:F2}", (-b - Math.Sqrt(d)) / (2 * a), (-b + Math.Sqrt(d)) / (2 * a));
            }
        }
    }
