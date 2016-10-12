using System;

class DecimalToBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string binary = "", reversedBinary = "";
        do
        {
            int remainder = number % 2;
            binary += remainder.ToString();
            number /= 2;
        } while (number != 0);
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            reversedBinary += binary[i];
        }
        Console.WriteLine("{0}", reversedBinary);
    }
}
