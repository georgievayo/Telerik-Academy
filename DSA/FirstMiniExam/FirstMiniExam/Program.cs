using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMiniExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] seq = Console.ReadLine().Split(' ');

            StringBuilder k = new StringBuilder("");
            StringBuilder p = new StringBuilder("");
            foreach (var item in seq)
            {
                if (item[0] == 'M')
                {
                    Console.Write(item + " ");
                }
                else if (item[0] == 'K')
                {
                    k.Append(item + " ");
                }
                else if (item[0] == 'P')
                {                  
                    p.Append(item + " ");
                }
            }

            p.Remove(p.Length - 1, 1);
            Console.Write(k);
            Console.Write(p);
        }
    }
}
