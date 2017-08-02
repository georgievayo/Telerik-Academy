using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRecursion
{
    public class Pair<T1, T2>
    {
        private Lazy<T1> first;

        private Lazy<T2> second;

        public Pair(Lazy<T1> f, Lazy<T2> s)
        {
            this.first = f;
            this.second = s;
        }

        public Lazy<RT> WithPair<RT>(Func<Lazy<T1>, Lazy<T2>, Lazy<RT>> func)
        {
            return func(first, second);
        }
    }

    public class Optional<T>
    {
        private Lazy<T> value;

        public Optional()
        {
            value = null;
        }

        public Optional(Lazy<T> v)
        {
            value = v;
        }

        public Lazy<RT> WithOptional<RT>(Lazy<RT> whenEmpty, Func<Lazy<T>, Lazy<RT>> whenFull)
        {
            if (value == null)
            {
                return whenEmpty;
            }

            return whenFull(value);
        }

        public Optional<Lazy<RT>> Bind<RT, T2>(Func<Lazy<T>, Optional<Lazy<RT>>> f)
        {
            if (value == null)
            {
                return new Optional<Lazy<RT>>();
            }

            return f(value);
        }
    }
}
