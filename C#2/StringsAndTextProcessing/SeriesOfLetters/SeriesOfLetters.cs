using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            output = output.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i]!=output[output.Length - 1])
                {
                   output = output.Append(input[i]);
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
