using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            char[,] dp = new char[n, m];
            int count = 0;
            FindCombinations(dp, 0, 0, n, m, ref count);
            Console.WriteLine(count);
        }

        static void FindCombinations(char[,] dp, int i, int j, int n, int m, ref int cout)
        {
            while (i < n)
            {
                while (j < m)
                {
                    if ((j - 1 >= 0 ? dp[i, j - 1] == 'b' : false) || (i - 1 >= 0 ? dp[i - 1, j] == 'b' : false))
                    {
                        dp[i, j] = 'w';
                        if (j + 1 < m)
                        {
                            FindCombinations(dp, i, j + 1, n, m, ref cout);
                        }
                        else if (i + 1 < n)
                        {
                            FindCombinations(dp, i + 1, 0, n, m, ref cout);
                        }
                        else
                        {
                            cout++;
                            //Print(dp);

                            return;
                        }
                        return;

                    }
                    else
                    {
                        dp[i, j] = 'b';
                        if (j + 1 < m)
                        {
                            FindCombinations(dp, i, j + 1, n, m, ref cout);
                        }
                        else if (i + 1 < n)
                        {
                            FindCombinations(dp, i + 1, 0, n, m, ref cout);
                        }
                        else
                        {
                            cout++;
                            //Print(dp);


                        }

                        dp[i, j] = 'w';
                        if (j + 1 < m)
                        {
                            FindCombinations(dp, i, j + 1, n, m, ref cout);
                        }
                        else if (i + 1 < n)
                        {
                            FindCombinations(dp, i + 1, 0, n, m, ref cout);
                        }
                        else
                        {
                            cout++;
                            //Print(dp);
                            return;
                        }
                        return;
                    }
                }
            }
        }

        static void Print(char[,] dp)
        {
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write(dp[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
