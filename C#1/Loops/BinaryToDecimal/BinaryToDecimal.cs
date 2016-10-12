using System;

class BinaryToDecimal
{
    static void Main()
    {
        long sum = 0;
        string number = Console.ReadLine();
        for (int i = number.Length - 1; i >= 0; i--)
        {
            int lastDigit = (int)Char.GetNumericValue(number[i]) % 10;
            sum = sum + (long)(lastDigit * (Math.Pow(2, number.Length - 1 - i)));
        }
        Console.WriteLine(sum);
    }
}
