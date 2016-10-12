using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(a,Math.Max(b,c)));
            Console.WriteLine(Math.Min(a, Math.Min(b, c)));
            Console.WriteLine("{0:F2}",(double)(a+b+c)/3);
        }
    }
}
