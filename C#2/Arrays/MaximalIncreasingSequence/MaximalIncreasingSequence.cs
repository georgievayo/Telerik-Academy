using System;

namespace MaximalIncreasingSequence
{
    class MaximalIncreasingSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrOfNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrOfNumbers[i] = int.Parse(Console.ReadLine());
            }
            int numOfSequence = arrOfNumbers[0];
            int counter = 1, maxCounter = 0;
            for (int i = 1; i < n; i++)
            {
                if (arrOfNumbers[i] < numOfSequence)
                {
                    numOfSequence = arrOfNumbers[i];
                    counter++;
                    if (maxCounter < counter)
                    {
                        maxCounter = counter;
                    }
                }
                else if (arrOfNumbers[i] >= numOfSequence)
                {
                    numOfSequence = arrOfNumbers[i];
                    counter = 1;
                }
            }
            Console.WriteLine(maxCounter);
        }
    }
}
