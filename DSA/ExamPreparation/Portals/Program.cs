using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Program
    {
        private static long max = 0;
        private static long sum = 0;
        private static string[,] labyrinth;
        static void Main(string[] args)
        {
            var initialPosition = Console.ReadLine().Split(' ');
            var currentRow = int.Parse(initialPosition[0]);
            var currentCol = int.Parse(initialPosition[1]);
            var sizes = Console.ReadLine().Split(' ');
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            labyrinth = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    labyrinth[i, j] = line[j];
                }
            }
            int lastAdded = 0;
            FindMaxSum(currentRow, currentCol, lastAdded);
            Console.WriteLine(max);

        }

        static void FindMaxSum(int i, int j, int lastAdded)
        {
            if (labyrinth[i, j] == "#")
            {
                if (max < sum)
                {
                    max = sum;
                }
                return;
            }
            else
            {
                int cellValue = int.Parse(labyrinth[i, j]);
                sum += cellValue;
                lastAdded = cellValue;
                labyrinth[i, j] = "#";


                // go right
                if (j + cellValue < labyrinth.GetLength(1))
                {
                    FindMaxSum(i, j + cellValue, lastAdded);
                }
                // go left
                if (j - cellValue >= 0)
                {
                    FindMaxSum(i, j - cellValue, lastAdded);
                }
                // go down
                if (i + cellValue < labyrinth.GetLength(0))
                {
                    FindMaxSum(i + cellValue, j, lastAdded);
                }
                // go up
                if (i - cellValue >= 0)
                {
                    FindMaxSum(i - cellValue, j, lastAdded);
                }

                labyrinth[i, j] = cellValue.ToString();
                sum -= lastAdded;
            }
        }

        static void PrintLabyrinth()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write(labyrinth[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
