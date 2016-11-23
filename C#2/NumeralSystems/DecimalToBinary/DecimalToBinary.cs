using System;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            string output = string.Empty;
           
            while(n != 0)
            {
                output += (char)((n % 2) + 48);
                n /= 2;
            }
            char[] arr = output.ToCharArray();
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
    }
}
