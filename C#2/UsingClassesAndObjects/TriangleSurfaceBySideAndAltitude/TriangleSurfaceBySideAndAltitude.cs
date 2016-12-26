using System;

namespace TriangleSurfaceBySideAndAltitude
{
    class TriangleSurfaceBySideAndAltitude
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());

            Console.WriteLine("{0:F2}",side*altitude/2);
        }
    }
}
