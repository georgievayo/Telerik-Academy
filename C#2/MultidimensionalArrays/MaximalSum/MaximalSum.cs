using System;

namespace MaximalSum
{

    public class MaximalSum
    {
        public static int FindSum(int[,] array, int startIndexOfRow, int startIndexOfCol)
        {
            int sum = 0;
            if (startIndexOfCol + 2 <= array.GetLength(1) - 1 && startIndexOfRow + 2 <= array.GetLength(0) - 1)
            {
                for (int i = startIndexOfRow; i < startIndexOfRow + 3; i++)
                {
                    for (int j = startIndexOfCol; j < startIndexOfCol + 3; j++)
                    {
                        sum += array[i, j];
                    }
                } 
            }
            return sum;
        }

        static void Main()
        {
            string[] sizes = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(sizes[0]);
            int m = Convert.ToInt32(sizes[1]);

            int[,] arr = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] numbersInRow = Console.ReadLine().Split(' ');
                
                for (int j = 0; j < m; j++)
                {
                    arr[i,j] = Convert.ToInt32(numbersInRow[j]);
                }
            }

           
            int maxSum = -9000;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (FindSum(arr,i,j) > maxSum)
                    {
                       maxSum = FindSum(arr,i,j);
                    }
                }
            }
            Console.WriteLine(maxSum);s
        }
    }
}
