using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTwoTowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> bricks = new List<int>();
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                bricks.Add(int.Parse(Console.ReadLine()));
                sum += bricks[i];
            }
            sum /= 2;
            int maxHeight = 0;

            int count = 0;
            while (count < 2)
            {
                var copy = new List<int>(bricks);
                findNumbers(copy, 0, 0, sum, "", ref count);
                if (count < 2)
                {
                    count = 0;
                }
                --sum;
            }
            Console.WriteLine(sum + 1);

        }

        static void findNumbers(List<int> list, int index, int current, int goal, string result, ref int count)
        {
            if ((list.Count < index || current > goal) && count < 2)
                return;
            for (int i = index; i < list.Count; i++)
            {
                if (current + list[i] == goal)
                {
                    list.RemoveAt(i);

                    foreach (var num in result.Split(' '))
                    {
                        try
                        {
                            list.Remove(int.Parse(num));

                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                    if (count < 2)
                    {
                        count++;
                        findNumbers(list, 0, 0, goal, "", ref count);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (current + list[i] < goal)
                {
                    findNumbers(list, i + 1, current + list[i], goal, result + " " + list[i].ToString(), ref count);
                }
            }
        }
    }
}
