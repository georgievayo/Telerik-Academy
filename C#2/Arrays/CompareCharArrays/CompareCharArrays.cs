using System;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string firstArray = Console.ReadLine();
            string secondArray = Console.ReadLine();
            for (int i = 0; i < firstArray.Length; i++)
            {
                if ((int)firstArray[i] > (int)secondArray[i] || ((int)firstArray[i] == (int)secondArray[i] && i == firstArray.Length - 1 && firstArray.Length > secondArray.Length))
                {
                    Console.WriteLine(">");
                    break;
                }
                else if ((int)firstArray[i] < (int)secondArray[i])
                {
                    Console.WriteLine("<");
                    break;
                }
                else if ((int)firstArray[i] == (int)secondArray[i] && i == firstArray.Length - 1 && firstArray.Length == secondArray.Length)
                {
                    Console.WriteLine("=");
                }
            }
        }
    }
}
