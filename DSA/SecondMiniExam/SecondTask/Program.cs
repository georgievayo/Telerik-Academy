using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            var neighbours = new List<int>[rows * cols + 1];
            var map = new Dictionary<int, Node>();
            int k = 1;
            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    int val = int.Parse(row[j]);
                    map[k] = new Node(i, j, val);
                    k++;
                }
            }


        }
    }

    class Node : IComparable
    {
        public int Value;

        public int Row;

        public int Col;

        public Node(int row, int col, int value)
        {
            Row = row;
            Col = col;
            Value = value;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
