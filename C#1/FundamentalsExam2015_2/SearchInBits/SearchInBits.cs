using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SearchInBits
{
    class SearchInBits
    {
        static void Main(string[] args)
        {
            byte s = byte.Parse(Console.ReadLine());
            string sToStr = Convert.ToString(s, 2).PadLeft(4, '0');
            byte n = byte.Parse(Console.ReadLine());
            int counter = 0;
            for (byte i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                for (int k = 0; k < 27; k++)
                {
                    int mask = (number >> k) ^ s;
                    string maskToStr = Convert.ToString(mask, 2).PadLeft(sToStr.Length, '0');
                    bool isEqual = true;
                    for (int j = maskToStr.Length - 1; j >= maskToStr.Length - sToStr.Length; j--)
                    {
                        if (maskToStr[j] == '1')
                        {
                            isEqual = false;
                        }
                    }
                    if (isEqual == true)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
