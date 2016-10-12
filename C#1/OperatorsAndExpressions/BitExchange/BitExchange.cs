using System;

class BitExchange
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
        long result = number | mask;
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
        number = Exchange(number, 3, 24);
        number = Exchange(number, 4, 25);
        number = Exchange(number, 5, 26);
        Console.WriteLine(number);
    }
}
