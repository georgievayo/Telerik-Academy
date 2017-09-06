using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = pattern + pattern;
            int length = text.Length;
            int count = 0;

                var failLink = PreComputeKMP(pattern);

                int j = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    while (j >= 0 && pattern[j] != text[i])
                    {
                        j = failLink[j];
                    }

                    ++j;
                    if (j == pattern.Length)
                    {
                        count++;
                        j = failLink[j];
                    }
                }
            int index = 0;
            for (int i = 0; i < failLink.Length; i++)
            {
                if (failLink[i] > 0)
                {
                    index = i - 1;
                    break;
                }
            }
            Console.WriteLine(text.Substring(0, index));

        }

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
