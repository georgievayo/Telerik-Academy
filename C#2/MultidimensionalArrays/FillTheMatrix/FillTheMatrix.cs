using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char character = char.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int number = 1;
            if (character == 'a')
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        arr[j, i] = number;
                        number++;
                    }
                }
            }
            else if (character == 'b')
            {
                int ctr = 0;
                while (ctr != n)
                {
                    if (ctr % 2 == 0)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            arr[j, ctr] = number;
                            number++;
                        }
                    }
                    else
                    {
                        for (int j = n - 1; j >= 0; j--)
                        {
                            arr[j, ctr] = number;
                            number++;
                        }
                    }
                    ++ctr;
                }

            }
            else if (character == 'c')
            {
                int ctr = 1;
                int i = n - 1;
                int lastrow = i;
                int j = 0;

                //under diagonal
                while (lastrow >= 0 && j < n)
                {
                    i = lastrow;
                    while (i < n)
                    {
                        arr[i, j] = ctr;
                        ctr++;
                        i++;
                        j++;
                    }
                    --lastrow;
                    j = 0;
                }

                i = 0;
                j = 1;
                int lastCow = j;
                // above diagonal
                while (lastCow < n && i < n)
                {
                    j = lastCow;
                    while (j < n)
                    {
                        arr[i, j] = ctr;
                        ctr++;
                        i++;
                        j++;
                    }
                    ++lastCow;
                    i = 0;
                }

            }
            else if (character == 'd')
            {
                string direction = "down";
                int maxRotations = n * n;
                int num = 1;
                int row = 0;
                int col = 0;
                for (int i = 0; i < maxRotations; i++)
                {
                    if (direction == "down" && (row == n ||arr[row,col] != 0))
                    {
                        direction = "right";
                        col++;
                        row--;
                    }
                    if (direction == "up" && (row < 0 ||arr[row,col] != 0))
                    {
                        direction = "left";
                        --col;
                        row++;
                    }
                    if (direction == "right" && (col == n ||arr[row,col] != 0))
                    {
                        direction = "up";
                        --row;
                        col--;
                    }
                    if (direction == "left" && (col < 0||arr[row,col] != 0))
                    {
                        direction = "down";
                        row++;
                        col++;
                    }
                    arr[row, col] = num;
                    num++;

                    if (direction == "down")
                    {
                        row++;
                    }
                    if (direction == "up")
                    {
                        row--;
                    }
                    if (direction == "left")
                    {
                        col--;
                    }
                    if (direction == "right")
                    {
                        col++;
                    }

                    
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == n - 1)
                    {
                        Console.Write("{0}", arr[i, j]);
                    }
                    else
                    {
                        Console.Write("{0} ", arr[i, j]);
                    }
                   
                }
                Console.WriteLine();
            }
        }
    }
}
