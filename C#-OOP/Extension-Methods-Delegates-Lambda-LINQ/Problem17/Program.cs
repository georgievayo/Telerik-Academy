using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem17
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "typotiq", "golqma typotiq", "mnogo golqma typotiq", "tolkova golqma typotiq", "krai" };
            var longestWord = words.OrderByDescending(i => i.Length).First();

            Console.WriteLine(longestWord);
        }
    }
}
