using System;

namespace TriangleSurfaceByTwoSidesAndAnAngle
{
    class TriangleSurfaceByTwoSidesAndAnAngle
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double degrees = double.Parse(Console.ReadLine());
            double angle = Math.PI * degrees / 180.0;

            Console.WriteLine("{0:F2}", (a*b*Math.Sin(angle))/2);
        }
    }
}
