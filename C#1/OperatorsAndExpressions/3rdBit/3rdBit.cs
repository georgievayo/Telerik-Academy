using System;

class _3rdBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int mask = 1 << 3;
        int numberAndMask = number & mask;
        int bit = numberAndMask >> 3;
        Console.WriteLine(bit);
    }
}
