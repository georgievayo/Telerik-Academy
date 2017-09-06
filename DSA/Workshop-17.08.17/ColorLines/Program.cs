using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] board = new char[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    board[i, j] = line[j];
                }
            }
            int count = 0;

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    if (board[i, j] == 'R')
                    {
                        var index = j;
                        while (index < size[1] && (board[i, index] == 'R' || board[i,index] == 'G'))
                        {
                            if (index < size[1] && board[i, index] == 'G')
                            {
                                board[i, index] = 'B';
                            }
                            else if (index < size[1] && board[i, index] == 'R')
                            {
                                board[i, index] = '.';
                            }
                            index++;
                            
                        }

                        while (j < size[1] && (board[i, j] == 'R' || board[i, j] == 'G'))
                        {
                            if (j < size[1] && board[i, j] == 'G')
                            {
                                board[i, j] = 'B';
                            }
                            else if (j < size[1] && board[i, j] == 'R')
                            {
                                board[i, j] = '.';
                            }
                            j++;

                        }

                        count++;
                    }  
                }
            }

            Print(board);

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    if (board[i, j] == 'B')
                    {
                        int index = i;

                        while (index < size[0] && board[i, j] == 'B')
                        {
                            if (index < size[0])
                            {
                                board[i, j] = '.';
                            }
                            index++;
                        }

                        count++;
                    }
                }
            }
            Print(board);


            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    if (board[i, j] == 'G')
                    {
                        count+=2;
                    }
                }
            }

            Console.WriteLine(count);
        }

        static void Print(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                    
                }
                Console.WriteLine();
            }
        }
        static void CheckAroundGreen(ref char[,] board, int i, int j)
        {
            // Down
            for (int k = i + 1; k < board.GetLength(0); k++)
            {
                if (board[k, j] == 'B')
                {
                    board[k, j] = '.';
                }
                else
                {
                    break;
                }
            }

            // Up
            for (int k = i - 1; k >= 0; --k)
            {
                if (board[k, j] == 'B')
                {
                    board[k, j] = '.';
                }
                else
                {
                    break;
                }
            }

            // Right
            for (int k = j + 1; k < board.GetLength(1); k++)
            {
                if (board[i, k] == 'R')
                {
                    board[i, k] = '.';
                }
                else
                {
                    break;
                }
            }

            // Left
            for (int k = j - 1; k >= 0; --k)
            {
                if (board[i, k] == 'R')
                {
                    board[i, k] = '.';
                }
                else
                {
                    break;
                }
            }
        }
    }
}
