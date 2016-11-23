using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
    class ReverseNumber
    {
        static string ReversingNumber(string number)
        {
            string rev = "";
            for (int i = 0; i < number.Length; i++)
            {
                rev += number[number.Length - 1 - i];
            }
            return rev;
        }

        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(ReversingNumber(number));
        }
    }
}
