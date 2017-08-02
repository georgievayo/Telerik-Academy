using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyString
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                string str = Console.ReadLine();
                Console.WriteLine(isFunny(str) ? "Funny" : "Not Funny");
            }
        }

        static bool isFunny(string str)
        {
            int n = str.Length;
            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(str[i] - str[i - 1]) != Math.Abs(str[n - 1 - i] - str[n - i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
