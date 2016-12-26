using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BitShiftMatrix
{
    class Program
    {
        static string ChooseLeftOrRight(int col, int colNow)
        {
            if (col < colNow)
            {
                return "left";
            }
            else
            {
                return "right";
            }
        }

        static string ChooseUpOrDown(int row, int rowNow)
        {
            if (row < rowNow)
            {
                return "up";
            }
            else
            {
                return "down";
            }
        }
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int coef = Math.Max(r, c);
            int n = int.Parse(Console.ReadLine());
            int[] codes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BigInteger[,] matrix = new BigInteger[r, c];
            bool[,] isVisisted = new bool[r, c];
           

            for (int i = 0; i < c; i++)
            {
                matrix[r - 1, i] = (BigInteger)Math.Pow(2, i);
            }

            for (int j = 0; j < c; j++)
            {
                for (int i = r - 2; i >= 0; --i)
                {
                    matrix[i, j] = matrix[i + 1, j] * 2;
                }
            }



            int rowNow = r - 1;
            int colNow = 0;
            BigInteger sum = 0;

            for (int code = 0; code < 4; code++)
            {
                int row = codes[code] / coef;
                int col = codes[code] % coef;

                string direction = ChooseLeftOrRight(col, colNow);

                if (direction == "left")
                {
                    for (int i = colNow; i >= col; --i)
                    {
                        if (!isVisisted[rowNow, i])
                        {
                            sum += matrix[rowNow, i];
                            //Console.WriteLine("i={0} j={1}",rowNow,i);
                            isVisisted[rowNow, i] = true;
                        }
                    }// left
                    
                }
                else
                {
                    for (int j = colNow; j <= col; j++)
                    {
                        if (!isVisisted[rowNow, j])
                        {
                            sum += matrix[rowNow, j];
                            //Console.WriteLine("i={0} j={1}", rowNow, j);

                            isVisisted[rowNow, j] = true;
                        }
                    }//to right
                }

                colNow = col;

              
                    direction = ChooseUpOrDown(row, rowNow);
                    if (direction == "up")
                    {
                        for (int i = rowNow; i >= row; --i)
                        {
                            if (!isVisisted[i, colNow])
                            {
                                sum += matrix[i, colNow];
                                //Console.WriteLine("i={0} j={1}", i, colNow);

                                isVisisted[i, colNow] = true;
                            }
                        } // up
                    }
                    else
                    {
                        for (int i = rowNow; i <= row; i++)
                        {
                            if (!isVisisted[i, colNow])
                            {
                                sum += matrix[i, colNow];

                                //Console.WriteLine("i={0} j={1}", i, colNow);

                                isVisisted[i, colNow] = true;
                            }
                        } //down
                    }
                    rowNow = row;
                }
            
            Console.WriteLine(sum);

        }
    }
}
