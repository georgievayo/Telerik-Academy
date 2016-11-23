using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLargestNumber
{
    class GetLargestNumber
    {
        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }
        
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = Convert.ToInt32(input[i]);
            }
            Console.WriteLine(GetMax(numbers[0],GetMax(numbers[1],numbers[2])));
        }
    }
}
