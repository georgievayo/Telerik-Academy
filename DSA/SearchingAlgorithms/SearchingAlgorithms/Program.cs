using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 4, 5, 7, 10, 11};
            Console.WriteLine(list.InterpolationSearch(-9, 0, list.Count - 1));
        }
    }
}
