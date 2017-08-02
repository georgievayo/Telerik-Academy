using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRecursion
{
    public class Range
    {
        public static Lazy<List<int>> FromTo(Lazy<int> begin, Lazy<int> end)
        {
            if (begin.Value >= end.Value)
            {
                return new Lazy<List<int>>();
            }

            return new Lazy<List<int>>(() => new List<int>(begin, FromTo(new Lazy<int>(() => begin.Value + 1), end)));
        }

        public static Lazy<List<int>> FromIEnumerable(this IEnumerable<int> values)
        {
            return FromIEnumerable(values.GetEnumerator());
        }

        public static Lazy<List<int>> FromIEnumerable(IEnumerator<int> enumerator)
        {
            if (!enumerator.MoveNext())
            {
                return new Lazy<List<int>>(() => new List<int>());
            }

            var headValue = new Lazy<int>(() => enumerator.Current);

            var list = new List<int>(headValue, FromIEnumerable(enumerator));
        }
    }
}
