using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var A = new Point(firstLine[0], firstLine[1]);
            var B = new Point(firstLine[2], firstLine[3]);

            var secondLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var C = new Point(secondLine[0], secondLine[1]);
            var D = new Point(secondLine[2], secondLine[3]);

            var thirdLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var E = new Point(thirdLine[0], thirdLine[1]);
            var F = new Point(thirdLine[2], thirdLine[3]);

            var lines_intersect = false;
            var segments_intersect = false;
            var firstIntersect = new Point();
            var close_p1 = new Point();
            var close_p2 = new Point();
            FindIntersection(A, B, C, D, out lines_intersect, out segments_intersect, out firstIntersect, out close_p1, out close_p2);

            var secondIntersect = new Point();
            FindIntersection(C, D, E, F, out lines_intersect, out segments_intersect, out secondIntersect, out close_p1, out close_p2);


            var b = secondIntersect.DistanceTo(firstIntersect);
            var thirdIntersect = new Point();
            FindIntersection(E, F,A, B, out lines_intersect, out segments_intersect, out thirdIntersect, out close_p1, out close_p2);
            var c = thirdIntersect.DistanceTo(secondIntersect);
            var a = firstIntersect.DistanceTo(thirdIntersect);



            var p = (a + b + c) / 2;
                var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("{0:F3}", area);
        }

        static void FindIntersection(
            Point p1, Point p2, Point p3, Point p4,
            out bool lines_intersect, out bool segments_intersect,
            out Point intersection,
            out Point close_p1, out Point close_p2)
        {
            // Get the segments' parameters.
            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            double denominator = (dy12 * dx34 - dx12 * dy34);

            double t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                / denominator;
            if (double.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new Point(float.NaN, float.NaN);
                close_p1 = new Point(float.NaN, float.NaN);
                close_p2 = new Point(float.NaN, float.NaN);
                return;
            }
            lines_intersect = true;

            double t2 =
                ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)
                / -denominator;

            // Find the point of intersection.
            intersection = new Point(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect =
            ((t1 >= 0) && (t1 <= 1) &&
             (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new Point(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new Point(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }
    }

    class Point
    {
        public double X;
        public double Y;

        public Point()
        {
            X = double.MinValue;
            Y = double.MinValue;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
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