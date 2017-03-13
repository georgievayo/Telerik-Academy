using Minesweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesGame
{
	public class Minesweeper
    {

		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] board = CreateBoard();
			char[,] mines = PutMines();
			int counter = 0;
			bool hasExplode = false;
			List<Result> winners = new List<Result>(6);
			int row = 0;
			int col = 0;
			bool firstFlag = true;
			const int max = 35;
			bool secondFlag = false;

			do
			{
				if (firstFlag)
				{
					Console.WriteLine(@"Let's play Minesweeper. Try to find the boards without mines. 
Command 'top' shows the rating.
Command 'restart' starts new game.
Command 'exit' ends the current game.");
					ShowBoard(board);
					firstFlag = false;
				}
				Console.Write("Enter row and column : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out col) &&
						row <= board.GetLength(0) && col <= board.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ShowRating(winners);
						break;
					case "restart":
						board = CreateBoard();
						mines = PutMines();
						ShowBoard(board);
						hasExplode = false;
						firstFlag = false;
						break;
					case "exit":
						Console.WriteLine("Bye, bye, bye!");
						break;
					case "turn":
						if (mines[row, col] != '*')
						{
							if (mines[row, col] == '-')
							{
                                ChangeTurn(board, mines, row, col);
								counter++;
							}
							if (max == counter)
							{
								secondFlag = true;
							}
							else
							{
								ShowBoard(board);
							}
						}
						else
						{
							hasExplode = true;
						}
						break;
					default:
						Console.WriteLine("\nError! Invalid command!\n");
						break;
				}
				if (hasExplode)
				{
					ShowBoard(mines);
					Console.Write("\nHrrrrrr! You have died with {0} points. " +
						"Please, write your nickname: ", counter);
					string nickName = Console.ReadLine();
					Result t = new Result(nickName, counter);
					if (winners.Count < 5)
					{
						winners.Add(t);
					}
					else
					{
						for (int i = 0; i < winners.Count; i++)
						{
							if (winners[i].Points < t.Points)
							{
								winners.Insert(i, t);
								winners.RemoveAt(winners.Count - 1);
								break;
							}
						}
					}
					winners.Sort((Result firsrResult, Result secondResult) => secondResult.Name.CompareTo(firsrResult.Name));
					winners.Sort((Result firsrResult, Result secondResult) => secondResult.Points.CompareTo(firsrResult.Points));
					ShowRating(winners);

					board = CreateBoard();
					mines = PutMines();
					counter = 0;
					hasExplode = false;
					firstFlag = true;
				}
				if (secondFlag)
				{
					Console.WriteLine("\nCongratulations! You have opened 35 fields.");
					ShowBoard(mines);
					Console.WriteLine("Please, write your nickname: ");
					string nickName = Console.ReadLine();
					Result result = new Result(nickName, counter);
					winners.Add(result);
					ShowRating(winners);
					board = CreateBoard();
					mines = PutMines();
					counter = 0;
					secondFlag = false;
					firstFlag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Goodbye!");
			Console.Read();
		}

		private static void ShowRating(List<Result> results)
		{
			Console.WriteLine("\nResults:");
			if (results.Count > 0)
			{
				for (int i = 0; i < results.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} points",
						i + 1, results[i].Name, results[i].Points);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("The rating is empty!\n");
			}
		}

		private static void ChangeTurn(char[,] board, char[,] mines, int row, int col)
		{
			char numberOfMines = CountMines(mines, row, col);
			mines[row, col] = numberOfMines;
			board[row, col] = numberOfMines;
		}

		private static void ShowBoard(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateBoard()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PutMines()
		{
			int rows = 5;
			int cols = 10;
			char[,] board = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					board[i, j] = '-';
				}
			}

			List<int> listOfNumbers = new List<int>();
			while (listOfNumbers.Count < 15)
			{
				Random nextNumber = new Random();
				int number = nextNumber.Next(50);
				if (!listOfNumbers.Contains(number))
				{
                    listOfNumbers.Add(number);
				}
			}

			foreach (int num in listOfNumbers)
			{
				int col = (num / cols);
				int row = (num % cols);
				if (row == 0 && num != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}
				board[col, row - 1] = '*';
			}

			return board;
		}

		private static void PutNumbers(char[,] board)
		{
			int cols = board.GetLength(0);
			int rows = board.GetLength(1);

			for (int i = 0; i < cols; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					if (board[i, j] != '*')
					{
						char numberOfMines = CountMines(board, i, j);
                        board[i, j] = numberOfMines;
					}
				}
			}
		}

		private static char CountMines(char[,] board, int row, int col)
		{
			int counter = 0;
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);

			if (row - 1 >= 0)
			{
				if (board[row - 1, col] == '*')
				{
                    counter++; 
				}
			}
			if (row + 1 < rows)
			{
				if (board[row + 1, col] == '*')
				{
                    counter++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (board[row, col - 1] == '*')
				{
                    counter++;
				}
			}
			if (col + 1 < cols)
			{
				if (board[row, col + 1] == '*')
				{
                    counter++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (board[row - 1, col - 1] == '*')
				{
                    counter++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (board[row - 1, col + 1] == '*')
				{
                    counter++; 
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (board[row + 1, col - 1] == '*')
				{
                    counter++; 
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (board[row + 1, col + 1] == '*')
				{
                    counter++; 
				}
			}
			return char.Parse(counter.ToString());
		}
	}
}
