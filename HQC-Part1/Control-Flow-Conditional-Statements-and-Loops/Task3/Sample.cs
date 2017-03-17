using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Sample
    {
        static void Main(string[] args)
        {
            int index;
            for (index = 0; index < 100; index++)
            {
                Console.WriteLine(array[index]);
                if (index % 10 == 0 && array[index] == expectedValue)
                {
                    index = 666;
                }
            }
            // More code here
            if (index == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
