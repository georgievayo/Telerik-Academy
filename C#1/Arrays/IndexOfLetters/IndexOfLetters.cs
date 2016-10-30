using System;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main()
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string input = Console.ReadLine();
            
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (alphabet[j] == input[i])
                    {
                        Console.WriteLine(j);
                    }
                } 
            }
            
        }
    }
}
