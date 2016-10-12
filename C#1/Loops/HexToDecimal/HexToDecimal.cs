using System;

class HexToDecimal
{
    static void Main()
    {
        string hex = Console.ReadLine();
        long number = 0;
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            switch (hex[i])
            {
                case '0': number += (long)(0 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '1': number += (long)(1 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '2': number += (long)(2 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '3': number += (long)(3 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '4': number += (long)(4 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '5': number += (long)(5 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '6': number += (long)(6 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '7': number += (long)(7 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '8': number += (long)(8 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case '9': number += (long)(9 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case 'A': number += (long)(10 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case 'B': number += (long)(11 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case 'C': number += (long)(12 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case 'D': number += (long)(13 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case 'E': number += (long)(14 * Math.Pow(16, (hex.Length - 1 - i))); break;
                case 'F': number += (long)(15 * Math.Pow(16, (hex.Length - 1 - i))); break;
            }
        }
        Console.WriteLine("{0}", number);
    }
}

