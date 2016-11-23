using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstDigitOfSecondNum;
            int secondDigitOfFirstNum;
            int subtract;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n - 1; i++)
            {
                secondDigitOfFirstNum = arr[i]%10;
                firstDigitOfSecondNum = arr[i+1]/10;
                Console.Write("{0} ", secondDigitOfFirstNum * firstDigitOfSecondNum);   
            }
            Console.WriteLine();
            for (int i = 0; i < n - 1; i++)
            {
                subtract = arr[i] - arr[i + 1];
                if (subtract < 0)
                {
                    Console.Write("{0} ", -subtract);
                }
                else if (subtract >= 0)
                {
                    Console.Write("{0} ", subtract);
                }
                
            }
        }
    }
}
