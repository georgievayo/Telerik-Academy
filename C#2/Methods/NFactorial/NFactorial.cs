using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NFactorial
{
    class NFactorial
    {
        static double Multiply(int[] digits, int number)
        {
            double num = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                num += Math.Pow(10, digits.Length - i - 1) * digits[i];
            }
            return number * num;
        }
        static void Main(string[] args)
        {
            BigInteger product = 1;
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                for (BigInteger i = 1; i <= n; i++)
                {
                    product *= i;
                }
                Console.WriteLine(product);
            }  
        }
    }
}
