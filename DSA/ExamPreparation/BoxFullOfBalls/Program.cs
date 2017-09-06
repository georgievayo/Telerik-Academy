using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFullOfBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] possibleTurns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(possibleTurns);
            int[] possibleBalls = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(possibleBalls);
            bool[] isWinningStrategy = new bool[possibleBalls[possibleBalls.Length - 1]];
            int wins = 0;
            bool[] winning = GenerateWinningCases(possibleTurns, possibleBalls);
            for (int i = possibleBalls[0]; i <= possibleBalls[1]; i++)
            {
                if (winning[i])
                {
                    wins++;
                }
            }
            Console.WriteLine(wins);
        }

        static bool[] GenerateWinningCases(int[] turns, int[] balls)
        {
            bool[] isWinning = new bool[500000];
            for (int i = 0; i < turns.Length; i++)
            {
                isWinning[turns[i]] = true;
            }

            for (int i = 0; i < balls[balls.Length - 1]; i++)
            {
                if (!isWinning[i])
                {
                    foreach (var turn in turns)
                    {
                        isWinning[i + turn] = true;
                    }
                }
            }

            return isWinning;
        }
    }
}
