using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class Display
    {
        private double? size;
        private int? numberOfColors;

        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Size should be longer than 0");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of colors should be more than 0");
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }

        public Display(double? s, int? num)
        {
            Size = s;
            NumberOfColors = num;
        }

        public override string ToString()
        {
            return $"[Size: {this.size}, Number of colors: {this.numberOfColors}]";
        }
    }
}
