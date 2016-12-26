using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseURL
{
    class ParseURL
    {
        static void Main(string[] args)
        {
            string[] link = Console.ReadLine().Split(':', '/');
            Console.WriteLine("[protocol] = {0}", link[0]);
            Console.WriteLine("[server] = {0}", link[3]);
            StringBuilder sb = new StringBuilder();
            for (int i = 4; i < link.Length; i++)
            {
                if (i != link.Length - 1)
                {
                    sb = sb.Append(link[i]);
                    sb = sb.Append("/");
                }
                else
                {
                    sb = sb.Append(link[i]);
                }
            }
            Console.WriteLine("[resource] = /{0}", sb.ToString());
        }
    }
}
