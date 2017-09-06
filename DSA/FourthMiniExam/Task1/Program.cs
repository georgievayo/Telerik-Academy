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
            var steveCoord = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var steve = new Point(steveCoord[0], steveCoord[1]);
            var v1 = steveCoord[2];

            var ellenCoord = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var ellen = new Point(ellenCoord[0], ellenCoord[1]);
            var v2 = ellenCoord[2];

            if (steve.X == ellen.X)
            {
                var timeOnSand = steve.Y / v1;
                var timeInWater = ellen.Y / v2;
                Console.WriteLine("{0:0.00}", timeOnSand + timeInWater);
                return;
            }

            if (v1 == v2)
            {
                var distance = ellen.DistanceTo(steve);
                Console.WriteLine("{0:0.00}", distance / v1);
                return;
            }

            if (steve.X > ellen.X)
            {
                var currentBest = double.MaxValue;
                for (double offset = ellen.X; offset <= steve.X; offset+=0.01)
                {
                    var onBorder = new Point(offset, 0);
                    var timeInWater = onBorder.DistanceTo(steve) / v1;
                    var timeOnSand = onBorder.DistanceTo(ellen) / v2;
                    currentBest = Math.Min(currentBest, timeInWater + timeOnSand);
                }
                
                Console.WriteLine("{0:0.00}", currentBest);
            }
            else if (steve.X < ellen.X)
            {
                var currentBest = double.MaxValue;
                for (double offset = steve.X; offset <= ellen.X; offset += 0.01)
                {
                    var onBorder = new Point(offset, 0);
                    var timeInWater = onBorder.DistanceTo(ellen) / v2;
                    var timeOnSand = onBorder.DistanceTo(steve) / v1;
                    currentBest = Math.Min(currentBest, timeInWater + timeOnSand);
                }

                Console.WriteLine("{0:0.00}", currentBest);
            }
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
