using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintLongSequence
{
    class PrintLongSequence
    {
        static void Main(string[] args)
        {
            int number = 2;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(number);
                    number++;
                }
                else
                {
                    Console.WriteLine("-{0}", number);
                    number++;
                }
            }
        }
    }
}
