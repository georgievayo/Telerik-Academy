using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpJump
{
    class JumpJump
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == '0')
                {
                    Console.WriteLine("Too drunk to go on after {0}!", i);
                    break;
                }
                else if (input[i] == '^')
                {
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", i);
                    break;
                }
                else if ((input[i] - '0') % 2 == 0)
                {
                    i += (input[i] - '0');
                   // Console.WriteLine("i = {0}", i);
                }
                else if ((input[i] - '0') % 2 != 0)
                {
                    i -= (input[i] - '0');
                    //Console.WriteLine("i = {0}", i);
                }
                if (i < 0 || i >= input.Length)
                {
                    Console.WriteLine("Fell off the dancefloor at {0}!", i);
                    break;
                }
            }
           
        }
    }
}
