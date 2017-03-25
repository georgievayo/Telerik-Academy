using System;

namespace Methods
{
    class Calculation
    {
        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new Exception("Invalid number!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("There are no elements to compare!");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                   maxElement = elements[i];
                }
            }

            return maxElement;
        }

        static void PrintAsNumber(double number, Format format)
        {
            if (format == Format.TwoFixedPoints)
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == Format.Percentage)
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == Format.WithEmptySpaces)
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Format is not correct!");
            }
        }

        static void Main()
        {
            Console.WriteLine(Geometry.CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, Format.TwoFixedPoints);
            PrintAsNumber(0.75, Format.Percentage);
            PrintAsNumber(2.30, Format.WithEmptySpaces);

            bool horizontal, vertical;
            Console.WriteLine(Geometry.CalcDistanceBetweenTwoPoints(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
