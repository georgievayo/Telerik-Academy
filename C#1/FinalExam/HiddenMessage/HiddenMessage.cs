using System;
namespace HiddenMessage
{
    class HiddenMessage
    {
        static void Main(string[] args)
        {

            string output = "";

            while (true)
            {
                int i, s;
                string input;
                string iAsStr = Console.ReadLine();
                if (!Int32.TryParse(iAsStr, out i) && iAsStr == "end")
                {
                    Console.WriteLine(output);
                    break;
                }
                else if (Int32.TryParse(iAsStr, out i))
                {
                    i = int.Parse(iAsStr);
                    s = int.Parse(Console.ReadLine());
                    input = Console.ReadLine();
                    if (i < 0)
                    {
                        if (s < 0)
                        {
                            for (int j = input.Length + i; j >= 0; j--)
                            {

                                output += input[j];
                                j += s + 1;
                            }
                        }
                        else
                        {
                            for (int j = input.Length + i; j < input.Length; j++)
                            {

                                output += input[j];
                                j += -(s - 1);
                            }
                        }

                    }
                    else
                    {
                        if (s < 0)
                        {
                            for (int j = i; j < input.Length; j++)
                            {

                                output += input[j];
                                j += s - 1;
                                if (j < -1)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int j = i; j < input.Length; j++)
                            {

                                output += input[j];
                                j += s - 1;
                            }
                        }

                    }
                }
                s = 0;
                i = 0;

            }


        }
    }
}
