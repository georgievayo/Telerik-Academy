using System;

namespace FindSumInArray
{
    class FindSumInArray
    {
        static void Main()
        {
            int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11, mySum = 0, indexOfFirstNumber = 0;
            int[] numbers = new int[7];
            for (int i = 0; i < 7; i++)
            {
                mySum += arr[i];
                numbers[i] = arr[i];
                for (int j = i + 1; j < 7; j++)
                {
                    mySum += arr[j];
                    numbers[j] = arr[j];
                    if (mySum == 11)
                    {
                        for (int k = indexOfFirstNumber; k <= j; k++)
                        {
                            Console.WriteLine(numbers[k]);
                        }
                    }
                    else if (mySum > 11)
                    {
                        mySum = 0;
                        indexOfFirstNumber = i + 1;
                        break;
                    }
                }
            }
        }
    }
}
