using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster
{
    class Program
    {
        public static long count = 0;
        private static int n;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            long[] conf = new long[n + 1];
            conf[0] = 0;
            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (n % 2 == 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                //for (int i = 2; i < n + 1; i++)
                //{
                //    if (i % 2 == 0)
                //    {
                //        conf[i] = conf[i - 1] + conf[i - 2] + 1;
                //    }
                    
                //}
                double catalanNum = n / 2;
                double pow = Math.Pow(4, catalanNum);
                var result = FindCatalan(catalanNum) * pow;
                Console.WriteLine(result);
            }
        }


        static double FindCatalan(double nth)
        {
            double numerator = 1;
            double denominator = 1;
            for (double i = 2 * nth; i >= nth+ 2; i--)
            {
                numerator *= i;
            }
            for (int i = 1; i <= nth; i++)
            {
                denominator *= i;
            }
            double catalanNumber = numerator / denominator;

            return catalanNumber;
        }
        static long binomialCoeff(int n, int k)
        {
            long res = 1;

            // Since C(n, k) = C(n, n-k)
            if (k > n - k)
                k = n - k;

            // Calculate value of [n*(n-1)*---*(n-k+1)] / [k*(k-1)*---*1]
            for (int i = 0; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            return res;
        }

        // A Binomial coefficient based function to find nth catalan
        // number in O(n) time
        static long catalan(int n)
        {
            // Calculate value of 2nCn
            long c = binomialCoeff(2 * n, n);

            // return 2nCn/(n+1)
            return c / (n + 1);
        }

        // Function to find possible ways to put balanced parenthesis
        // in an expression of length n
       static long findWays(int n)
        {
            // If n is odd, not possible to create any valid parentheses
            if (n % 2 == 1) return 0;

            // Otherwise return n/2'th Catalan Numer
            return catalan(n / 2);
        }
    }
}
