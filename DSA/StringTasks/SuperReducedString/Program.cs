using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperReducedString
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            string result = Remove(text);
            Console.WriteLine(result.Length > 0 ? result.ToString() : "Empty string");
        }

        static string Remove(StringBuilder result)
        {
            int n = result.Length;

            for (int i = 0; i < result.Length - 1; i++)
            {
                if (result[i] == result[i + 1])
                {
                    result.Remove(i, 2);
                    if (i > 0)
                    {
                        i -= 2;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                if (result.Length == 0)
                {
                    return "";
                }
            }

            if (result[result.Length - 2] == result[result.Length - 1])
            {
                result.Remove(result.Length - 2, 2);
            }

            return result.ToString();
        }
    }
}
