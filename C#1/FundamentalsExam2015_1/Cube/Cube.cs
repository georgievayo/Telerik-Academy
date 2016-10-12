using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    class Cube
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2*n - 1; i++)
            {
                for (int j = 0; j < 2*n - 1; j++)
                {
                    if(i == 0 && j >= n - 1 ||
                       i == n - 1 && j <= n-1 ||
                       i == 2 * n - 2 && j <= n - 1 ||
                       j == 0 && i > n-1 ||
                       j == n - 1 && i > n - 1 ||
                       j == 2 * n - 2 && i <= n - 1 ||
                       i + j == n - 1 && i < n - 1 && j < n - 1 ||
                       i + j == 3*n-3 && i >= n-1 && j >= n-1 ||
                       i + j == 2 * n - 2 && i <= n - 1 && j > n - 1)
                    {
                        Console.Write(':');
                    }
                    else if (i + j < 2 * n - 2 && i + j > n - 1 && i < n - 1)
                    {
                        Console.Write('/');
                    }
                    else if (i + j <= 3 * n - 3 && i + j > 2 * n - 2 && j > n - 1)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
