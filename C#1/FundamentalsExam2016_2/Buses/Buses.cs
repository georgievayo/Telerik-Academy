using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses
{
    class Buses
    {
        static void Main(string[] args)
        {
            int c = int.Parse(Console.ReadLine());
            int groups = 1;
            int firstSpeed = int.Parse(Console.ReadLine());
            for (int i = 0; i < c-1; i++)
            {
                int s = int.Parse(Console.ReadLine());
                if(s<=firstSpeed)
                {
                    firstSpeed = s;
                    groups++;
                }
            }
            Console.WriteLine(groups);
        }
    }
}
