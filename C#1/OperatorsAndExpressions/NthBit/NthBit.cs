using System;

class NthBit
{
    static void Main()
    {
        long p = long.Parse(Console.ReadLine()); 
        int n = int.Parse(Console.ReadLine()); 
        long nValue = (long)((p >> n) & 1);
        Console.WriteLine(nValue);
    }
}
