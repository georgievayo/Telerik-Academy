using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static bool isLarger(int[] arr, int position)
        {
            if (arr[position] > arr[position + 1] &&arr[position] > arr[position -1] )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(input[i]);
            }

            bool flag = false;
            for (int i = 1; i < n - 1; i++)
            {
                if (isLarger(arr,i))
                {
                    Console.WriteLine(i);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine(-1);
            }
        }
    }
}
