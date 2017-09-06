using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int length = text.Length;
            Console.WriteLine(GetNumForPalindrome(text));

        }
        static int GetNumForPalindrome(string str)
        {
            int count = 0;
            for (int start = 0, end = str.Length - 1; start < end; ++start)
            {
                if (str[start] != str[end])
                    ++count;
                else --end;
            }
            return count;
        }
        //static void Main(string[] args)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine(GetNumForPalindrome(Console.ReadLine()).ToString());

        //    }

        //}
        static int[] PreComputeKMP(string str)
        {
            var failLink = new int[str.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;
            for (int i = 1; i < str.Length; ++i)
            {
                int j = failLink[i];
                while (j >= 0 && str[i] != str[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            return failLink;
        }
    }

}
