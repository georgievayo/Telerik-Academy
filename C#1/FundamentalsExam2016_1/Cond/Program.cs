using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond
{
    class Program
    {
        static void Main(string[] args)
        {
            uint p = uint.Parse(Console.ReadLine());

            string pToStr = Convert.ToString(p, 2);
            Console.WriteLine("pToStr = " + pToStr);

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                uint n = uint.Parse(Console.ReadLine());
                uint newNumber = n;
                string nToStr = Convert.ToString(n, 2);
                Console.WriteLine(pToStr);
                Console.WriteLine(nToStr);
                for (int j = 0; j <= nToStr.Length - 1; j++)
                {
                    uint mask = p ^ newNumber;
                    string maskToStr = Convert.ToString(n, 2);
                    Console.WriteLine(maskToStr);
                    bool isEqual = true;
                    for (int k = maskToStr.Length - 1; k <= maskToStr.Length - pToStr.Length; k--)
                    {
                        if (maskToStr[k] == '1')
                        {
                            isEqual = false;
                        }
                    }
                    Console.WriteLine(isEqual);
                    if (isEqual)
                    {
                        newNumber = n;
                        n = n >> 1;
                        Console.WriteLine("n>>1: " + Convert.ToString(n,2));
                    }
                    else
                    {
                        newNumber = (n >> pToStr.Length) << pToStr.Length;
                        n = n >> pToStr.Length;
                        Console.WriteLine("n>>number: " + Convert.ToString(n, 2));
                    }
                  
                }
                
            }
        }
    }
}
