using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> price = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            BigInteger profit = 0;
            profit = FindProfit(price, profit);
            if (profit < 0)
            {
                profit = 0;
            }
            Console.WriteLine(profit);

        }

        static BigInteger FindProfit(List<int> price, BigInteger profit)
        {
            int max = price.Max();

            int ounces = 0;
            

            for (int i = 0; i < price.Count; i++)
            {
                if (price[i] < max)
                {
                    profit -= price[i];
                    ounces++;
                }
                else
                {
                    profit += ounces * price[i];
                    ounces = 0;
                    if (i == price.Count - 1)
                    {
                        return profit;
                    }
                    else
                    {
                        var newList = new List<int>();
                        newList = price.GetRange(i + 1, price.Count - i - 1);
                        FindProfit(newList, profit);
                    }
                }
            }
            return profit;
        }
    }
}
