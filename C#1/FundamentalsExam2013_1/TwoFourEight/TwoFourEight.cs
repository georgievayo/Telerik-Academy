using System;
using System.Numerics;

namespace TwoFourEight
{
    class TwoFourEight
    {
        static void Main(string[] args)
        {
            BigInteger a = BigInteger.Parse(Console.ReadLine());
            BigInteger b = BigInteger.Parse(Console.ReadLine());
            BigInteger c = BigInteger.Parse(Console.ReadLine());
            BigInteger r = 0;
            if (b == 2)
            {
                r = a % c;
            }
            else if (b == 4)
            {
                r = a + c;
            }
            else if (b == 8)
            {
                r = a * c;
            }
            if (r % 4 == 0)
            {
                Console.WriteLine(r / 4);
            }
            else
            {
                Console.WriteLine(r % 4);
            }
            Console.WriteLine(r);
        }
    }
}
