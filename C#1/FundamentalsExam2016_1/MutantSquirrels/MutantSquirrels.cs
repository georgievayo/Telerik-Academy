using System;
using System.Numerics;

class MutantSquirrels
{
    static void Main()
    {
        double t = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double s = double.Parse(Console.ReadLine());
        double n = double.Parse(Console.ReadLine());
        double tails = t * b * s * n;
        if (tails%2==0)
        {
            Console.WriteLine("{0:F3}", tails * 376439);
        }
        else
        {
            Console.WriteLine("{0:F3}", (double)((double)tails / 7));
        }
  
    }
}

