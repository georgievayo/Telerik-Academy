using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Sub_stringInText
{
    class Program
    {
        static void Main()
        {
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int counter = 0;

            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if (string.Equals(text.Substring(i, pattern.Length), pattern))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
