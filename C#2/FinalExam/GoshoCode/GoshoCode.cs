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
            string word = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            string text = string.Empty;

            for (int i = 0; i < rows; i++)
            {
                text += Console.ReadLine();
                text += " ";
            }

            string[] sentences = text.Split('.', '!');
            //int index = 0;
            //char[] marks = new char[sentences.Length];
            //for (int i = 0; i < text.Length; i++)
            //{
            //    if (text[i] == '.' || text[i] == '!')
            //    {
            //        marks[index] = text[i];
            //        index++;
            //    }

            //}

            int sum = 0;
            int currentPos = -1;
            for (int i = 0; i < sentences.Length; i++)
            {
                currentPos += sentences[i].Length + 1;
                int indexOf = sentences[i].IndexOf(word);
                if (indexOf > -1 && text[currentPos] == '.')
                {
                    for (int j = indexOf + word.Length + 1; j < sentences[i].Length; j++)
                    {
                        if (sentences[i][j] != ' ')
                        {
                            sum += (int)sentences[i][j] * word.Length;
                        }
                    }
                }
                else if (indexOf > -1 && text[currentPos] == '!')
                {
                    for (int j = 0; j < indexOf; j++)
                    {
                        if (sentences[i][j] != ' ')
                        {
                            sum += (int)sentences[i][j] * word.Length;
                        }
                    }
                }
            }


            Console.WriteLine(sum);


        }
    }
}
