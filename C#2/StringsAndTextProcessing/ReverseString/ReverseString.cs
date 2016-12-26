using System;

namespace ReverseString
{
    class ReverseString
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            char[] arr = new char[input.Length];
            arr = input.ToCharArray();
            Array.Reverse(arr);
            string s = new string(arr);
            Console.WriteLine(s);
        }
    }
}
