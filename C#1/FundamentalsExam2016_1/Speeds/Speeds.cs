using System;

class Speeds
{
    static void Main()
    {
        int c = int.Parse(Console.ReadLine());
        int[] speeds = new int[c];
        for (int i = 0; i < c; i++)
        {
            speeds[i] = int.Parse(Console.ReadLine());
        }

        int firstSpeed = speeds[0], length = 1, sum = firstSpeed, maxSum = 0;
   
        for (int i = 1; i < c; i++)
        {
            if (speeds[i] > firstSpeed)
            {
                length++;
                sum += speeds[i];

                if (length > 1 && sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            else
            {
                firstSpeed = speeds[i]; 
                sum = firstSpeed; 
                length = 1;
            }
        }
       if(maxSum == 0)
       {
           sum = 0;
           for (int i = 0; i < c-1; i++)
           {
               if(speeds[i]==speeds[i+1])
               {
                   sum = speeds[i];
                   if(sum>maxSum)
                   {
                       maxSum = sum;
                   }
               }
           }
           if(maxSum==0)
           {
               Array.Sort(speeds);
               maxSum = speeds[c - 1];
           }
       }
        Console.WriteLine(maxSum);
    }
}
