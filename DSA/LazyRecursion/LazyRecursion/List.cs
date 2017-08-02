using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRecursion
{
    public class List<T>
    {
        private Optional<Pair<T, List<T>>> head;

        public List()
        {
            this.head = new Optional<Pair<T, List<T>>>();
        }

        public List(Lazy<T> headValue, Lazy<List<T>> tailList)
        {
            this.head = new Optional<Pair<T, List<T>>>(
                new Lazy<Pair<T, List<T>>>(() =>
                    new Pair<T, List<T>>(headValue, tailList)));
        }

        public Lazy<RT> WithList<RT>(Lazy<RT> whenEmpty, Func<Lazy<T>, Lazy<List<T>>, Lazy<RT>> f)
        {
            return head.WithOptional(whenEmpty, pair => pair.Value.WithPair(f));
        }
    }
}
