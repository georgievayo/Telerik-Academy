using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationProblem
{
    class Program
    {
        static int GetCodeOf(char letter)
        {
            switch (letter)
            {
                case 'a': return 0;
                case 'b': return 1;
                case 'c': return 2;
                case 'd': return 3;
                case 'e': return 4;
                case 'f': return 5;
                case 'g': return 6;
                case 'h': return 7;
                case 'i': return 8;
                case 'j': return 9;
                case 'k': return 10;
                case 'l': return 11;
                case 'm': return 12;
                case 'n': return 13;
                case 'o': return 14;
                case 'p': return 15;
                case 'q': return 16;
                case 'r': return 17;
                case 's': return 18;
                case 't': return 19;
                case 'u': return 20;
                case 'v': return 21;
                case 'w': return 22;
                default: return -1;
            }
        }

        static string Convert(long number)
        {
            string num = string.Empty;

            do
            {
                if (number % 19 > 9)
                {
                    switch (number % 19)
                    {
                        case 10: num += 'a'; ; break;
                        case 11: num += 'b'; break;
                        case 12: num += 'c'; break;
                        case 13: num += 'd'; break;
                        case 14: num += 'e'; break;
                        case 15: num += 'f'; break;
                        case 16: num += 'g'; break;
                        case 17: num += 'h'; break;
                        case 18: num += 'i'; break;
                    }

                }
                else
                {
                    num += (char)((number % 19) + 48);
                }
                number /= 19;

            } while (number != 0);
            return num;
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long sum = 0;

            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    sum += GetCodeOf(item[i]) * (long)Math.Pow(23, item.Length - 1 - i);
                }
                
            }
            Console.WriteLine("{0} = {1}", Convert(sum), sum);
        }
    }
}
