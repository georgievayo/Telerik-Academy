using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Grapes
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger firstFac = 1;
            BigInteger secondFac = 1;
            BigInteger thirdFac = 1;

            for (int i = 1; i <= 2 * num; i++)
            {
                firstFac *= i;
            }
            for (int j = 1; j <= num + 1; j++)
            {
                secondFac *= j;
            }
            for (int k = 1; k <= num; k++)
            {
                thirdFac *= k;
            }

            if (num < 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(firstFac / (secondFac * thirdFac));
            }
            
        }
    }
}
