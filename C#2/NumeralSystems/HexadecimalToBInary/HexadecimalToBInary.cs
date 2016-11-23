using System;

namespace HexadecimalToBInary
{
    class HexadecimalToBInary
    {
        static long ConvertNumberToDec(string hex)
        {
            long dec = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                switch (hex[i])
                {
                    case '1': dec += 1 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '2': dec += 2 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '3': dec += 3 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '4': dec += 4 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '5': dec += 5 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '6': dec += 6 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '7': dec += 7 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '8': dec += 8 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case '9': dec += 9 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case 'A': dec += 10 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case 'B': dec += 11 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case 'C': dec += 12 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case 'D': dec += 13 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case 'E': dec += 14 * (long)Math.Pow(16, hex.Length - 1 - i); break;
                    case 'F': dec += 15 * (long)Math.Pow(16, hex.Length - 1 - i); break;

                }
            }
            return dec;
        }

        static char[] ConvertNumberToBin(long dec)
        {
            string output = string.Empty;
            while (dec != 0)
            {
                output += (char)((dec % 2) + 48);
                dec /= 2;
            }
            char[] bin = output.ToCharArray();
            Array.Reverse(bin);
            return bin;
        }

        static void Main(string[] args)
        {
            string hex = Console.ReadLine();
            char[] arr = ConvertNumberToBin(ConvertNumberToDec(hex));
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
    }
}
