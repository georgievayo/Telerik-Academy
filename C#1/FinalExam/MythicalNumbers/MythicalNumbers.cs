using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicalNumbers
{
    class MythicalNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int thirdDigit = number % 10;
            int secondDigit = (number / 10) % 10;
            int firstDigit = number / 100;
            double result = 0;
            if (thirdDigit == 0)
            {
                result = firstDigit * (double)secondDigit;
            }
            else if (thirdDigit > 0 && thirdDigit <= 5)
            {
                result = (firstDigit * secondDigit) / (double)thirdDigit;
            }
            else if (thirdDigit > 5)
            {
                result = (firstDigit + secondDigit) * (double)thirdDigit;
            }
            Console.WriteLine("{0:F2}", result);
        }
    }
}
