using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        protected double height;
        protected double width;

        public Shape(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public abstract double CalculateSurface();

    }
}
