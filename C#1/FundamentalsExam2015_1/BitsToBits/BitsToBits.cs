using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsToBits
{
    class BitsToBits
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            string concatenation = "";
            for (byte i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                concatenation += Convert.ToString(number, 2).PadLeft(30, '0');
            }
            int countZeroes = 1, countOnes = 1;
            int curSeqStart = 0;
            for (int i = 1; i < concatenation.Length; i++)
            {
                if (concatenation[i] != concatenation[curSeqStart])
                {
                    curSeqStart = i;
                }
                else if (concatenation[i] == '0' && i - curSeqStart + 1 > countZeroes)
                {
                    countZeroes = i - curSeqStart + 1;
                }
                else if (concatenation[i] == '1' && i - curSeqStart + 1 > countOnes)
                {
                    countOnes = i - curSeqStart + 1;
                }
            }
            Console.WriteLine(countZeroes);
            Console.WriteLine(countOnes);
           
        }
    }
}
