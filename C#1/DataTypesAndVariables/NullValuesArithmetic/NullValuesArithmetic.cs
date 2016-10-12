using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? var1 = null;
        double? var2 = null;
        Console.WriteLine(var1);
        Console.WriteLine(var2);
        Console.WriteLine(var2 + 4);
        Console.WriteLine(var1 + null);
    }
}
