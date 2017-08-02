using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockAndTheValidString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(isValid(str) ? "YES" : "NO");
        }

        private static SortedList<char, int> freq = new SortedList<char, int>();


        private static void FillFrequencies(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!freq.ContainsKey(str[i]))
                {
                    freq.Add(str[i], 1);
                }
                else
                {
                    freq[str[i]]++;
                }
            }
        }

        static bool isValid(string str)
        {
            FillFrequencies(str);
            int count = freq.First().Value;
            bool isTheOnlyOne = false;
            foreach (var element in freq)
            {
                if (element.Value != count)
                {
                    if (element.Value == count + 1 || element.Value + 1 == count)
                    {
                        if (isTheOnlyOne)
                        {
                            return false;
                        }
                        else
                        {
                            isTheOnlyOne = true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
