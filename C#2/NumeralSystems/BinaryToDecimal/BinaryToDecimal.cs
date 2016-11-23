using System;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        static long ConvertNumber(string bin)
        {
            long dec = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i]=='1')
                {
                    dec += (bin[i] - '0') * (long)Math.Pow(2, bin.Length - 1 - i);
                } 
            }
            return dec;
        }
        static void Main(string[] args)
        {
            string bin = Console.ReadLine();
            Console.WriteLine(ConvertNumber(bin));
        }
    }
}
