using System;
using System.Collections.Generic;


namespace LargestAreaInMatrix
{
    class LargestAreaInMatrix
    {
        private static bool[,] isVisited;
        private static int max = 0;
        private static int current = 0;
        static void Spreading(int[,] arr, int row, int col, int currentElement)
        {
            if ((row < 0 || col < 0 || row >= arr.GetLength(0) || col >= arr.GetLength(1) || currentElement != arr[row, col]))
            {
                return;
            }
            if (isVisited[row, col])
            {
                return;
            }
            isVisited[row, col] = true;
            current++;
            Spreading(arr, row - 1, col, currentElement); // up
            Spreading(arr, row + 1, col, currentElement); // down    
            Spreading(arr, row, col - 1, currentElement); // left        
            Spreading(arr, row, col + 1, currentElement); // right 
        }

        static void Main()
        {
            string[] sizes = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(sizes[0]);
            int m = Convert.ToInt32(sizes[1]);
            int[,] arr = new int[n, m];
            bool[,] boolArr = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] numbersInRow = Console.ReadLine().Split(' ');

                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = Convert.ToInt32(numbersInRow[j]);
                }
            }


            isVisited = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    Spreading(arr, i, j, arr[i, j]);

                    if (current > max)
                    {
                        max = current;
                    }
                    current = 0;
                }
            }
         ;

            Console.WriteLine("{0}", max);

        }
    }
}
