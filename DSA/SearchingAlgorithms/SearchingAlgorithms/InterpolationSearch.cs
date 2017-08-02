using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    public static class InterpolationSearchAlorithm
    {
        public static int InterpolationSearch(this List<int> list, int key, int from, int to)
        {
            if (from > to)
            {
                return -1;
            }

            int middle = from + ((key - list[from])*(to - from)) / (list[to] - list[from]);
            if (key < list[middle])
            {
                return InterpolationSearch(list, key, from, middle - 1);
            }
            else if (key > list[middle])
            {
                return InterpolationSearch(list, key, middle + 1, to);
            }
            else
            {
                return middle;
            }
        }
    }
}
