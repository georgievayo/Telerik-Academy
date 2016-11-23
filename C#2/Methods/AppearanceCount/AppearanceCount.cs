using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppearanceCount
{
    class AppearanceCount
    {
        static int Counting(int[] arr, int number)
        {
            int ctr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    ctr++;
                }
            }
            return ctr;
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
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(Counting(arr,k));
        }
    }
}
