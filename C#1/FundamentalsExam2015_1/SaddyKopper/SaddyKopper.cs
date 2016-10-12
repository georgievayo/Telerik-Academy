using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SaddyKopper
{
    class SaddyKopper
    {
        static string Calculate(string n)
        {
            BigInteger product = 1;
            while (n.Length > 1)
            {
                int sum = 0;
                n = n.Remove(n.Length - 1);
                for (int i = 0; i < n.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += (n[i] - '0');
                    }
                }
                product = product * sum;
            }
            n = Convert.ToString(product);
            return n;
        }
        static void Main(string[] args)
        {
            int counter = 0;
            string n = Console.ReadLine();
            while (n.Length > 1)
            {
                n = Calculate(n);
                counter++;
                if (counter == 10)
                {
                    Console.WriteLine(n);
                    break;
                }
            }
            if (counter < 10)
            {
                Console.WriteLine(counter);
                Console.WriteLine(n);
            }
            
        }
    }
}

