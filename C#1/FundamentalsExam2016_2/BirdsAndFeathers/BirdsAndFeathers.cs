using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsAndFeathers
{
    class BirdsAndFeathers
    {
        static void Main(string[] args)
        {
            double b = double.Parse(Console.ReadLine());
            double f = double.Parse(Console.ReadLine());
            if (b% 2 == 0)
            {
                Console.WriteLine("{0:F4}", 123123123123 * (f / b));
            }
            else
            {
                Console.WriteLine("{0:F4}",(f/b)/317);
            }
        }
    }
}
