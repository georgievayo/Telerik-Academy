using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class ColoredBeads
    {
        private static char[] arr;
        static int r;
        static int g;
        static int b;
        private static SortedSet<string> results = new SortedSet<string>();
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            r = input[0];
            g = input[1];
            b = input[2];
            arr = new char[r + g + b];
            for (int i = 0; i < b; i++)
            {
                arr[i] = 'B';
            }
            for (int i = b; i < b + g; i++)
            {
                arr[i] = 'G';
            }

            for (int i = b + g; i < arr.Length; i++)
            {
                arr[i] = 'R';
            }
            int index = int.Parse(Console.ReadLine());

            PermuteRep(arr, 0, arr.Length);
            if (index < results.Count)
            {
                Console.WriteLine(results.ElementAt(index));
            }
        }

        static void PermuteRep(char[] arr, int start, int n)
        {
            if (Check(arr))
            {
                results.Add(string.Join("", arr));
            }

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        private static bool Check(char[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}