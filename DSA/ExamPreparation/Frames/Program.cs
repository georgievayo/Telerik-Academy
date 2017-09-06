using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        private static SortedSet<string> permutations = new SortedSet<string>();
        private static int n = 0;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            Frame[] frames = new Frame[n];
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int first = int.Parse(line[0]);
                int second = int.Parse(line[1]);
                frames[i] = new Frame(first, second);
            }
            GeneratePermutations(frames, 0);

            var result = new StringBuilder();
            foreach (var res in permutations)
            {
                result.AppendLine(res);
            }

            Console.WriteLine(permutations.Count);
            Console.WriteLine(result.ToString().Trim());
        }

        static void GeneratePermutations(Frame[] arr, int k)
        {
            if (k >= n)
            {
                var result = string.Join(" | ", arr.ToList());
                permutations.Add(result);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                SwapFrame(ref arr[k]);
                GeneratePermutations(arr, k + 1);
                SwapFrame(ref arr[k]);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    GeneratePermutations(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void SwapFrame(ref Frame frame)
        {
            int oldFirst = frame.Width;
            frame.Width = frame.Height;
            frame.Height = oldFirst;
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }

    class Frame
    {
        public int Width;
        public int Height;

        public Frame(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Width, this.Height);
        }
    }
}
