using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Statistics
    {
        public void PrintStatistics(double[] data, int count)
        {
            double max = 0;
            for (int i = 0; i < count; i++)
            {
                if (data[i] > max)
                {
                    max = data[i];
                }
            }

            PrintElement(max, "Max element:");

            double min = 0;
            for (int i = 0; i < count; i++)
            {
                if (data[i] < min)
                {
                    min = data[i];
                }
            }
            PrintElement(min, "Min element:");

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += data[i];
            }
            PrintElement(sum / count, "Average:");
        }

        public void PrintElement(double element, string message)
        {
            Console.WriteLine(message + ' ' + element.ToString());
        }
        static void Main(string[] args)
        {
        }
    }
}
