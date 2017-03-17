using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public static class Calculator
    {
        public static double CalculateDistance(Point3D a, Point3D b)
        {
            double dist = 0;
            dist = Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2) + Math.Pow((a.Z - b.Z), 2));
            return dist;
        }
    }
}
