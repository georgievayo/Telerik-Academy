using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianRugs
{
    class PersianRugs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 2*n; i++)
            {
                for (int j = 0; j <= 2*n; j++)
                {
                    if(i == j && i != n ||
                       j - i == d + 1 && j <= n - 1 && d < n - 1 ||
                       i - j == d + 1 && j >= n +1 && d < n - 1)
                    {
                        Console.Write('\\');
                    }
                    else if (i + j == 2 * n && i != n ||
                             i + j == 2 * n - d - 1 && j >= n + 1 && d < n - 1 ||
                             i + j == 2 * n + d + 1 && j <= n - 1 && d < n - 1)
                    {
                        Console.Write('/');
                    }
                    else if (i + j < 2 * n - d - 1 && j <= 2 * n - d && j - i > d + 1 && j >= d + 1 ||
                             i + j > 2 * n + d + 1 && j <= 2 * n - d && i - j > d + 1 && j >= d + 1)
                    {
                        Console.Write('.');
                    }
                    else if(i==n && j==n)
                    {
                        Console.Write('X');
                    }
                    else if (i < j && i + j > 2 * n ||
                             i > j && i + j < 2 * n)
                    {
                        Console.Write('#');
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
