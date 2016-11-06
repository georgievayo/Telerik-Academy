using System;
using System.Collections;

namespace Enigmanation
{
    class Enigmanation
    {

        static int Calculate(int a, char op, int b)
        {
            int res = 0;
            switch (op)
            {
                case '+': res = a + b; break;
                case '-': res = a - b; break;
                case '*': res = a * b; break;
                case '%': res = a % b; break;
                default:
                    break;
            }
            return res;
        }

        static bool isDigit(char w)
        {
            return ((int)w > 47 && (int)w < 58);
        }

        static bool isOperator(char w)
        {
            return w == '+' || w == '-' || w == '*' || w == '%';
        }

        static void Main()
        {
            string input = Console.ReadLine();
            int result = 0;

            int index = 0;
            int indexOfScope = 0;
            int inScope = 0;
            int prev = 0;
            int next = 0;

            while (input[index] != '=')
            {
                if (isDigit(input[index]) && index == 0)
                {
                    result = (int)input[index] - 48;
                    index++;
                    //Console.WriteLine("result: {0}", result);
                }
                else if (isOperator(input[index]))
                {
                    index++;
                }
                else if (isDigit(input[index]) && isOperator(input[index - 1]))
                {
                    next = (int)input[index] - 48;
                    result = Calculate(result, input[index - 1], next);
                    index++;
                }
                else if (input[index] == '(')
                {
                    indexOfScope = index;
                    index++;
                    inScope = 0;
                    do
                    {

                        if (isDigit(input[index]) && index == indexOfScope + 1)
                        {
                            prev = (int)input[index] - 48;
                            index++;
                        }
                        else if (isOperator(input[index]))
                        {
                            index++;
                        }
                        else if (isDigit(input[index]) && isOperator(input[index - 1]))
                        {
                            next = (int)input[index] - 48;
                            inScope += Calculate(prev, input[index - 1], next);
                            index++;
                        }
                    } while (input[index] != ')');
                    //result = Calculate(result, input[tempIndex],inScope);
                    if (input[index] == ')' && indexOfScope != 0)
                    {
                        result = Calculate(result, input[indexOfScope - 1], inScope);
                    }
                    else if (input[index] == ')' && indexOfScope == 0)
                    {
                        result = inScope;
                    }
                    index++;
                    //Console.WriteLine(inScope);
                }

            }
            Console.WriteLine("{0:F3}",(double)result);
        }
    }
}
