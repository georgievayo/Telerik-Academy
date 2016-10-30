using System;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            bool equal = true;
            int comparer = Math.Min(first.Length, second.Length);

            for (int i = 0; i < comparer; i++)
            {
                if (first[i] > second[i])
                {
                    Console.WriteLine(">");
                    equal = false;
                    break;
                }
                else if (first[i] < second[i])
                {
                    Console.WriteLine("<");
                    equal = false;
                    break;
                }
            }
            if (equal)
            {
                if (first.Length > second.Length)
                {
                    Console.WriteLine(">");
                }
                else if (first.Length < second.Length)
                {
                    Console.WriteLine("<");
                }
                else { Console.WriteLine("="); }

            }
        }
    }
}
