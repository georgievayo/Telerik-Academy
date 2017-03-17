using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 0;
            int end = 50;
            int input = -50;
            if (input < start || input > end)
            {
                throw new InvalidRangeException("Invallid input.",start.ToString(), end.ToString());
            }
        }
    }
}
