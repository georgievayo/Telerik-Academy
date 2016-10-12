using System;

class ModifyBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());
        int mask = 1 << p;
        int result = n | mask;
        if (v == 0)
        {
            mask = ~mask;
            result = n & mask;
        }
        Console.WriteLine(result);
    }
}

