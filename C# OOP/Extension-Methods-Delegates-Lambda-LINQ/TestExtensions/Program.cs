using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExtensions
{
    class TestExtensions
    {
        static void Main(string[] args)
        {
            StringBuilder name = new StringBuilder();
            name.Append("Pesho Goshov");
            Console.WriteLine("Pesho's last name is: {0}", name.Substring(6,6));

            List<int> sequence = new List<int>() { 1,5,8,14,7,68,92};
            Console.WriteLine("sum = {0}", sequence.Sum());
            Console.WriteLine("product = {0}", sequence.Product());
            Console.WriteLine("average = {0}", sequence.Average());
            Console.WriteLine("min = {0}", sequence.Min());
            Console.WriteLine("max = {0}", sequence.Max());

        }
    }
}
