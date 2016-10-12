using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman1
{
    class Batman
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char space = ' ';
            char symbol = char.Parse(Console.ReadLine());
            for (int i = 0; i < n/2 + n/2 + n/3; i++)
            {
                for (int j = 0; j < 3*n; j++)
                {
                    if(i == 0 && j < n || 
                       i == 0 && j >= 2*n ||
                       i <= j && i <= n / 2 - 1 && j < n ||
                       i + j <= 3*n - 1 && j >= 2 * n && i <= n / 2 - 1||
                       i >= n/2 && i < n/2+n/3 && j>=n/2 && j <= 3*n - 1 - n/2 ||
                       i == n / 2 - 1 && (j == 3*n/2 - 1 ||j == 3*n/2 + 1) ||
                       i >= n / 2 + n / 3 && j >= n + 1 && j < 2 * n - 1 && j - i >= 3 * n / 2 - (n / 2 + n / 2 + n / 3 - 1) && i + j <= (3 * n) / 2 + n / 2 + n / 2 + n / 3 - 1)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(space);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
