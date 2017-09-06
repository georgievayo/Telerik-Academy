using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guards
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int guardsNum = int.Parse(Console.ReadLine());
            int[,] maze = new int[rows, cols];

            for (int i = 0; i < guardsNum; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int row = int.Parse(line[0]);
                int col = int.Parse(line[1]);
                var protectedPosition = FindProtectedCell(row, col, line[2]);
                maze[row, col] = int.MaxValue - 100;
                if (protectedPosition.Item1 >= 0 && protectedPosition.Item1 < rows && protectedPosition.Item2 >= 0 &&
                    protectedPosition.Item2 < cols)
                {
                    maze[protectedPosition.Item1, protectedPosition.Item2] = 3;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (maze[i, j] == 0)
                    {
                        maze[i, j] = 1;
                    }
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    if (i == 0)
                    {
                        maze[i, j] += maze[i, j - 1];
                    }

                    if (j == 0)
                    {
                        maze[i, j] += maze[i - 1, j];
                    }
                    
                    if(i != 0 && j != 0)
                    {
                        maze[i, j] += Math.Min(maze[i - 1, j], maze[i, j - 1]);
                    }
                }

            }
            Console.WriteLine(maze[rows - 1, cols - 1]);
            Console.WriteLine(maze[rows - 1, cols - 1] < int.MaxValue - 100 ? maze[rows - 1, cols - 1].ToString() : "Meow");

        }

        static Tuple<int, int> FindProtectedCell(int row, int col, string direction)
        {
            switch (direction)
            {
                case "L": return new Tuple<int, int>(row, col - 1);
                case "R": return new Tuple<int, int>(row, col + 1);
                case "U": return new Tuple<int, int>(row - 1, col);
                case "D": return new Tuple<int, int>(row + 1, col);
                default: throw new Exception();
            }
        }
    }
}
