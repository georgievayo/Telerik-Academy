using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            var patterns = GeneratePrefixesAndSufixes(word);
            int count = 0;
            int currentPrefix = 0;
            int currentSuffix = 0;
            for (int p = 0; p < patterns.Count; p++)
            {
                
                var failLink = PreComputeKMP(patterns[p]);
                int j = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    while (j >= 0 && patterns[p][j] != text[i])
                    {
                        j = failLink[j];
                    }

                    ++j;
                    if (j == patterns[p].Length)
                    {
                        if (p == 0)
                        {
                            count++;
                        }
                        else if (p > 0 && p % 2 == 1)
                        {
                            currentPrefix++;
                        }
                        else if (p > 0 && p % 2 == 0)
                        {
                            currentSuffix++;
                        }
                        j = failLink[j];
                    }
                }

                if (p != 0 && p % 2 == 0)
                {
                    count += currentPrefix * currentSuffix;
                    currentSuffix = 0;
                    currentPrefix = 0;
                }
            }
            Console.WriteLine(count);
           
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

        static List<string> GeneratePrefixesAndSufixes(string word)
        {
            List<string> found = new List<string>() {word};
           
            for (int i = 0; i < word.Length - 1; i++)
            {
                string prefix = word.Substring(0, i + 1);
                string suffix = word.Substring(i + 1, word.Length - i - 1);
                found.Add(prefix);
                found.Add(suffix);
            }

            return found;
        }
    }
}
