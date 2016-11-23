using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingPolynomials
{
    class AddingPolynomials
    {
        static void Add(int[] first, int[] second,int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", first[i] + second[i]);
            }
        }
        static void Main(string[] args) 
        {
            int n = int.Parse(Console.ReadLine());
            string[] input1 = Console.ReadLine().Split(' ');
            int[] arr1 = new int[input1.Length];
            string[] input2 = Console.ReadLine().Split(' ');
            int[] arr2 = new int[input2.Length];
            for (int i = 0; i < input1.Length; i++)
            {
                arr1[i] = Convert.ToInt32(input1[i]);
            }
            for (int i = 0; i < input2.Length; i++)
            {
                arr2[i] = Convert.ToInt32(input2[i]);
            }
            Add(arr1, arr2, n);
        }
    }
}
