using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = Console.ReadLine();
            string linkTag = "<a href=";

            StringBuilder href = new StringBuilder("(");
            StringBuilder text = new StringBuilder("[");

            int endOfTag = 0;
            for (int i = 0; i < html.Length; i++)
            {
                if (html[i] == '<' && html[i + 1] == 'a')
                {
                    
                    for (int j = i + 9; html[j] != '"'; j++)
                    {
                        href = href.Append(html[j]);
                    }
                    href = href.Append(")");
                    Console.WriteLine(href.ToString());
                    
                    href = href.Clear();
                    href = href.Append("(");
                   
                }
                if (html[i] == '"' && html[i + 1] == '>')
                {
                   
                    for (int j = i + 2; html[j] != '<' ; j++)
                    {
                        text.Append(html[j]);
                        endOfTag = j;
                    }
                    text = text.Append("]");
                    text = text.Append("(");
                    Console.WriteLine(text.ToString());
                  
                    
                    
                }
                html = html.Replace("<a href=\"", text.ToString());
                html = html.Replace("\">", ")");
                text.Clear();
                text.Append("[");
                endOfTag += 4;


            }
            Console.WriteLine(html);
        }
    }
}
