using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyTheSnake
{

    class SneakyTheSnake
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split('x');
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            int curRow = 0;
            int curCol = 0;

            int length = 3;

            char[,] terrain = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string line = string.Empty;
                line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (i == 0 && line[j] == 'e')
                    {
                        curCol = j;
                    }
                    terrain[i, j] = line[j];
                }
            }

            
            string[] directions = Console.ReadLine().Split(',');

            for (int i = 0; i < directions.Length; i++)
            {
                if (i % 5 == 4 && i > 1)
                {
                    --length;
                }
                
                int verticalStep = 0;
                int horizontalStep = 0;
                switch (directions[i])
                {
                    case "s": verticalStep = 1; break;
                    case "w":verticalStep = -1; break;
                    case "a": horizontalStep = -1; break;
                    case "d": horizontalStep = 1; break;
                    default:
                        break;
                }

                if (directions[i] == "s" || directions[i] == "w")
                {

                    curRow += verticalStep;
                    if (length <= 0 && terrain[curRow, curCol] != '@')
                    {
                        Console.WriteLine("Sneaky is going to starve at [{0},{1}]", curRow - verticalStep, curCol);
                        break;
                    }
                    if (curRow > rows)
                    {
                        Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", length);
                        break;
                    }

                    else
                    {
                        if (terrain[curRow, curCol] == '@')
                        {
                            length++;
                            terrain[curRow, curCol] = 'x';
                        }
                        else if (terrain[curRow, curCol] == '%')
                        {
                            Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", curRow, curCol);
                            break;
                        }
                    }
                    if (i == directions.Length - 1 && terrain[curRow,curCol] != 'e')
                    {
                        Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", curRow, curCol);
                        break;
                    }
                    else if (terrain[curRow, curCol] == 'e' && i!=0)
                    {
                        Console.WriteLine("Sneaky is going to get out with length {0}", length);
                        break;
                    }

                }
                else
                {
                    curCol += horizontalStep;
                    if (length <= 0 && terrain[curRow, curCol] != '@')
                    {
                        Console.WriteLine("Sneaky is going to starve at [{0},{1}]", curRow, curCol - horizontalStep);
                        break;
                    }
                    if (curCol >= cols)
                    {
                        curCol = 0;
                    }
                    else if (curCol < 0)
                    {
                        curCol = cols - 1;
                    }
                    if (terrain[curRow, curCol] == '@')
                    {
                        length++;
                        terrain[curRow, curCol] = 'x';
                    }
                    else if (terrain[curRow, curCol] == '%')
                    {
                        Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", curRow, curCol);
                        break;
                    }
                    if (i == directions.Length - 1 && terrain[curRow, curCol] != 'e')
                    {
                        Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", curRow, curCol);
                        break;
                    }
                    else if (terrain[curRow, curCol] == 'e' && i != 0)
                    {
                        Console.WriteLine("Sneaky is going to get out with length {0}", length);
                        break;
                    }
                }
            }

            //Print
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write("{0} ", terrain[i,j]);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
