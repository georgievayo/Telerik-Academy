using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfPages
{
    class NumberOfPages
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            if(d<10)
            {
                Console.WriteLine(d);
            }
            if(d>10 && d <= 189)
            {
                Console.WriteLine(((d-9)/2)+9);
            }
            if(d>189 && d<=2889)
            {
                Console.WriteLine(((d - 189) / 3) + 99);
            }
            if(d>2889 && d <= 38889)
            {
                Console.WriteLine(((d - 2889) / 4) + 999);
            }
            if (d > 38889 && d <= 438889)
            {
                Console.WriteLine(((d - 38889) / 5) + 9999);
            }
            if (d > 438889 && d <= 1000000)
            {
                Console.WriteLine(((d - 438889) / 6) + 91666);
            }
        }
    }
}
