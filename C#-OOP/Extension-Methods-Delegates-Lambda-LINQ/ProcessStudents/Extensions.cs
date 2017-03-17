using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessStudents
{
    public static class Extensions
    {
        public static bool Contains(this List<int> numbers, int number)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    counter++;
                }
            }

            if (counter == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ToString(this List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var number in numbers)
            {
                sb.Append(number.ToString());
                sb.Append(" ");
            }
            return sb.ToString();
        }

    }
}
