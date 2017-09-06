using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var coord = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var A = new Point(coord[0], coord[1]);
            coord = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var B = new Point(coord[0], coord[1]);
            coord = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var C = new Point(coord[0], coord[1]);

            var a = B.DistanceTo(C);
            var b = A.DistanceTo(C);
            var c = A.DistanceTo(B);

            var p = (a + b + c) / 2;
            var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("{0:0.00}", (2 * area / a));
            Console.WriteLine("{0:0.00}", 2 * area / b);
            Console.WriteLine("{0:0.00}",2 * area / c);

        }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceToSquared(Point other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;
            return dx * dx + dy * dy;
        }

        public double DistanceTo(Point other)
        {
            return Math.Sqrt(this.DistanceToSquared(other));
        }
    }
}
