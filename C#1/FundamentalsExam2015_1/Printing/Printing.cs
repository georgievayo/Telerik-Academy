using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing
{
    class Printing
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double s = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2}",((n*s)/500)*p);
        }
    }
}
