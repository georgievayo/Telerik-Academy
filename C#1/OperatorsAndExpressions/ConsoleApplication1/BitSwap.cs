using System;

class BitSwap
{
    static int FindBit(long number, int bitPosition)
    {

        int mask = 1 << bitPosition;

        long bit = (number & mask) >> bitPosition;
        return (int)bit;
    }

    static long ModifyBit(long number, int bitPosition, int bit)
    {
        int mask = 1 << bitPosition;
        long result = number | (long)mask;
        if (bit == 0)
        {
            mask = ~mask;
            result = number & mask;
        }
        return result;
    }

    static long Exchange(long num, int firstPosition, int secondPosition)
    {
        int firstBitToExchange = FindBit(num, firstPosition);
        int secondBitToExchange = FindBit(num, secondPosition);
        num = ModifyBit(num, secondPosition, firstBitToExchange);
        num = ModifyBit(num, firstPosition, secondBitToExchange);
        return num;
    }

    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        for (int i = p; i <= p + k - 1; i++)
        {
            number = Exchange(number, i, q);
            q++;
        }
        Console.WriteLine(number);
    }
}
