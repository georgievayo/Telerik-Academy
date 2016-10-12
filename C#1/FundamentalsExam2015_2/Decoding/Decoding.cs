using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoding
{
    class Decoding
    {
        static void Main(string[] args)
        {
            byte salt = byte.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            double encode = 0;
            for (int i = 0; i < text.Length; i++)
            {
                
                if(text[i]=='@')
                {
                    return;
                }
                else if (((int)text[i] >= 65 && (int)text[i] <= 90)||((int)text[i] >= 97 && (int)text[i] <= 122))
                {
                    encode = (int)text[i] * salt + 1000;
                }
                else if ((int)text[i] >= 48 && (int)text[i] <= 57)
                {
                    encode = (int)text[i] + salt + 500;
                }
                else 
                {
                   encode = (int)text[i] - salt;
                }
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", (double)(encode / 100));
                }
                else
                {
                    Console.WriteLine(encode * 100);
                }
            }
        }
    }
}
