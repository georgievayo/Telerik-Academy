using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    struct Point3D
    {
        private double x;
        private double y;
        private double z;

        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }
        public double Z { get { return this.z; } set { this.z = value; } }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
