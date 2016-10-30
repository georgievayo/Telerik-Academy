using System;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] arr = new bool[n+1];
            arr[0] = arr[1] = true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (arr[i] == false)
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        arr[j] = true;
                    }
                }
            }
            
            for (int k = n; k >= 0; k--)
            {
                if (arr[k] == false)
                {
                    Console.WriteLine(k);
                    break;
                }
            }
        }
    }
}
