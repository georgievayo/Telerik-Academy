using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobiAvokadoto
{
    class BobiAvokadoto
    {
        static uint NumberOfSetBits(uint i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            uint c = uint.Parse(Console.ReadLine());
            uint bestComb=0;
            uint maxNumber = 0;
            for (uint i = 0; i < c; i++)
            {
                uint comb = uint.Parse(Console.ReadLine());
                bool canBeUsed = true;
                uint counter = NumberOfSetBits(comb);
                uint mask = n & comb;
                if(mask != 0)
                {
                    canBeUsed = false;
                }

                if (canBeUsed && counter>maxNumber)
                {
                    maxNumber = counter;
                    bestComb = comb;
                }
            }
            Console.WriteLine(bestComb);
        }
    }
}
