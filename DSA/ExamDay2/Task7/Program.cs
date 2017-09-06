using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] firstPoint = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] secondPoint = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] thirdPoint = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            double a = firstPoint[0]*(secondPoint[1] - thirdPoint[1]) - firstPoint[1]*(secondPoint[0] - thirdPoint[0]) + secondPoint[0]*thirdPoint[1] - thirdPoint[0] * secondPoint[1];
            double b = (Math.Pow(firstPoint[0], 2) + Math.Pow(firstPoint[1], 2)) * (thirdPoint[1] - secondPoint[1]) +
                       (Math.Pow(secondPoint[0], 2) + Math.Pow(secondPoint[1], 2)) * (firstPoint[1] - thirdPoint[1]) +
                       (Math.Pow(thirdPoint[0], 2) + Math.Pow(thirdPoint[1], 2)) * (secondPoint[1] - firstPoint[1]);
            double c = (Math.Pow(firstPoint[0], 2) + Math.Pow(firstPoint[1], 2)) * (secondPoint[0] - thirdPoint[0]) +
                       (Math.Pow(secondPoint[0], 2) + Math.Pow(secondPoint[1], 2)) * (thirdPoint[0] - firstPoint[0]) +
                       (Math.Pow(thirdPoint[0], 2) + Math.Pow(thirdPoint[1], 2)) * (firstPoint[0] - secondPoint[0]);


            double x = -(b / (2 * a));
            double y = -(c / (2 * a));
            Console.WriteLine("{0:F4} {1:F4}", x,y);

        }
    }
}
