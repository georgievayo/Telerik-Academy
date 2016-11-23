using System;

namespace DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        static string Convert(long number)
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
            long n = long.Parse(Console.ReadLine());
            string hex = Convert(n);
            for (int i = hex.Length - 1; i >= 0; --i)
            {
                Console.Write(hex[i]);
            }
            Console.WriteLine();
        }
    }
}
