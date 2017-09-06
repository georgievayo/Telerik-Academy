using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Beers
    {
        private static int[,] board;
        private const int NORMAL_TIME = 1;
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = sizes[0];
            int m = sizes[1];
            int b = sizes[2];
            board = new int[n, m];

            for (int i = 0; i < b; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                board[line[0], line[1]] = -4;
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (i == 0 && j == 0)
                    {
                        board[i, j] = 0;
                        continue;
                    }

                    if (board[i, j] == 0)
                    {
                        board[i, j] = NORMAL_TIME;
                    }

                    if (i == 0)
                    {
                        board[i, j] += board[i, j - 1];
                    }
                    else if (j == 0)
                    {
                        board[i, j] += board[i - 1, j];
                    }
                    else if (i == n)
                    {
                        board[i, j] += Math.Min(board[i - 1, j], board[i, j - 1]);
                    }
                    else if (j == m)
                    {
                        board[i, j] += Math.Min(board[i - 1, j], board[i, j - 1]);
                    }
                    else
                    {
                        board[i, j] += Math.Min(board[i - 1, j], board[i, j - 1]);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(" {0}", board[i, j]);
                }
                Console.WriteLine();
            }

            var answer = board[n - 1, m - 1];
            Console.WriteLine(answer);
        }
    }
}
