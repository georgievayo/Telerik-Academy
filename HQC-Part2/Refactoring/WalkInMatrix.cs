using System;

namespace RotatingWalkGame
{
    public class WalkInMatrix
    {
        public static int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        public static int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        public static int directionsCount = 8;

        public static void ChangeDirection(ref int dx, ref int dy)
        {
            int currentDirection = 0;
            for (int i = 0; i < directionsCount; i++)
            {
                if (dirX[i] == dx && dirY[i] == dy)
                {
                    currentDirection = i;
                    break;
                }
            }

            // If current direction is the last one 
            // then it becomes the first one
            if (currentDirection == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[currentDirection + 1];
            dy = dirY[currentDirection + 1];
        }

        public static bool HasEmptyCellAround(int[,] arr, int x, int y)
        {
            int length = arr.GetLength(0);
            for (int i = 0; i < directionsCount; i++)
            {
                if (x + dirX[i] >= length || x + dirX[i] < 0 || y + dirY[i] >= length || y + dirY[i] < 0)
                {
                    continue;
                }
                else if(arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindEmptyCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            int length = arr.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    bool isEmpty = arr[i, j] == 0;
                    if (isEmpty)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        public static bool IsOutOfBoundaries(int currentX, int currentY, int dx, int dy, int size)
        {
            return currentX + dx >= size || currentX + dx < 0 || currentY + dy >= size || currentY + dy < 0;
        }

        public static bool IsEmptyCell(int[,] matrix, int row, int col)
        {
            return matrix[row, col] == 0;
        }

        public static void PrintMatrix(int[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number:");
            int n = 0;
            string input = Console.ReadLine();


            while (!int.TryParse(input, out n) || n < 0 || n > 100) 
            {
                Console.WriteLine("You haven't entered a correct positive number. Please, enter again!");
                input = Console.ReadLine();
            } 

            int[,] matrix = new int[n, n];

            int value = 1;
            int currentX = 0;
            int currentY = 0;
            int dx = 1;
            int dy = 1;
            matrix[currentX, currentY] = value;

            while (true)
            {
                while (HasEmptyCellAround(matrix, currentX, currentY))
                {

                    while (IsOutOfBoundaries(currentX, currentY, dx, dy, n) ||
                           !IsEmptyCell(matrix, currentX + dx, currentY + dy))
                    {
                        ChangeDirection(ref dx, ref dy);
                    }

                    currentX += dx;
                    currentY += dy;
                    value++;
                    matrix[currentX, currentY] = value;
                }

                FindEmptyCell(matrix, out currentX, out currentY);

                //If there is no empty cell in matrix
                if (currentX == 0 && currentY == 0)
                {
                    break;
                }

                dx = 1;
                dy = 1;
            }

            PrintMatrix(matrix, n);
        }
    }
}
