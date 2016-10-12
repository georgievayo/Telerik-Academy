using System;

class MMSAOfNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double firstNumber = double.Parse(Console.ReadLine());
        double min = firstNumber, max = firstNumber, sum = firstNumber;
        for (int i = 2; i <= n; i++)
        {
            double number = double.Parse(Console.ReadLine());
            sum += number;
            if (number > max)
            {
                max = number;
            }
            else if (number < min)
            {
                min = number;
            }
        }
        Console.WriteLine("min={0:F2}", min);
        Console.WriteLine("max={0:F2}", max);
        Console.WriteLine("sum={0:F2}", sum);
        Console.WriteLine("avg={0:F2}", sum / n);
    }
}