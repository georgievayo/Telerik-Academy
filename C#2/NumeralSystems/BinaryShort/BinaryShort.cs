using System;

namespace BinaryShort
{
    class BinaryShort
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16,'0'));
        }
    }
}
