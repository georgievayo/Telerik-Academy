using System;
using System.Linq;
class OddAndEvenProduct
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int oddProduct = 1;
        int evenProduct = 1;
        var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        for (int i = 0; i <= n-1; i++)
        {
            if ((i+1) % 2 == 0)
            {
                evenProduct *= numbers[i];
            }
            else oddProduct *= numbers[i];
        }
        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes {0}", oddProduct);
        }
        else Console.WriteLine("no {0} {1}", oddProduct, evenProduct);
    }
}

