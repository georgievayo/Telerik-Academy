using System;

namespace LeapYear
{
    class LeapYear
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            if (year % 4 == 0)
            {
                Console.WriteLine("Leap");
            }
            else
            {
                Console.WriteLine("Common");
            }
        }
    }
}
