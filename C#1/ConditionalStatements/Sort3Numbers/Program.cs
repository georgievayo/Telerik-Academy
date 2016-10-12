using System;

class Program
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double max = a;
        if (b >= a)
        {
            max = b;
            if (c >= max)
            {
                max = c;
                Console.WriteLine("{0} {1} {2}", c, b, a);
            }
            else
            {
                if (c >= a)
                {
                    Console.WriteLine("{0} {1} {2}", b, c, a);
                }
                else Console.WriteLine("{0} {1} {2}", b, a, c);
            }
        }
        else
        {
            if (c >= max)
            {
                Console.WriteLine("{0} {1} {2}", c, a, b);
            }
            else
            {
                if (c >= b)
                {
                    Console.WriteLine("{0} {1} {2}", a, c, b);
                }
                else Console.WriteLine("{0} {1} {2}", a, b, c);
            }
        }
    }
}
