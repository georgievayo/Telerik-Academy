using System;

namespace OneSystemToAnyOther
{
    class OneSystemToAnyOther
    {
        static long ConvertToDecimal(string number, int s)
        {
            long dec = 0;
            for (int i = 0; i < number.Length; i++)
            {
                switch (number[i])
                {
                    case '0': dec += 0 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '1': dec += 1 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '2': dec += 2 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '3': dec += 3 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '4': dec += 4 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '5': dec += 5 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '6': dec += 6 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '7': dec += 7 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '8': dec += 8 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case '9': dec += 9 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'A': dec += 10 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'B': dec += 11 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'C': dec += 12 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'D': dec += 13 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'E': dec += 14 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'F': dec += 15 * (long)Math.Pow(s, number.Length - 1 - i); break;
                }
            }
            return dec;
        }

        static string Convert(long number, int d)
        {
            string hex = string.Empty;

            do
            {
                if (number % d > 9)
                {
                    switch (number % d)
                    {
                        case 10: hex += 'A'; break;
                        case 11: hex += 'B'; break;
                        case 12: hex += 'C'; break;
                        case 13: hex += 'D'; break;
                        case 14: hex += 'E'; break;
                        case 15: hex += 'F'; break;

                    }

                }
                else
                {
                    hex += (char)((number % d) + 48);
                }
                number /= d;

            } while (number != 0);

            return hex;
        }
        static string ConvertNumber(string number, int s, int d)
        {
            return Convert(ConvertToDecimal(number, s), d);
        }
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            string n = Console.ReadLine();
            int d = int.Parse(Console.ReadLine());
            
            if (d == 10)
            {
                Console.WriteLine(ConvertToDecimal(n,s));
            }
            else if (s == d)
            {
                Console.WriteLine(n);
            }

            else
            {
                string output = ConvertNumber(n, s, d);
                for (int i = output.Length - 1; i >= 0; --i)
                {
                    Console.Write(output[i]);
                }
                Console.WriteLine();
            }
            
            
        }
    }
}
