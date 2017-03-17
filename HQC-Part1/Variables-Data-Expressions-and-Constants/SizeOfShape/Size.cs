using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfShape
{
    public class Size
    {
        public double width, height;
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(Size s, double angleOfTheFigureThatWillBeRotaed)
        {
            var sin = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed));
            var cos = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed));
            var newWidth = cos * s.width + sin * s.height;
            var newHeight =  sin * s.width + cos * s.height;

            return new Size(newWidth, newHeight);
        }
    }
}
