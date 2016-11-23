using System;

namespace BinaryToHexadecimal
{
    class BinaryToHexadecimal
    {
        static long ConvertNumberToDecimal(string bin)
        {
            long dec = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == '1')
                {
                    dec += (bin[i] - '0') * (long)Math.Pow(2, bin.Length - 1 - i);
                }
            }
            return dec;
        }

        static string ConvertNumberToHexadecimal(long number)
        {
            string hex = string.Empty;

            do
            {
                if (number % 16 > 9)
                {
                    switch (number % 16)
                    {
                        case 10: hex += 'A'; ; break;
                        case 11: hex += 'B'; break;
                        case 12: hex += 'C'; break;
                        case 13: hex += 'D'; break;
                        case 14: hex += 'E'; break;
                        case 15: hex += 'F'; break;
                    }

                }
                else
                {
                    hex += (char)((number % 16) + 48);
                }
                number /= 16;

            } while (number != 0);

            return hex;
        }
        static void Main(string[] args)
        {
            string bin = Console.ReadLine();
            string hex = ConvertNumberToHexadecimal(ConvertNumberToDecimal(bin));
            for (int i = hex.Length - 1; i >= 0; --i)
            {
                Console.Write(hex[i]);
            }
            Console.WriteLine();
        }
    }
}
