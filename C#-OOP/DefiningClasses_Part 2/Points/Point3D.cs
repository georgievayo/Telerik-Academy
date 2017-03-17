using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public struct Point3D
    {
        private double x;
        private double y;
        private double z;

        private static readonly Point3D start;

        public double X { get { return this.x; } private set { this.x = value; } }
        public double Y { get { return this.y; } private set { this.y = value; } }
        public double Z { get { return this.z; } private set { this.z = value; } }

        static Point3D O { get { return start; } }

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        static Point3D()
        {
            start.x = 0;
            start.y = 0;
            start.z = 0;
        }
        public override string ToString()
        {
            return $"[{this.X}, {this.Y}, {this.Z}]";
        }
    }
}