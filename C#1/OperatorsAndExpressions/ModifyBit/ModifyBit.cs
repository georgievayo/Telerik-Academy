using System;

class ModifyBit
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        uint p = uint.Parse(Console.ReadLine());
        sbyte v = sbyte.Parse(Console.ReadLine());
        ulong mask = (ulong)(1 << (int)p);
        ulong result = 0;
        if (v == 0)
        {
            mask = ~mask;
            result = n & mask;
        }
        else if (v == 1)
        {
            result = n | mask;
        }
        Console.WriteLine(result);
    }
}

