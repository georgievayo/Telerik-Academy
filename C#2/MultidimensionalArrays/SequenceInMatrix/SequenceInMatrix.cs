using System;

namespace SequenceInMatrix
{
    class SequenceInMatrix
    {
        public static int FindLengthInRowAndCol(string[,] arr, int startIndexOfRow, int startIndexOfCol)
        {
            int ctr = 0;
            int maxLength = 0;
            string element = arr[startIndexOfRow, startIndexOfCol];
            for (int i = startIndexOfRow; i < arr.GetLength(0); i++)
            {
                if (arr[i, startIndexOfCol] == element)
                {
                    ctr++;
                }
            }
            if (ctr > maxLength)
            {
                maxLength = ctr;
            }
            ctr = 0;

            for (int i = startIndexOfCol; i < arr.GetLength(1); i++)
            {
                if (arr[startIndexOfRow, i] == element)
                {
                    ctr++;
                }
            }
            if (ctr > maxLength)
            {
                maxLength = ctr;
            }
            return maxLength;
        }

        public static int FindLengthInLeftDiagonal(string[,] arr, int startIndexOfRow, int startIndexOfCol)
        {
            string element = arr[startIndexOfRow, startIndexOfCol];
            int ctr = 0;
            int maxLength = 0;

            int row = startIndexOfRow;
            int col = startIndexOfCol;
            //left diagonal
            while ((col > 0 && row < arr.GetLength(0))&&(row + col == startIndexOfCol + startIndexOfRow && arr[row, col] == element))
            {
                ctr++;
                row++;
                col--;
            }
            if (ctr > maxLength)
            {
                maxLength = ctr;
            }
            return maxLength;
        }

        public static int FindLengthInRightDiagonal(string[,] arr, int startIndexOfRow, int startIndexOfCol)
        {
            string element = arr[startIndexOfRow, startIndexOfCol];
            int ctr = 0;
            int maxLength = 0;

            int row = startIndexOfRow;
            int col = startIndexOfCol;
            //right diagonal
            while ((col < arr.GetLength(1) && row < arr.GetLength(0)) && (col - row == startIndexOfCol - startIndexOfRow && arr[row, col] == element))
            {
                ctr++;
                row++;
                col++;
            }
            if (ctr > maxLength)
            {
                maxLength = ctr;
            }
            return maxLength;
        }
        static void Main()
        {
            string[] sizes = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(sizes[0]);
            int m = Convert.ToInt32(sizes[1]);

            string[,] arr = new string[n, m];
            int maxLength = 0;
            int length = 0;

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = line[j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        length = Math.Max(FindLengthInRightDiagonal(arr, i, j), FindLengthInRowAndCol(arr, i, j));
                        if (length > maxLength)
                        {
                            maxLength = length;
                        }
                    }
                    else if (j == m - 1)
                    {
                        length = Math.Max(FindLengthInLeftDiagonal(arr, i, j), FindLengthInRowAndCol(arr, i, j));
                        if (length > maxLength)
                        {
                            maxLength = length;
                        }
                    }
                    else
                    {
                        length = Math.Max(Math.Max(FindLengthInLeftDiagonal(arr, i, j), FindLengthInRightDiagonal(arr, i, j)), FindLengthInRowAndCol(arr, i, j));
                        if (length > maxLength)
                        {
                            maxLength = length;
                        }
                    }
                }
            }
            Console.WriteLine(maxLength);
        }
    }
}
