using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public class Path
    {
        private List<Point3D> points;

        public List<Point3D> Points { get { return this.points; } private set { this.points = value; } }

        public Path()
        {
            points = new List<Point3D>();
        }

        public void Add(Point3D point)
        {
            this.points.Add(point);
        }
    }
}
