using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Result
    {
        string name;
        int points;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Result() { }

        public Result(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
}
