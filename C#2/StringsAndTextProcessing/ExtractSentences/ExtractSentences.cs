using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            char symbol = ' ';

            //word = word.PadRight(word.Length + 1, symbol);

            string[] sentences = text.Split('.');

            foreach(var sentence in sentences)
            {
                
                for (int j = 0; j < sentence.Length; j++)
                {
                    if (!char.IsLetterOrDigit(sentence[j]))
                    {
                        symbol = sentence[j];
                        break;
                    }
                }
                if (sentence.ToLower().Contains(word.ToLower().PadLeft(word.Length+ 1, symbol).PadRight(word.Length + 2, symbol)))
                {
                    Console.Write("{0} ", sentence.PadRight(sentence.Length + 1, '.').TrimStart(' '));
                }
            }
        }
    }
}