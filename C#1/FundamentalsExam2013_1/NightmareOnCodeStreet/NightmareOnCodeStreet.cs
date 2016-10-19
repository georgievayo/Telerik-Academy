using System;

namespace NightmareOnCodeStreet
{
    class NightmareOnCodeStreet
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int counter = 0;
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0 && (input[i] == '0' || input[i] == '1' || input[i] == '2' || input[i] == '3' || input[i] == '4' || input[i] == '5' || input[i] == '6' || input[i] == '7' || input[i] == '8' || input[i] == '9'))
                {
                    counter++;
                    switch (input[i])
                    {
                        case '1': sum += 1; break;
                        case '2': sum += 2; break;
                        case '3': sum += 3; break;
                        case '4': sum += 4; break;
                        case '5': sum += 5; break;
                        case '6': sum += 6; break;
                        case '7': sum += 7; break;
                        case '8': sum += 8; break;
                        case '9': sum += 9; break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("{0} {1}", counter, sum);
        }
    }
}
