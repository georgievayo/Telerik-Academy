using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse);

            var correct = new Sequence[n+1];

            for (int i = 1; i <= n; i++)
            {
                correct[i] = new Sequence(i, correct[i - 1]);
            }

            var leftEnd = correct[1];
            var rightEnd = correct[n];

            foreach (int x in numbers)
            {
                var middle = correct[x];
                var newRight = middle.left;
                var newLeft = middle.right;

                Sequence.Detach(middle);
                Sequence.Attach(rightEnd, middle);
                Sequence.Attach(middle, leftEnd);

                leftEnd = newLeft ?? middle;
                rightEnd = newRight ?? middle;
            }

            var output = new int[n];
            for (int i = 0; i < n; ++i)
            {
                output[i] = leftEnd.middle;
                leftEnd = leftEnd.right;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class Sequence
    {
        public int middle;

        public Sequence left;
        public Sequence right;

        public Sequence()
        {
            
        }
        public Sequence(int middle, Sequence left)
        {
            this.middle = middle;
            this.left = left;
            this.right = null;

            if (left != null)
            {
                left.right = this;
            }
        }

        public static void Detach(Sequence x)
        {
            if (x.left != null)
            {
                x.left.right = null;
            }
            if (x.right != null)
            {
                x.right.left = null;
            }

            x.left = null;
            x.right = null;
        }

        public static void Attach(Sequence l, Sequence r)
        {
            if (l == r)
            {
                return;
            }

            l.right = r;
            r.left = l;
        }
    }
}
