using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SecretNumeralSystem
{
    class SecretNumeralSystem
    {
        static string[] systemNumbers = { "hristo", "tosho", "pesho", "hristofor", "vlad", "haralampi", "zoro", "vladimir" };

        static string DecodeNumber(string number)
        {
            string numAsStr = string.Empty;
            int zeroIndex = 0;
            int i = 7;
            while (number != "")
            {
                if (number.IndexOf(systemNumbers[i]) == zeroIndex && number != string.Empty)
                {
                    numAsStr += i.ToString();
                    number = number.Remove(0, systemNumbers[i].Length);
                    i = 8;
                }
                if (i == 0)
                {
                    i = 7;
                }
                else
                {
                    i--;
                }

            }

            return numAsStr;
        }

        static long ConvertToDecimal(string number)
        {
            long dec = 0;
            for (int i = 0; i < number.Length; i++)
            {
                dec += (number[i] - '0') * (long)Math.Pow(8, number.Length - 1 - i);
            }

            return dec;
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(',');

            BigInteger product = 1;
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].TrimStart(' ');
                product *= ConvertToDecimal(DecodeNumber(input[i]));
            }

            Console.WriteLine(product);
        }
    }
}
