using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToNumber
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int result = 0;
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i]=='@')
                {
                    Console.WriteLine(result);
                    return;
                }
                else if((int)input[i]>=48 && (int)input[i]<=57)
                {
                    result = result * (input[i] - '0');
                }
                else if((int)input[i]>=65 && (int)input[i]<=90)
                {
                    result += (int)input[i]%65;
                }
                else if((int)input[i]>=97 && (int)input[i]<=122)
                {
                    result += (int)input[i]%97;
                }
                else
                {
                    result = result % m;
                }
            }
            Console.WriteLine(result);
        }
    }
}
