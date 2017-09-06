using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromize
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            int charsCount = findMinInsertions(input, 0, input.Length - 1);
            Console.WriteLine(charsCount);
        }

        static int findMinInsertions(char[] str, int l, int h)
        {
            if (l > h) return int.MaxValue;
            if (l == h) return 0;
            if (l == h - 1) return (str[l] == str[h]) ? 0 : 1;

            return (str[l] == str[h]) ?
                findMinInsertions(str, l + 1, h - 1) :
                (Math.Min(findMinInsertions(str, l, h - 1),
                     findMinInsertions(str, l + 1, h)) + 1);
        }

        static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
