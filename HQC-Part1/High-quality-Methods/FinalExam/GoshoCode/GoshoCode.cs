using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshoCode
{
    class GoshoCode
    {
        static void Main(string[] args)
        {
            // Get initial data
            string keyword = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            string text = string.Empty;
            for (int i = 0; i < rows; i++)
            {
                text += Console.ReadLine();
                text += " ";
            }

            // Separate sentences
            string[] sentences = text.Split('.', '!');

            int sum = 0;
            int currentPosInText = -1;
            for (int i = 0; i < sentences.Length; i++)
            {
                currentPosInText += sentences[i].Length + 1;
                int indexOfWord = sentences[i].IndexOf(keyword);

                // If the word has been found and the sentence is statement
                if (indexOfWord > -1 && text[currentPosInText] == '.')
                {
                    // Get sum of characters in sentence after keyword
                    for (int j = indexOfWord + keyword.Length + 1; j < sentences[i].Length; j++)
                    {
                        // Ignore whitespaces
                        if (sentences[i][j] != ' ')
                        {
                            int code = (int)sentences[i][j] * keyword.Length;
                            sum += code;
                        }
                    }
                }
                // If the word has been found and the sentence is exclamation 
                else if (indexOfWord > -1 && text[currentPosInText] == '!')
                {
                    // Get sum of characters in sentence before keyword
                    for (int j = 0; j < indexOfWord; j++)
                    {
                        if (sentences[i][j] != ' ')
                        {
                            int code = (int)sentences[i][j] * keyword.Length;
                            sum += code;
                        }
                    }
                }
            }


            Console.WriteLine(sum);
        }
    }
}
