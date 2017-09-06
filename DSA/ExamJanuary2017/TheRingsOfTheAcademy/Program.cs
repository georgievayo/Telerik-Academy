using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TheRingsOfTheAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] rings = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                rings[int.Parse(Console.ReadLine())]++;
            }
            BigInteger permutations = 1;

            for (int i = 0; i < rings.Length; i++)
            {
                if (rings[i] > 1)
                {
                    BigInteger current = 1;
                    for (int j = 2; j <= rings[i]; j++)
                    {
                        current *= j;
                    }
                    permutations *= current;
                }
            }
            Console.WriteLine(permutations);
        }
    }
}
