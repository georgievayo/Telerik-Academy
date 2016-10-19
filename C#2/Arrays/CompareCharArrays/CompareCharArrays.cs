using System;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string firstArray = Console.ReadLine();
            string secondArray = Console.ReadLine();
            int result = string.Compare(firstArray, secondArray, true);
            if (result == -1)
            {
                Console.WriteLine("<");
            }
            else if (result == 0)
            {
                Console.WriteLine("=");
            }
            else if (result == 1)
            {
                Console.WriteLine(">");
            }
        }
    }
}
