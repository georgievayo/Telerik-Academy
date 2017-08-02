using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBase
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] numbersCount = new int[n + 1];
            numbersCount[1] = k - 1;
            numbersCount[2] = k * (k - 1);

            for (int i = 3; i < n + 1; i++)
            {
                numbersCount[i] = (k - 1) * numbersCount[i - 1] + (k - 1) * numbersCount[i - 2];
            }
            Console.WriteLine(numbersCount[n]);
        }
    }
}
