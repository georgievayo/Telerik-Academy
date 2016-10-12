using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    class Batman
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            char[,] batman = new char[120, 3 * n];

            batman[(n - 2) / 2, (3 * n / 2) - 1] = batman[(n - 2) / 2, (3 * n / 2) + 1] = symbol;

            for (int i = 0; i < n / 2; i++)                   //ляво крило
            {
                for (int j = i; j < n / 2; j++)
                {
                    batman[i, j] = symbol;
                }
            }

            for (int i = 0; i < n / 2; i++)                   //дясно крило
            {
                for (int j = 3 * n - 1 - i; j > 3 * n - 1 - i - n / 2; j--)
                {
                    batman[i, j] = symbol;
                }
            }

            for (int i = n - 1; i > n - 1 - (n + 1) / 2; i--)               //ляв правоъгълник
            {
                for (int j = 0; j < n - 2; j++)
                {
                    batman[j, i] = symbol;
                }
            }
            for (int i = 2 * n; i < 2 * n + (n + 1) / 2; i++)                   //десен правоъгълник
            {
                for (int j = 0; j < n - 2; j++)
                {
                    batman[j, i] = symbol;
                }
            }
            for (int i = n / 2; i < n - 2; i++)             //централен правоъгълник
            {
                for (int j = n; j < 2 * n; j++)
                {
                    batman[i, j] = symbol;
                }
            }
            int p = n + 1, m = n - 3, counter = 0;
            for (int i = n - 2; i < n - 2 + (n - 1) / 2; i++)          //долен триъгълник
            {
                counter++;
                while (p <= n + 1 + m)
                {
                    batman[i, p] = symbol;
                    p++;
                }
                m = m - 1;
                p = n + 1 + counter;
            }

            for (int i = 0; i < n - 2 + (n - 1) / 2; i++)
            {
                for (int j = 0; j < 3 * n; j++)
                {
                        Console.Write("{0}", batman[i, j]); 
                }
                Console.WriteLine();
            }
        }
    }
}
