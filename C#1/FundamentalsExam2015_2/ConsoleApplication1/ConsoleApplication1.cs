using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication1
{
    class ConsoleApplication1
    {
        static BigInteger Calculate(string n)
        {
            BigInteger product = 1;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] != '0')
                {
                    product *= (n[i] - '0');
                }
                else if (n[i] == '0' && n.Length == 1)
                {
                    product = 1;
                }
                //Console.WriteLine("product = " + product);
            }
            return product;
        }
        static void Main(string[] args)
        {
            string n;
            int counter = -1;
            BigInteger product = 1, firstProduct = 1;
            do
            {
                n = Console.ReadLine();
                if(n != "END")
                {
                    counter++;
                    if (counter < 10 && counter % 2 != 0)
                    {
                        product *= Calculate(n);
                    }

                    else if (counter >= 10 && counter % 2 != 0)
                    {
                        firstProduct = product;
                        product = 1;
                        product *= Calculate(n);
                    }
                }
                else if(n == "END")
                {
                    if(counter>=10)
                    {
                        Console.WriteLine(firstProduct);
                    }
                    Console.WriteLine(product);
                }
                
                //Console.WriteLine("all = " + product);
            } while (n != "END");
        }
    }
}
