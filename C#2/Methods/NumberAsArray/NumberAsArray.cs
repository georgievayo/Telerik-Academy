using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberAsArray
{
    class NumberAsArray
    {
        static int[] FindSum(int[] num1, int[] num2)
        {
            int[] result = new int[Math.Max(num1.Length, num2.Length)];
            for (int i = 0; i < Math.Max(num1.Length, num2.Length); i++)
            {
                
            }

        }

        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(' ');
            int size1 = Convert.ToInt32(sizes[0]);
            int size2 = Convert.ToInt32(sizes[1]);

            int[] number1 = new int[size1];
            int[] number2 = new int[size2];

            string[] input1 = Console.ReadLine().Split(' ');
            string[] input2 = Console.ReadLine().Split(' ');

            for (int i = 0; i < size1; i++)
            {
                number1[i] = Convert.ToInt32(input1[i]);
            }
            for (int j = 0; j < size2; j++)
            {
                number2[j] = Convert.ToInt32(input2[j]);
            }


            BigInteger sum = FindSum(number1, number2);

            while(sum != 0)
            {
                Console.Write("{0} ", sum%10);
                sum /= 10;
            }
        }
    }
}
