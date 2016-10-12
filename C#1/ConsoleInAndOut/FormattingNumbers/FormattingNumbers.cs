using System;

    class FormattingNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            string hexValue = a.ToString();
            string binValue = Convert.ToString(a, 2);
            Console.WriteLine("{0, -10}{1, 10}{2:F2, 10}{3:F3, -10}", hexValue, binValue, b, c);
        }
    }
