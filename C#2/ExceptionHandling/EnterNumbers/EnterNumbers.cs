using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    class EnterNumbers
    {
        static string ReadNumber(string[] input, int start, int end)
        {
            string result = string.Format("{0} < ", start.ToString());
            int[] numbers = new int[10];
            bool isInvalid = false;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    numbers[i] = int.Parse(input[i]);
                }
                catch (Exception exc)
                {
                    throw new Exception("Exception", exc);
                }
                if (numbers[i] < start || numbers[i] > end)
                {
                    isInvalid = true;
                }
                if (i > 0 && numbers[i] <= numbers[i - 1])
                {
                    isInvalid = true;
                }
                result += string.Format("{0} < ", numbers[i]);
            }
            result += string.Format("{0}", end.ToString());
            if (isInvalid)
            {
                return "Exception";
            }

            return result;

        }
        static void Main(string[] args)
        {
            string[] input = new string[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = Console.ReadLine();
            }
            Console.WriteLine(ReadNumber(input, 1, 100)); 
        }
    }
}
