using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    public static class BinarySearchArgorithm
    {
        public static int BinarySearch1(this List<int> list, int key, int from, int to)
        {
            if (from > to)
            {
                return -1;
            }

            int middle = (to + from) / 2;
            if (key < list[middle])
            {
               return BinarySearch1(list, key, from, middle);
            }
            else if (key > list[middle])
            {
                return BinarySearch1(list, key, middle + 1, to);
            }
            else
            {
               return middle;
            }
        }
    }
}
