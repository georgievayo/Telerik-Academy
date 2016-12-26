using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double number = default(double);

            try
            {
                number = double.Parse(input);
                if (number < 0)
                {
                    throw new FormatException("Invalid number");
                }
                Console.WriteLine("{0:F3}", Math.Sqrt(number));
            }
            catch (FormatException exc)
            {
                Console.WriteLine("Invalid number", exc);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }


        }
    }
}
