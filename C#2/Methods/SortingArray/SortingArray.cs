using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArray
{
    class SortingArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(input[i]);
            }
            Array.Sort(arr);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
        }
    }
}
