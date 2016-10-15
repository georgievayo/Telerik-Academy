using System;

namespace MaximalSequence
{
    class MaximalSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int maxCounter = 1;
            
            int[] arrayOfNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrayOfNumbers[i] = int.Parse(Console.ReadLine());
            }
            int number = arrayOfNumbers[0];
            for (int i = 1; i < n; i++)
            {
                if(arrayOfNumbers[i] == number)
                {
                    counter++;
                    if (maxCounter < counter)
                    {
                        maxCounter = counter;
                    }
                }
                else if(arrayOfNumbers[i] != number)
                {
                    number = arrayOfNumbers[i];
                    counter = 1;
                }
            }
            Console.WriteLine(maxCounter);
        }
    }
}
