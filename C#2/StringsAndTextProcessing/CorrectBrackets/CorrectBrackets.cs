using System;

namespace CorrectBrackets
{
    class CorrectBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int openBr = 0;
            int closeBr = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBr++;
                }
                else if (input[i] == ')')
                {
                    closeBr++;
                }
            }
            if (openBr == closeBr)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
