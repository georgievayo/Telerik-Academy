using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int length = input.Length;
            long operations = 0;
            int i = 0;
            int j = length - 1;

            while (j > i)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    if (j <= i)
                    {
                        break;
                    }
                    if (input[j] >= 'a' && input[j] <= 'z')
                    {
                        int firstOption = Math.Abs((int)input[i] - (int)input[j]);
                        int secondOption = Math.Abs((int)'z' - Math.Abs((int)input[j] - ((int)input[i])) - (int)'a' + 1);
                        operations += Math.Min(firstOption, secondOption);
                    }
                    else
                    {
                        while (input[j] < 'a' && input[j] > 'z')
                        {
                            --j;
                        }

                        if (j <= i)
                        {
                            break;
                        }

                        if (input[j] >= 'a' && input[j] <= 'z')
                        {
                            int firstOption = Math.Abs((int)input[i] - (int)input[j]);
                            int secondOption = Math.Abs((int)'z' - Math.Abs((int)input[j] -
                                                        ((int)input[i])) - (int)'a' + 1);
                            operations += Math.Min(firstOption, secondOption);
                        }
                    }

                    --j;
                }
                i++;
                //char left = input[i];
                //char right = input[j];
                //while ((input[i] < 'a' || input[i] > 'z') && i < j)
                //{
                //    i++;
                //    left = input[i];
                //}

                //while ((input[j] < 'a' || input[j] > 'z') && i < j)
                //{
                //    j--;
                //    right = input[j];
                //}

                //if (i >= j)
                //{
                //    break;
                //}

                //int firstOption = Math.Abs(left - right);
                //int secondOption = Math.Abs('z' - Math.Abs(right - left) - 'a' + 1);
                //operations += Math.Min(firstOption, secondOption);

                //i++;
                //j--;
            }

            Console.WriteLine(operations);
        }
        
    }
}
