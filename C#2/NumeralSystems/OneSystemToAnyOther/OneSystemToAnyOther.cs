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
                    case 'G': dec += 16 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'H': dec += 17 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'I': dec += 18 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'J': dec += 19 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'K': dec += 20 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'L': dec += 21 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'M': dec += 22 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'N': dec += 23 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'O': dec += 24 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'P': dec += 25 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'Q': dec += 26 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'R': dec += 27 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'S': dec += 28 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'T': dec += 29 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'U': dec += 30 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'V': dec += 31 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'W': dec += 32 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'X': dec += 33 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'Y': dec += 34 * (long)Math.Pow(s, number.Length - 1 - i); break;
                    case 'Z': dec += 35 * (long)Math.Pow(s, number.Length - 1 - i); break;

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
                        case 16: hex += 'G'; break;
                        case 17: hex += 'H'; break;
                        case 18: hex += 'I'; break;
                        case 19: hex += 'J'; break;
                        case 20: hex += 'K'; break;
                        case 21: hex += 'L'; break;
                        case 22: hex += 'M'; break;
                        case 23: hex += 'N'; break;
                        case 24: hex += 'O'; break;
                        case 25: hex += 'P'; break;
                        case 26: hex += 'Q'; break;
                        case 27: hex += 'R'; break;
                        case 28: hex += 'S'; break;
                        case 29: hex += 'T'; break;
                        case 30: hex += 'U'; break;
                        case 31: hex += 'V'; break;
                        case 32: hex += 'W'; break;
                        case 33: hex += 'H'; break;
                        case 34: hex += 'W'; break;
                        case 35: hex += 'Z'; break;

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
            string output = ConvertNumber(n,s,d);
            for (int i = output.Length - 1; i >=0; --i)
            {
                Console.Write(output[i]);
            }
            Console.WriteLine();
        }
    }
}
