using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class CardsGame
    {
        static string[] deck = {"2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac",
        "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad",
        "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah",
        "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"};
        
        static void Main(string[] args)
        {
            // Get initial data
            int n = int.Parse(Console.ReadLine());
            long[] hands = new long[n];
            for (int i = 0; i < n; i++)
            {
                hands[i] = long.Parse(Console.ReadLine());
            }

            int[] myDeck = new int[52];

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                string binNumber = Convert.ToString(hands[i], 2).PadLeft(52,'0');
                for (int j = 0; j < 52; j++)
                {
                    if (binNumber[j] == '1')
                    {
                        myDeck[51 - j]++;
                    }
                }

                result = result | hands[i];
            }

            if (result == 4503599627370495)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }

            for (int i = 0; i < 52; i++)
            {
                if (myDeck[i] % 2 != 0)
                {
                    Console.Write("{0} ", deck[i]);
                }
            }
        }
    }
}
