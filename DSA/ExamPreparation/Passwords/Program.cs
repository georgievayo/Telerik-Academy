using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    class Program
    {
        private static int n;
        static List<List<int>> numbersCombinations = new List<List<int>>();
        static List<List<char>> lettersCombinations = new List<List<char>>();
        private static int[] arr;
        private static char[] letters;

        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int[] numbers = Enumerable.Range(0, k).ToArray();
            letters = Console.ReadLine().ToCharArray();
            Array.Sort(letters);
            int l = letters.Length;
            n = int.Parse(Console.ReadLine());
            arr = new int[n];
            GenerateNumbersCombinations(0, 0, k);
            GenerateLettersCombinations(0, 0, l);

            var results = new SortedSet<string>();

            foreach (var numPair in numbersCombinations)
            {
                StringBuilder current = new StringBuilder();
                foreach (var lettersPair in lettersCombinations)
                {
                    current.Append(numPair[0]);
                    current.Append(lettersPair[0] + "-");
                    current.Append(numPair[1]);
                    current.Append(lettersPair[1]);
                    results.Add(current.ToString());
                    current.Clear();
                    current.Append(numPair[0]);
                    current.Append(lettersPair[1] + "-");
                    current.Append(numPair[1]);
                    current.Append(lettersPair[0]);
                    results.Add(current.ToString());
                    current.Clear();
                }
            }

            Console.WriteLine(results.Count);
            if (results.Count > 0)
            {
                Console.WriteLine(string.Join("\n", results));
            }
        }

        static void GenerateNumbersCombinations(int index, int start, int end)
        {
            if (index >= n)
            {
                numbersCombinations.Add(arr.ToList());
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    arr[index] = i;
                    GenerateNumbersCombinations(index + 1, i + 1, end);
                }
            }
        }

        static void GenerateLettersCombinations(int index, int start, int end)
        {
            if (index >= n)
            {
                var current = new List<char>();
                foreach (var i in arr)
                {
                    current.Add(letters[i]);
                }

                lettersCombinations.Add(current);
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    arr[index] = i;
                    GenerateLettersCombinations(index + 1, i + 1, end);
                }
            }
        }
    }
}
