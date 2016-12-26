using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        static int[][] terrain;
        static void PrintArray()
        {
            for (int i = 0; i < terrain.Length; i++)
            {
                for (int j = 0; j < terrain[i].Length; j++)
                {
                    Console.Write("{0} ", terrain[i][j]);
                }
                Console.WriteLine();
            }
        }

        static int RabbitJump(int currentRow, int currentCol, string direction)
        {
            int sum = 0;

            while (true)
            {

            }
            return sum;
        }
        static void Main(string[] args)
        {
            int baseCol = int.Parse(Console.ReadLine());
            int totalRow = int.Parse(Console.ReadLine());

            int[] initialPorcupine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] initialRabbit = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            long sumR = 0;
            long sumP = 0;

            List<List<string>> commands = new List<List<string>>();
            string input = string.Empty;
            while (input != "END")
            {
                input = Console.ReadLine();
                commands.Add(input.Split(' ').ToList());
            }

            terrain = new int[totalRow][];

            //Build the terrain
            for (int i = 0; i < totalRow; i++)
            {
                if (i < totalRow/2)
                {
                    terrain[i] = new int[(i + 1) * baseCol];
                }
                else
                {
                    terrain[i] = new int[(totalRow - i) * baseCol];
                }
            }

            // Fill the terrain
            for (int i = 0; i < terrain.Length; i++)
            {
                for (int j = 0; j < terrain[i].Length; j++)
                {
                    if (j == 0)
                    {
                        terrain[i][j] = i + 1;
                    }
                    else
                    {
                        terrain[i][j] = terrain[i][j-1]+ terrain[i][0];
                    }
                }
            }

            int[] currentR = { initialRabbit[0], initialRabbit[1] };

            foreach(var command in commands)
            {
                if (command[0] == "R")
                {
                    int step = command[1] == "L" || command[1] == "B" ? -1 : 1;

                    while (true)
                    {
                        sumR += terrain[currentR[0]][currentR[1]];
                        currentR[0] % terrain[currentR[0]].Length += step;
                    }
                }
            }

            PrintArray();
        }
    }
}
