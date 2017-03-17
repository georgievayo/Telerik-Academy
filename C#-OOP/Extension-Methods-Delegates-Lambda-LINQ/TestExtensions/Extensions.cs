using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExtensions
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder substring = new StringBuilder();
            for (int i = index; i < index + length; i++)
            {
                substring.Append(sb[i]);
            }
            return substring;
        }

        public static T Sum<T>(this IEnumerable<T> sequence)
        {
            dynamic sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> sequence)
        {
            dynamic product = 1;
            foreach (var item in sequence)
            {
                product *= item;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> sequence)
        {
            dynamic min = sequence.First();
            foreach (var item in sequence)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> sequence)
        {
            dynamic max = sequence.First();
            foreach (var item in sequence)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> sequence)
        {
            int counter = 0;
            foreach (var item in sequence)
            {
                counter++;
            }
            return (dynamic)sequence.Sum() / counter;
        }
    }
}
