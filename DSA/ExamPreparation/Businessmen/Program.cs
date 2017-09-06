using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmen
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[] handshakes = new long[n + 1];
            handshakes[0] = 1;
            for (int i = 2; i < n + 1; i+=2)
            {
                for (int j = i - 2; j >= 0; j-=2)
                {
                    handshakes[i] += handshakes[j] * handshakes[i - 2 - j];
                }
            }

            Console.WriteLine(handshakes[n]);
        }
    }
}
